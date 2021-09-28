import { headers, getOptionsWithToken, fetchData, postResource, getAuthorization } from ".";

const url = '/contracts';

async function getContracts(token) {
    const options = getOptionsWithToken('GET', headers, token);
    const res = await fetchData(url, options);

    return res.json();
}

async function createContract(token, drone) {
    const options = getOptionsWithToken('POST', headers, token, drone);

    return await postResource(url, options);
}

export { getContracts, createContract }