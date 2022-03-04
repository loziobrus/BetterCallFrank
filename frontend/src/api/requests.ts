import axios from "axios";

const apiUrl = 'https://localhost:44374'

export const getWarehouses = async () => await axios.get(`${apiUrl}/Warehouse/getWarehouses`);