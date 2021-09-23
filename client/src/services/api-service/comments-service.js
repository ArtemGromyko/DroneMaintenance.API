import { headers, getOptions, fetchData, postResource, createUrlWithId } from ".";

const url = '/comments/';

async function getComments(token) {
    const options = getOptions('GET', headers, token);

    return await fetchData(url, options);
}

async function getCommentById(token, id) {
    const options = getOptions('GET', headers, token);

    return await fetchData(createUrlWithId(url, id), options);
}

async function createComment(token, comment) {
    const options = getOptions('POST', headers, token, comment);

    return await fetchData(url, options);
}

async function updateComment(token, commentId, comment) {
    const options = getOptions('PUT', headers, token, comment);

    return await fetchData(createUrlWithId(url, commentId), options);
}

async function deleteComment(token, commentId) {
    const options = getOptions('DELETE', headers, token);

    return await fetchData(createUrlWithId(url, commentId), options);
}

export { getComments, createComment, updateComment, getCommentById, deleteComment }