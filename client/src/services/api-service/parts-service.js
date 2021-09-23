import { headers, getOptions, fetchData, postResource, getAuthorization } from ".";

const url = '/parts';

async function getParts(token) {
    const options = getOptions('GET', headers, token);

    return await fetchData(url, options);
}

async function createPart(token, part) {
    const options = getOptions('POST', headers, token, part);

    return await postResource(url, options);
}

export { getParts, createPart }