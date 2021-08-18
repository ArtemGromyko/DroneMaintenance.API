const _apiBase = 'https://localhost:5001/api';

async function getResource(url) {
    const res = await fetch(`${_apiBase}${url}`);
    if (!res.ok) {
        throw new Error(`Could not fetch ${url}, received ${res.status}`);
    }
    return await res.json();
}

const getAllDrones = () =>
    this.getResource(`/drones/`);

const authenticate = async (user) => {
    console.log(JSON.stringify(user));
    return await fetch(`${_apiBase}/users/`, {
        method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }, body: JSON.stringify(user)
    });
};

const register = async (user) => {
    return await fetch(`${_apiBase}/users/registration`, {
        method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }, body: JSON.stringify(user)
    });
}

export { getAllDrones, authenticate, register };