import React from 'react';
import {
  View,
  StatusBar,
  ImageBackground,
  Text,
  TextInput,
  TouchableOpacity,
} from 'react-native';
import Icon from 'react-native-vector-icons/EvilIcons';
import {styles} from './style';
import {useNavigation} from '@react-navigation/native';
const Login = props => {
  const navigation = useNavigation();
  return (
    <View style={styles.root}>
      <StatusBar barStyle="light-content" backgroundColor="rgba(0,0,0,0)" />
      <View style={styles.background}>
        <ImageBackground
          style={styles.rect}
          imageStyle={styles.rect_imageStyle}
          source={require('../../assets/images/Gradient_Jr82Lj4.png')}>
          <View style={styles.plantingWithHntaColumn}>
            <Text style={styles.plantingWithHnta}>PLANTING WITH HNTA</Text>
            <View style={styles.form}>
              <View style={styles.usernameColumn}>
                <View style={styles.username}>
                  <Icon name="user" style={styles.emailIcon} />
                  <TextInput
                    placeholder="Email address"
                    placeholderTextColor="rgba(255,255,255,1)"
                    style={styles.usernameInput}
                  />
                </View>
                <View style={styles.password}>
                  <Icon name="lock" style={styles.lockIcon} />
                  <TextInput
                    placeholder="Password"
                    placeholderTextColor="rgba(255,255,255,1)"
                    secureTextEntry={true}
                    style={styles.passwordInput}
                  />
                </View>
              </View>
              <View style={styles.usernameColumnFiller} />
              <TouchableOpacity
                onPress={props.doLogin}
                style={styles.loginButton}>
                <Text style={styles.loginText}>Log in</Text>
              </TouchableOpacity>
            </View>
          </View>
          <View style={styles.plantingWithHntaColumnFiller} />
          <View style={styles.accountActions}>
            <TouchableOpacity
              onPress={() => navigation.navigate('SignUp')}
              style={styles.signUpButton}>
              <Text style={styles.createAccountText}>Create Account</Text>
            </TouchableOpacity>
            <TouchableOpacity
              onPress={() => navigation.navigate('SignUp')}
              style={styles.forgetPasswordButton}>
              <Text style={styles.forgetPasswordText}>Forget Password?</Text>
            </TouchableOpacity>
          </View>
        </ImageBackground>
      </View>
    </View>
  );
};

export default Login;
