import React, {Component} from 'react';
import {Alert, View} from 'react-native';
import styles from './forgot-password.style';
import loginInputStyles from '../../common-elements/login-common.style';
import InputText from '../../common-elements/input-text.component';
import TouchButton from '../../common-elements/button.component';
import {useNavigation} from '@react-navigation/native';

class ForgotPasswordForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
    };
    this.doCancel = this.doCancel.bind(this);
  }

  setEmailState = email => {
    this.setState({email});
  };

  doSendEmail = () => {
    const email = this.state.email;
    if (email) {
      Alert.alert('Email Sent!', `Sent to ${email}`, [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    } else {
      Alert.alert('Email is empty!', 'Please enter your email address', [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    }
  };

  doCancel = () => {
    const {navigation} = this.props;
    navigation.goBack();
  };

  render() {
    return (
      <View style={styles.form}>
        <InputText
          onChangeText={email => this.setEmailState(email)}
          inputStyle={loginInputStyles.username}
          iconName="user"
          iconStyle={loginInputStyles.usernameIcon}
          placeholder="Type your email to reset password"
          textInputStyle={loginInputStyles.usernameInput}
        />
        <View style={styles.buttonRow}>
          <TouchButton
            doPress={this.doSendEmail}
            buttonTypeStyle={styles.sendButton}
            buttonTextStyle={loginInputStyles.mainButtonText}
            buttonText="Send"
          />
          <TouchButton
            doPress={this.doCancel}
            buttonTypeStyle={styles.cancelButton}
            buttonTextStyle={loginInputStyles.mainButtonText}
            buttonText="Cancel"
          />
        </View>
      </View>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <ForgotPasswordForm {...props} navigation={navigation} />;
};
