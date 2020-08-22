import React, {Component} from 'react';
import LoginForm from './login/login-form.component';
import RegisterForm from './register/register-form.component';
import {doLogin} from '../../services/user-service';
import {Text, View} from 'react-native';
import styles from '../login/login-container.style';
import AsyncStorage from '@react-native-community/async-storage';
import ForgotPasswordForm from './forgot-password/forgot-password-form.component';

class LoginContainer extends Component {
  render() {
    return (
      <View style={styles.plantingWithHntaColumn}>
        <Text style={styles.plantingWithHnta}>PLANTING WITH HNTA</Text>
        <LoginForm doLogin={this.doLogin} />
        {/*<RegisterForm />*/}
        {/* <ForgotPasswordForm /> */}
      </View>
    );
  }

  async doLogin() {
    const email = 'abc@gmail.com';
    const passwrod = 'admin1234';
    const loginResult = await doLogin(email, passwrod);
    if (loginResult.result) {
      console.log("Login success");
    } else {
      console.log("Login failed");
    }
  }
}

export default LoginContainer;
