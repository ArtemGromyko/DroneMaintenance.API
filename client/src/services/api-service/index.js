const _apiBase = 'https://localhost:5001/api';

async function getResource(url) {
    const res = await fetch(`${_apiBase}${url}`);
    if (!res.ok) {
        throw new Error(`Could not fetch ${url}, received ${res.status}`);
    }

    return await res.json();
}

async function postResource(url, options) {
    return await fetch(`${_apiBase}${url}`, options);
}

const getAllDrones = () =>
    this.getResource(`/drones/`);

const authenticationOptions = {
    method: 'POST',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
};

const authenticate = async (user, auth) => {
    const options = { ...authenticationOptions, body: JSON.stringify(user) };
    return auth ? await postResource(`/users/`, options) :
        await postResource(`/users/registration`, options);
};

const signOut = async (id, token) => {
    const options = {
        method: 'POST', headers: {
            ...authenticationOptions.headers, 'Authorization': 'Bearer ' + token
        }
    };
    
    return await postResource(`/users/signout/${id}`, options);
};

export { getAllDrones, authenticate, signOut };