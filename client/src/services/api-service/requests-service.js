import { headers, getOptions, fetchData, postResource, createUrl } from ".";

const requestUrl = '/requests';
const userUrl = '/users';

function createUrlForRequests({role, id}) {
    return role === 'admin' ?
        requestUrl : createUrl(userUrl, id, requestUrl);
}

async function getRequests(user) {
    const options = getOptions('GET', headers, user.token);
    const url = createUrlForRequests(user);

    return await fetchData(url, options);
}

async function createRequest(token, request) {
    const options = getOptions('POST', headers, token, request);

    return await postResource(requestUrl, options);
}

export { getRequests, createRequest }