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
        <LoginForm />
        {/*<RegisterForm />*/}
        {/* <ForgotPasswordForm /> */}
      </View>
    );
  }
}

export default LoginContainer;
