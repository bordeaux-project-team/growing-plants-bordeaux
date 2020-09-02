import React, {Component} from 'react';
import {Alert, View} from 'react-native';
import styles from './login-form.style';
import loginInputStyles from '../../common-elements/login-common.style';
import InputText from '../../common-elements/input-text.component';
import TouchButton from '../../common-elements/button.component';
import {doLogin} from '../../../services/user-service';
import {useNavigation} from '@react-navigation/native';
import LOGIN_SCREEN from '../login-screen.const';

class LoginForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      password: '',
    };
    this.doLogin = this.doLogin.bind(this);
    this._navigateToRegister = this._navigateToRegister.bind(this);
    this._navigateToForgotPassword = this._navigateToForgotPassword.bind(this);
  }

  setEmailState = email => {
    this.setState({email});
  };

  setPasswordState = password => {
    this.setState({password});
  };

  async doLogin() {
    const email = this.state.email;
    const password = this.state.password;
    const {navigation} = this.props;
    const loginResult = await doLogin(email, password);
    if (loginResult.result) {
      navigation.navigate('MainScreen');
    } else {
      Alert.alert('Login Fail!', 'Please check your Email or Password', [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    }
  }

  _navigateToRegister() {
    const {navigation} = this.props;
    navigation.navigate('StartScreen', {
      screenType: LOGIN_SCREEN.register,
    });
  }

  _navigateToForgotPassword() {
    const {navigation} = this.props;
    navigation.navigate('StartScreen', {
      screenType: LOGIN_SCREEN.forgot,
    });
  }

  render() {
    return (
      <View style={styles.form}>
        <InputText
          onChangeText={email => this.setEmailState(email)}
          inputStyle={loginInputStyles.username}
          iconName="user"
          iconStyle={loginInputStyles.usernameIcon}
          placeholder="Email"
          textInputStyle={loginInputStyles.usernameInput}
        />
        <InputText
          secureTextEntry={true}
          onChangeText={password => this.setPasswordState(password)}
          inputStyle={loginInputStyles.password}
          iconName="lock"
          iconStyle={loginInputStyles.passwordIcon}
          placeholder="Password"
          textInputStyle={loginInputStyles.passwordInput}
        />
        <TouchButton
          doPress={this.doLogin}
          buttonTypeStyle={loginInputStyles.mainButton}
          buttonTextStyle={loginInputStyles.mainButtonText}
          buttonText="Log in"
        />
        <View style={styles.footerTexts}>
          <TouchButton
            doPress={this._navigateToRegister}
            buttonTypeStyle={loginInputStyles.createAccountButton}
            buttonTextStyle={loginInputStyles.createAccount}
            buttonText="Create Account"
          />
          <TouchButton
            doPress={this._navigateToForgotPassword}
            buttonTypeStyle={loginInputStyles.forgotPasswordButton}
            buttonTextStyle={loginInputStyles.forgotPassword}
            buttonText="Forgot Password?"
          />
        </View>
      </View>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <LoginForm {...props} navigation={navigation} />;
};
