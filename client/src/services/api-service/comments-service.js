import { _apiBase, headers, getOptions, getResource, postResource, getAuthorization } from ".";

const url = '/comments';

async function getComments(token) {
    const options = getOptions('GET', {...headers, ...getAuthorization(token)});

    return await getResource(url, options);
}

async function createComment(token, comment) {
    const options = getOptions('POST', {...headers, ...getAuthorization(token)}, comment);

    return await postResource(url, options);
}

export { getComments, createComment }