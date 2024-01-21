import * as hurricaneApi from './hurricane-api';

export async function getAllHurricanes() {
    try {
        const response = await hurricaneApi.index();
        const data = response.reverse();
        return data;
    } catch (err) {
        console.log(err);
        return err;
    }
}

export async function getHurricane(id) {
    try {
        const response = await hurricaneApi.show(id);
        if(response.length){
            return response[0];
        } else {
            return null;
        }
    } catch (err) {
        console.log(err);
        return err;
    }
}