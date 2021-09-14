const _apiBase = 'https://localhost:5001/api';

const postOptions = {
    method: 'POST',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
    }
};

const getPostOptionsWithToken = (token, body) => {
    const options = { ...postOptions };
    options.headers = {...options.headers, 'Authorization': 'Bearer ' + token, 'Accept': 'application/json',
    'Content-Type': 'application/json',};
    if (body) {
        options.body = JSON.stringify(body);
    }

    return options;
};

const getPostOptionsWithBody = (body) => ({ ...postOptions, body: JSON.stringify(body)});

async function getResource(url, options = null) {
    console.log(options);
    const res = await fetch(`${_apiBase}${url}`, options);
    if (!res.ok) {
        throw new Error(`Could not fetch ${url}, received ${res.status}`);
    }

    return await res.json();
}

async function postResource(url, options) {
    return await fetch(`${_apiBase}${url}`, options);
}

const getRequestsForUser = async (id, token) => {
    console.log(id);
    return await getResource(`/requests/`, {headers: {authorization: 'Bearer ' + token}});
}

const authenticate = async (user, auth) => {
    return auth ? await postResource(`/users/`, getPostOptionsWithBody(user)) :
        await postResource(`/users/registration`, getPostOptionsWithBody(user));
};

const signOut = async (id, token) =>
    await postResource(`/users/signout/${id}`, getPostOptionsWithToken(token));

const deleteRequestForUser = async (id, token) => {
    const deleteOptions = {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
    };

    return await fetch(`${_apiBase}/requests/${id}`, deleteOptions);
}

const createRequestForUser = async (id, token, createdRequest) => {

    createdRequest.userId = id;
    createdRequest.droneId = '9fffa88b-91c5-42a6-8692-1fd8701fb0e4';

    console.log(createdRequest);

    const options = {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(createdRequest)
    };

    return await fetch(`${_apiBase}/requests/`, options);
}

const updateRequestForUser = async (id, token, requestId, updatedRequest) => {
    updatedRequest.userId = id;
    updatedRequest.droneId = '9fffa88b-91c5-42a6-8692-1fd8701fb0e4';

    console.log(updatedRequest);

    const options = {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(updatedRequest)
    };

    return await fetch(`${_apiBase}/requests/${requestId}`, options);
}

const getAllComments = async (token) =>
    await getResource('/comments/', {headers: {authorization: 'Bearer ' + token}});

const getAllDrones = async (token) =>
    await getResource('/drones/', {headers: {authorization: 'Bearer ' + token}});

export { getAllDrones, 
    authenticate, signOut, getRequestsForUser, deleteRequestForUser, createRequestForUser, updateRequestForUser, getAllComments,
    _apiBase, postOptions,  getPostOptionsWithToken, getPostOptionsWithBody, getResource};