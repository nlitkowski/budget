import axios from "axios";

export const ApiClient = axios.create({
    baseURL: 'https://localhost:44312/api/',
    timeout: 1000,
    headers: {}
});