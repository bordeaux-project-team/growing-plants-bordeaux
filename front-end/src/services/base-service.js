import {apiUrl} from '../../app.json';
import AsyncStorage from '@react-native-community/async-storage';

const headers = {
  Accept: 'application/json',
  'Content-Type': 'application/json',
};

const headersAuth = {
  Accept: 'application/json',
  'Content-Type': 'application/json',
  Authorization: '',
};

const getToken = async () => {
  try {
    return `Bearer ${await AsyncStorage.getItem('token')}`;
  } catch (err) {
    console.log(err);
    return null;
  }
};

const fetchPost = async (endPoint, data, auth) => {
  try {
    let header = headers;
    if (auth) {
      header = headersAuth;
      header.Authorization = await getToken();
    }
    const url = `${apiUrl}${endPoint}`;
    return await fetch(url, {
      method: 'POST',
      headers: header,
      body: JSON.stringify(data),
    });
  } catch (err) {
    console.log(err);
    return err;
  }
};

const fetchGet = async (endPoint, auth) => {
  try {
    let header = headers;
    if (auth) {
      header = headersAuth;
      header.Authorization = await getToken();
    }
    const url = `${apiUrl}${endPoint}`;
    return await fetch(url, {
      headers: header,
    });
  } catch (err) {
    console.log(err);
    return err;
  }
};

export {fetchPost, fetchGet};
