import axios from 'axios';

export const setupAxios = (state: any, action: any) => {
  axios.defaults.baseURL = process.env.REACT_APP_API_URL;
}

export default axios;