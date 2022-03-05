import axios from "axios";

const apiUrl = 'https://localhost:44374'

export const getVehicles = async () => await axios.get(`${apiUrl}/Vehicle/getVehicles`);