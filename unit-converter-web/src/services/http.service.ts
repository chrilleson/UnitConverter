import axios, { AxiosHeaders } from 'axios';

export const setupAxios = (axios: any, store: any) => {
  axios.defaults.baseURL = process.env.REACT_APP_API_URL;

  axios.interceptors.request.use(
    (request: { headers: AxiosHeaders }) => {
      request.headers.set('Content-type', 'application/json');

      return request;
    },
    (error: any) => {
      return Promise.reject(error);
    }
  )

  axios.interceptors.response.use(
    (response: any) =>{
      return response;
    },
    (error: any) => {
      console.warn(error);
      
      const message = error.response.data.message || error.message;

      store.dispatch({ type: 'SHOW_ERROR', error: { openDialog: true, message: message }});
      return Promise.reject(error);
    }
  )
}

export default axios;