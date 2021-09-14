import { _apiBase, getPostOptionsWithToken, getPostOptionsWithBody, getResource } from ".";

function getContracts(token) {
    return getResource('/contracts/', {headers: {authorization: `Bearer ${token}`}});
}

function createContract(token, body) {

}

export { getContracts };