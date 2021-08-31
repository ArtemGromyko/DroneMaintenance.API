import React, { useContext, useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import IconButton from '@material-ui/core/IconButton';
import DeleteIcon from '@material-ui/icons/Delete';
import { MainContext } from '../../contexts/main-context';
import { deleteRequestForUser } from '../../services/api-service';
import EditIcon from '@material-ui/icons/Edit';
import TableFooter from '@material-ui/core/TableFooter';
import Button from '@material-ui/core/Button';
import { getRequestsForUser } from '../../services/api-service';
import { useHistory } from 'react-router';
import { RequestsContext } from '../../contexts/requests-context';

const columns = [
  {
    id: 'delete',
    label: 'Action',
  },
  {
    id: 'requestStatus',
    label: 'RequestStatus',
    align: 'left'
  },
  {
    id: 'serviceType',
    label: 'ServiceType',
    minWidth: 100,
  },
  {
    id: 'date',
    label: 'Date',
    minWidth: 100,
  },
  {
    id: 'description',
    label: 'Description',
    minWidth: 100,
    align: 'right'
  },
];

const useStyles = makeStyles({
  root: {
    width: '100%',
    margin: '0 auto'
  },
  container: {
    maxHeight: 600,
  },
  tableFooter: {
    width: '80%',
    minHeight: '75px',
    margin: '0 auto',
  },
  buttonCreate: {
    background: 'linear-gradient(45deg, #2196F3 30%, #21CBF3 90%)',
    border: 0,
    borderRadius: 3,
    boxShadow: '0 3px 5px 2px rgba(33, 203, 243, .3)',
    color: 'white',
  },
  pagination: {
    marginLeft: 'auto'
  }
});

export default function RequestsPage() {
  const [rows, setRows] = useState([]);

  const { user } = useContext(MainContext);
  const history = useHistory();
  const { setRequest } = useContext(RequestsContext);

  useEffect(() => {
    if (user) {
      getRequestsForUser(user.id, user.token).then((res) => setRows(res));
    } else {
      setRows([]);
    }
  }, [user]);

  const classes = useStyles();
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);

  const handleDelete = (id) => {
    deleteRequestForUser(id, user.token)
      .then((response) => {
        if (response.ok) {
          var array = rows.filter((i) => i.id !== id);
          setRows(array);
        }
      })
  };

  const handleEdit = (id) => {
    setRequest(rows.find((r) => r.id === id));
    history.push('/request-editing');
  }

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  return (
    <Paper className={classes.root}>
      <TableContainer className={classes.container}>
        <Table stickyHeader aria-label="sticky table">
          <TableHead>
            <TableRow>
              {columns.map((column) => (
                <TableCell
                  key={column.id}
                  align={column.align}
                  style={{ minWidth: column.minWidth }}
                >
                  {column.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((row) => {

              return (
                <TableRow hover role="checkbox" tabIndex={-1} key={row.id}>
                  <TableCell align='left'>
                    <IconButton onClick={() => handleDelete(row.id)} aria-label="delete">
                      <DeleteIcon />
                    </IconButton>
                    <IconButton onClick={() => handleEdit(row.id)} aria-label="delete">
                      <EditIcon />
                    </IconButton>
                  </TableCell>

                  {columns.map((column) => {
                    const value = row[column.id];
                    if (value !== undefined) {
                      return (
                        <TableCell key={column.id} align={column.align}>
                          {value}
                        </TableCell>
                      );
                    }
                  })}
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
      <TableFooter >
        <TableRow >
          <TableCell colSpan={1}>
            <Button variant="contained" className={classes.buttonCreate} onClick={() => history.push('/request-creating')}>
              Create
            </Button>
          </TableCell>
          <TableCell className={classes.pagination}>
            <TablePagination
              rowsPerPageOptions={[10, 25, 100]}
              component="div"
              count={rows.length}
              rowsPerPage={rowsPerPage}
              page={page}
              onPageChange={handleChangePage}
              onRowsPerPageChange={handleChangeRowsPerPage}
            >
            </TablePagination>
          </TableCell>
        </TableRow>
      </TableFooter>
    </Paper>
  );
}
