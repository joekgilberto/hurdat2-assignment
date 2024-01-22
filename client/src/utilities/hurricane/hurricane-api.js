//Imports axios from axios and assigns BASE_URL to evvironmental variable REACT_APP_HURRICANE_URL
import axios from 'axios';
const BASE_URL = process.env.REACT_APP_HURRICANE_PROD_URL;

//Exports async function index that returns data from response of BASE_URL/landfalls/, a list of all landfall hurricanes
export async function index() {
    return axios
        .get((`${BASE_URL}landfalls/`))
        .then((res) => {
            return res.data
        })
        .catch((err) => console.log(err));
};

//Exports async function show that returns data from response of BASE_URL/:id/, a single hurricane
export async function show(id) {
    return axios
        .get(`${BASE_URL}${id}/`)
        .then((res) => {
            return res.data
        })
        .catch((err) => console.log(err));

};