import { headers, getOptionsWithToken, fetchData, getOptionsWithTokenWithoutToken } from ".";

async function authenticate(user, auth) {
    const options = getOptionsWithTokenWithoutToken('POST', headers, user);

    return auth ? await fetchData(`/users/`, options) :
        await fetchData(`/users/registration`, options);
};

async function signOut(id, token) {
    const options = getOptionsWithToken('POST', headers, token);

    return await fetchData(`/users/signout/${id}`, options);
}

export { authenticate, signOut }