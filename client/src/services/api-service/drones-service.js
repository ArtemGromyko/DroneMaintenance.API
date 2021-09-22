import { _apiBase, headers, getOptions, getResource, postResource, getAuthorization } from ".";

const url = '/drones';

async function getDrones(token) {
    const options = getOptions('GET', {...headers, ...getAuthorization(token)});

    return await getResource(url, options);
}

async function createDrone(token, drone) {
    const options = getOptions('POST', {...headers, ...getAuthorization(token)}, drone);

    return await postResource(url, options);
}

export { getDrones, createDrone }