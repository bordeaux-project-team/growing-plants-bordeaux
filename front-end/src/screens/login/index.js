import React, {Component} from 'react';
import Login from './Login';
import {doLogin} from '../../services/user-service';
import AsyncStorage from '@react-native-community/async-storage';

class LoginContainer extends Component {
  render() {
    return <Login doLogin={this.doLogin} />;
  }

  async doLogin() {
    await doLogin('john.wick@gmail.com', 'TheJohnWick!1234');
    const token = await AsyncStorage.getItem("token");
    const user = JSON.parse(await AsyncStorage.getItem("user"));
    console.log(`Token: ${token}`);
    console.log(`User: ${JSON.stringify(user)}`);
  }
}

export default LoginContainer;
