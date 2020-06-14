import React, {Component} from 'react';
import Login from './Login';
import {login, signUp} from '../../services/user-service';
import AsyncStorage from '@react-native-community/async-storage';

export default class LoginScreen extends Component {
  render() {
    return <Login doLogin={this.doLogin} />;
  }

  async doLogin() {
    await login('john.wick@gmail.com', 'TheJohnWick!1234');
    const token = await AsyncStorage.getItem("token");
    const user = JSON.parse(await AsyncStorage.getItem("user"));
    console.log(`Token: ${token}`);
    console.log(`User: ${JSON.stringify(user)}`);
  }

  async signUp() {

  }
}
