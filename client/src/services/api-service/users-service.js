import { headers, getOptions, fetchData, createUrlWithId } from ".";

async function authenticate(user, auth) {
    const options = getOptions('POST', headers, token, user);

    return auth ? await fetchData(`/users/`, options) :
        await fetchData(`/users/registration`, options);
};

async function signOut(id, token) {
    const options = getOptions('POST', headers, token, user);

    return await fetchData(`/users/signout/${id}`, options);
}

export { authenticate, signOut }