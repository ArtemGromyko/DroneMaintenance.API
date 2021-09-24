import { headers, getOptionsWithToken, fetchData, createUrlWithId } from ".";

const url = '/drones/';

async function getDrones(token) {
    const options = getOptionsWithToken('GET', headers, token);

    return await fetchData(url, options);
}

async function createDrone(token, drone) {
    const options = getOptionsWithToken('POST', headers, token, drone);

    return await fetchData(url, options);
}

async function deleteDrone(token, id) {
    const options = getOptionsWithToken('DELETE', headers, token);

    return await fetchData(createUrlWithId(url, id), options);
}

async function updateDrone(token, id, drone) {
    const options = getOptionsWithToken('PUT', headers, token, drone);

    return await fetchData(createUrlWithId(url, id), options);
}

export { getDrones, createDrone, deleteDrone, updateDrone }