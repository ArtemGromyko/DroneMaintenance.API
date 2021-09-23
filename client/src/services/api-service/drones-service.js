import { headers, getOptions, fetchData, createUrlWithId } from ".";

const url = '/drones';

async function getDrones(token) {
    const options = getOptions('GET', headers, token);

    return await fetchData(url, options);
}

async function createDrone(token, drone) {
    const options = getOptions('POST', headers, token, drone);

    return await fetchData(url, options);
}

async function deleteDrone(token, id) {
    const options = getOptions('DELETE', headers, token);

    return await fetchData(createUrlWithId(url, id), options);
}

async function updateDrone(token, id, drone) {
    const options = getOptions('PUT', headers, token, drone);

    return await fetchData(createUrlWithId(url, id), options);
}

export { getDrones, createDrone, deleteDrone, updateDrone }