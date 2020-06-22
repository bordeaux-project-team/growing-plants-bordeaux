import React from 'react';
import {View} from 'react-native';
import styles from './forgot-password.style';
import loginInputStyles from '../../common/login-common.style';
import InputText from '../../common/input-text.component';
import TouchButton from '../../common/button.component';

const ForgotPasswordForm = props => {
  return (
    <View style={styles.form}>
      <InputText
        inputStyle={loginInputStyles.username}
        iconName="user"
        iconStyle={loginInputStyles.usernameIcon}
        placeholder="Type your email to reset password"
        textInputStyle={loginInputStyles.usernameInput}
      />
      <View style={styles.buttonRow}>
        <TouchButton
          doPress={props.doLogin}
          buttonTypeStyle={styles.sendButton}
          buttonTextStyle={loginInputStyles.mainButtonText}
          buttonText="Send"
        />
        <TouchButton
          doPress={props.doLogin}
          buttonTypeStyle={styles.cancelButton}
          buttonTextStyle={loginInputStyles.mainButtonText}
          buttonText="Cancel"
        />
      </View>
    </View>
  );
};

export default ForgotPasswordForm;
