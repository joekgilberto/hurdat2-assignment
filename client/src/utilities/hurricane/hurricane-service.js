//Imports custom API call functions
import * as hurricaneApi from './hurricane-api';

//Exports getAllHurricanes function that calls upon hurricaneApi.index() in a try/catch, reverses the order of the results, and returns it
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

//Exports getHurricane function with an id as a parameter that calls upon hurricaneApi.show() in a try/catch, with said id parameter passed as an argument, and, if the response exits and has a length, returns the first index, otherwise returning an empty object 
export async function getHurricane(id) {
    try {
        const response = await hurricaneApi.show(id);
        if(response){
            if(response.length){
                return response[0];
            } else{
                return {};
            }
        } else {
            return {};
        }
    } catch (err) {
        console.log(err);
        return err;
    }
}