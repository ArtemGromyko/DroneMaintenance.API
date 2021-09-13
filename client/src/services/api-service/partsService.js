import { _apiBase, getPostOptionsWithToken, getPostOptionsWithBody, getResource } from ".";

function getParts(token) {
    return getResource('/parts/', {headers: {authorization: `Bearer ${token}`}});
}

export { getParts };