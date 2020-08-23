import {fetchPost} from './base-service';
import AsyncStorage from '@react-native-community/async-storage';

const doLogin = async (email, password) => {
  let response = await fetchPost(
    'api/user/login',
    {
      email,
      password,
    },
    false,
  );
  let loginResult = await response.json();
  if (loginResult.result) {
    await AsyncStorage.setItem('token', loginResult.result.token);
    await AsyncStorage.setItem('user', JSON.stringify(loginResult.result));
  }
  return loginResult;
};

export const registerModel = {
  firstName: 'test',
  lastName: 'test',
  dateOfBirth: '1996-09-30', // YYYY-MM-DD
  gender: true,
  email: 'test@gmail.com',
  password: 'abc!1234',
};

const registerAccount = async register => {
  let response = await fetchPost('api/user/register-account', register, false);
  return await response.json();
};

export {doLogin, registerAccount};
