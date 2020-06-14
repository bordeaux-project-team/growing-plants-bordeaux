import {fetchPost} from "./base-service";
import AsyncStorage from '@react-native-community/async-storage';

const doLogin = async (email, password) => {
  let response = await fetchPost(`/api/user/login`, {
    email, password
  }, false);
  let loginResult = await response.json();
  await AsyncStorage.setItem("token", loginResult.result.token);
  await AsyncStorage.setItem("user", JSON.stringify(loginResult.result));
};


export {doLogin}
