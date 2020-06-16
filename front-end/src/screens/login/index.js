import React, {Component} from 'react';
import LoginForm from './login/login-form.component';
import {doLogin} from '../../services/user-service';
import {Text, View} from 'react-native';
import styles from '../login/login-container.style';
import AsyncStorage from '@react-native-community/async-storage';

class LoginContainer extends Component {
  render() {
    return (
      <View style={styles.plantingWithHntaColumn}>
        <Text style={styles.plantingWithHnta}>PLANTING WITH HNTA</Text>
        <LoginForm doLogin={this.doLogin} />
      </View>
    );
  }

  async doLogin() {
    await doLogin('john.wick@gmail.com', 'TheJohnWick!1234');
    const token = await AsyncStorage.getItem('token');
    const user = JSON.parse(await AsyncStorage.getItem('user'));
    console.log(`Token: ${token}`);
    console.log(`User: ${JSON.stringify(user)}`);
  }
}

export default LoginContainer;
