import React, {Component} from 'react';
import {Alert, View} from 'react-native';
import styles from './register-form.style';
import InputText from '../../common-elements/input-text.component';
import loginInputStyles from '../../common-elements/login-common.style';
import TouchButton from '../../common-elements/button.component';
import {doLogin, registerAccount} from '../../../services/user-service';
import {StackActions, useNavigation} from '@react-navigation/native';

class RegisterForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      password: '',
      rePassword: '',
    };
    this.doCreateAccount = this.doCreateAccount.bind(this);
  }

  setEmailState = email => {
    this.setState({email});
  };

  setPasswordState = password => {
    this.setState({password});
  };

  setRePasswordState = rePassword => {
    this.setState({rePassword});
  };

  async doCreateAccount() {
    const email = this.state.email;
    const password = this.state.password;
    const rePassword = this.state.rePassword;
    const {navigation} = this.props;
    if (password === rePassword) {
      const registerModel = {
        firstName: 'firstName',
        lastName: 'lastName',
        dateOfBirth: '1996-09-30', // YYYY-MM-DD
        gender: true,
        email,
        password,
      };
      const registerResult = await registerAccount(registerModel);
      if (registerResult.result) {
        const loginResult = await doLogin(email, password);
        if (loginResult.result) {
          navigation.dispatch(StackActions.replace('PlantingEnvironment'));
        } else {
          Alert.alert('There was an error!', 'Please try again', [
            {
              text: 'OK',
              onPress: () => console.log('Cancel Pressed'),
              style: 'cancel',
            },
          ]);
        }
      }
    } else {
      Alert.alert('Re-Password is not match!', 'Please type again', [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    }
  }

  render() {
    return (
      <View style={styles.form}>
        <InputText
          onChangeText={email => this.setEmailState(email)}
          inputStyle={loginInputStyles.username}
          iconName="user"
          iconStyle={loginInputStyles.usernameIcon}
          placeholder="Sign Up by an Email"
          textInputStyle={loginInputStyles.usernameInput}
        />
        <InputText
          secureTextEntry={true}
          onChangeText={password => this.setPasswordState(password)}
          inputStyle={loginInputStyles.password}
          iconName="lock"
          iconStyle={loginInputStyles.passwordIcon}
          placeholder="Your Password"
          textInputStyle={loginInputStyles.passwordInput}
        />
        <InputText
          secureTextEntry={true}
          onChangeText={rePassword => this.setRePasswordState(rePassword)}
          inputStyle={loginInputStyles.password}
          iconName="lock"
          iconStyle={loginInputStyles.passwordIcon}
          placeholder="Retype Your Password"
          textInputStyle={loginInputStyles.passwordInput}
        />
        <TouchButton
          doPress={this.doCreateAccount}
          buttonTypeStyle={loginInputStyles.mainButton}
          buttonTextStyle={loginInputStyles.mainButtonText}
          buttonText="Sign Up"
        />
      </View>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <RegisterForm {...props} navigation={navigation} />;
};
