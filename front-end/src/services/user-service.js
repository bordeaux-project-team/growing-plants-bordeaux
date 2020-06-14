import {fetchPost, fetchGet} from "./base-service";
import AsyncStorage from '@react-native-community/async-storage';

const login = async (email, password) => {
  let response = await fetchPost(`/api/user/login`, {
    email, password
  }, false);
  if (response.status == 401) {
    // Force login
  }
  if (response.status == 200) {
    
  }
  console.log(response);
  let result =  await response.json();
  console.log(result);
};

const signUp = async (user) => {
  let response = await fetchPost(`/api/user/register-account`, user, false);
  return await response.json();
}

export {login, signUp}
