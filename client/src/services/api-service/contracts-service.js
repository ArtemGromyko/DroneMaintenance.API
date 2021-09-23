import { headers, getOptions, fetchData, postResource, getAuthorization } from ".";

const url = '/contracts';

async function getContracts(token) {
    const options = getOptions('GET', headers, token);

    return await fetchData(url, options);
}

async function createContract(token, drone) {
    const options = getOptions('POST', headers, token, drone);

    return await postResource(url, options);
}

export { getContracts, createContract }