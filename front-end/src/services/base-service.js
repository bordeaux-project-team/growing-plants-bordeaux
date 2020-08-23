import {apiUrl} from '../../app.json';
import AsyncStorage from '@react-native-community/async-storage';

const headers = {
  Accept: 'application/json',
  'Content-Type': 'application/json',
};

const getToken = async () => {
  try {
    return await AsyncStorage.getItem('token');
  } catch (err) {
    console.log(err);
    return null;
  }
}

const fetchGet = async (endPoint, auth) => {
  try {
    const header = headers;
    if (auth) {
      header.Authorization = `Bearer ${await getToken()}`;
    }
    const url = `${apiUrl}/${endPoint}`;
    return await fetch(url, {
      headers: header
    });
  } catch (err) {
    console.log(err);
    return err;
  }
}

const fetchPost = async (endPoint, data, auth) => {
  try {
    const header = headers;
    if (auth) {
      header.Authorization = `Bearer ${await getToken()}`;
    }
    const url = `${apiUrl}/${endPoint}`;
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

export {fetchPost};
