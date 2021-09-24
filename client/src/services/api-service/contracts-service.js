import { headers, getOptionsWithToken, fetchData, postResource, getAuthorization } from ".";

const url = '/contracts';

async function getContracts(token) {
    const options = getOptionsWithToken('GET', headers, token);

    return await fetchData(url, options);
}

async function createContract(token, drone) {
    const options = getOptionsWithToken('POST', headers, token, drone);

    return await postResource(url, options);
}

export { getContracts, createContract }