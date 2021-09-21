import { _apiBase, headers, getOptions, getResource, postResource, getAuthorization } from ".";

const url = `${_apiBase}/comments`;

async function getComments(token) {
    const options = getOptions('GET', ...headers, getAuthorization(token));

    return await getResource(url, oprions);
}

export { getComments }