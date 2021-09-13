import { _apiBase, getPostOptionsWithBody, getPostOptionsWithBody, getResource } from ".";


function getServiceRequests(token) {
    return getResource('/requests/', {headers: {authorization: 'Bearer ' + token}});
}

function getServiceRequest(token, id) {
    return getResource(`/requests/${id}`, {headers: {authorization: 'Bearer ' + token}});
}

export {getServiceRequest, getServiceRequests};