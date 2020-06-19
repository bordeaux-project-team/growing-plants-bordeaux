import React from 'react';
import {View} from 'react-native';
import styles from './register-form.style';
import InputText from '../common/input-text.component';
import loginInputStyles from '../common/login-common.style';
import Button from '../common/button.component';

const RegisterForm = props => {
  return (
    <View style={styles.form}>
      <InputText
        inputStyle={loginInputStyles.username}
        iconName="user"
        iconStyle={loginInputStyles.usernameIcon}
        placeholder="Sign Up by an Email"
        textInputStyle={loginInputStyles.usernameInput}
      />
      <InputText
        inputStyle={loginInputStyles.password}
        iconName="lock"
        iconStyle={loginInputStyles.passwordIcon}
        placeholder="Your Password"
        textInputStyle={loginInputStyles.passwordInput}
      />
      <InputText
        inputStyle={loginInputStyles.password}
        iconName="lock"
        iconStyle={loginInputStyles.passwordIcon}
        placeholder="Retype Your Password"
        textInputStyle={loginInputStyles.passwordInput}
      />
      <Button
        doPress={props.doLogin}
        buttonTypeStyle={loginInputStyles.mainButton}
        buttonTextStyle={loginInputStyles.mainButtonText}
        buttonText="Sigh Up"
      />
    </View>
  );
};

export default RegisterForm;
