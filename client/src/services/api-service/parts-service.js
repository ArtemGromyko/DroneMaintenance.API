import { headers, getOptionsWithToken, fetchData, postResource, getAuthorization } from ".";

const url = '/parts';

async function getParts(token) {
    const options = getOptionsWithToken('GET', headers, token);

    return await fetchData(url, options);
}

async function createPart(token, part) {
    const options = getOptionsWithToken('POST', headers, token, part);

    return await postResource(url, options);
}

export { getParts, createPart }