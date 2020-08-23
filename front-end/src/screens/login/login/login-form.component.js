import React, {Component} from 'react';
import {Alert, View} from 'react-native';
import styles from './login-form.style';
import loginInputStyles from '../../common-elements/login-common.style';
import InputText from '../../common-elements/input-text.component';
import TouchButton from '../../common-elements/button.component';
import {doLogin, registerAccount} from '../../../services/user-service';
import {insertPlantingProcess} from '../../../services/planting-process-service';
import {useNavigation} from '@react-navigation/native';

class LoginForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      password: '',
    };
    this.doLogin = this.doLogin.bind(this);
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
    console.log(email);
    console.log(password);
    const loginResult = await doLogin(email, password);
    if (loginResult.result) {
      console.log('LoginForm > Login success');
      navigation.navigate('MainScreen');
    } else {
      console.log('LoginForm > Login failed');
      Alert.alert('Login Fail!', 'Please check your Email or Password', [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    }
  }

  async doCreateAccount() {
    await doLogin("john.wick@gmail.com", "TheJohnWick!1234");
    const result = await insertPlantingProcess(null);
    console.log(result);
    if (result.status === 401) {
      // navigate to StartScreen
      console.log("Unauthorized");
    } else if (result.status === 200) {
      const actualResult = await result.json();
      console.log(actualResult);
    } else {
      // Other error!
      console.log("Đã có lỗi xảy ra! Xin vui lòng thử lại")
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
          placeholder="Email"
          textInputStyle={loginInputStyles.usernameInput}
        />
        <InputText
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
            doPress={this.doCreateAccount}
            buttonTypeStyle={loginInputStyles.createAccountButton}
            buttonTextStyle={loginInputStyles.createAccount}
            buttonText="Create Account"
          />
          <TouchButton
            doPress={this.props.doLogin}
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
