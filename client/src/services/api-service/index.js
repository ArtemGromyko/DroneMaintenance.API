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

const getAllDrones = () =>
    getResource(`/drones/`);

const getRequestsForUser = async (id, token) => {
    console.log(id);
    return await getResource(`/requests/`, {headers: {authorization: 'Bearer ' + token}});
}

const authenticate = async (user, auth) => {
    console.log(getPostOptionsWithBody(user));
    console.log(user);
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

export { getAllDrones, authenticate, signOut, getRequestsForUser, deleteRequestForUser };