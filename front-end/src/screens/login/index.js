import React, {Component} from 'react';
import LoginForm from './login/login-form.component';
import RegisterForm from './register/register-form.component';
import {Text, View} from 'react-native';
import styles from '../login/login-container.style';
import ForgotPasswordForm from './forgot-password/forgot-password-form.component';
import LOGIN_SCREEN from './login-screen.const';

class LoginContainer extends Component {
  constructor(props) {
    super(props);
  }

  renderScreen() {
    const screenType = this.props.screenType;
    let screen;
    switch (screenType) {
      case LOGIN_SCREEN.register:
        screen = <RegisterForm />;
        break;
      case LOGIN_SCREEN.forgot:
        screen = <ForgotPasswordForm />;
        break;
      default:
        screen = <LoginForm />;
        break;
    }
    return screen;
  }

  render() {
    return (
      <View style={styles.plantingWithHntaColumn}>
        <Text style={styles.plantingWithHnta}>PLANTING WITH HNTA</Text>
        {this.renderScreen()}
      </View>
    );
  }
}

export default LoginContainer;
