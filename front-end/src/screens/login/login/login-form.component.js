import React from 'react';
import {View, Text, TouchableOpacity} from 'react-native';
import styles from './login-form.style';
import loginInputStyles from '../common/login-common.style';
import InputText from '../common/input-text.component';
import Button from '../common/button.component';

const LoginForm = props => {
  return (
    <View style={styles.form}>
      <InputText
        inputStyle={loginInputStyles.username}
        iconName="user"
        iconStyle={loginInputStyles.usernameIcon}
        placeholder="Email"
        textInputStyle={loginInputStyles.usernameInput}
      />
      <InputText
        inputStyle={loginInputStyles.password}
        iconName="lock"
        iconStyle={loginInputStyles.passwordIcon}
        placeholder="Password"
        textInputStyle={loginInputStyles.passwordInput}
      />
      <Button
        doPress={props.doLogin}
        buttonTypeStyle={loginInputStyles.mainButton}
        buttonTextStyle={loginInputStyles.mainButtonText}
        buttonText="Log in"
      />
      <View style={styles.footerTexts}>
        <Button
          doPress={props.doLogin}
          buttonTypeStyle={loginInputStyles.createAccountButton}
          buttonTextStyle={loginInputStyles.createAccount}
          buttonText="Create Account"
        />
        <Button
          doPress={props.doLogin}
          buttonTypeStyle={loginInputStyles.forgotPasswordButton}
          buttonTextStyle={loginInputStyles.forgotPassword}
          buttonText="Forgot Password?"
        />
      </View>
    </View>
  );
};

export default LoginForm;
