import {useContext, useEffect} from "react";
import {MainContext} from '../../contexts/main-context'
import {useHistory} from "react-router-dom";

function WithJwt({children}) {
    const {jwt} = useContext(MainContext);
    const history = useHistory();

    useEffect(()=>{
        if(jwt === '' || !jwt){
            history.push('/login')
        }
    }, []);

    return children;
}

export default WithJwt;