import axios from 'axios';
const BASE_URL = process.env.REACT_APP_HURRICANE_URL;

export async function index() {
    return axios
        .get((`${BASE_URL}landfalls/`))
        .then((res) => {
            return res.data
        })
        .catch((err) => console.log(err));
};

export async function show(id) {
    return axios
        .get(`${BASE_URL}${id}/`)
        .then((res) => {
            return res.data
        })
        .catch((err) => console.log(err));

};