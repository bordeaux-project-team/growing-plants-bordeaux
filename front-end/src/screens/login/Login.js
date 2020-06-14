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
import styles from './style';

const Login = props => {
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
                  <Icon name="user" style={styles.icon22} />
                  <TextInput
                    placeholder="Email"
                    placeholderTextColor="rgba(255,255,255,1)"
                    secureTextEntry={false}
                    style={styles.usernameInput}
                  />
                </View>
                <View style={styles.password}>
                  <Icon name="lock" style={styles.icon2} />
                  <TextInput
                    placeholder="Password"
                    placeholderTextColor="rgba(255,255,255,1)"
                    secureTextEntry={false}
                    style={styles.passwordInput}
                  />
                </View>
              </View>
              <View style={styles.usernameColumnFiller} />
              <TouchableOpacity
                onPress={() => props.navigation.navigate('Channels')}
                style={styles.button}>
                <Text style={styles.text2}>Log in</Text>
              </TouchableOpacity>
            </View>
          </View>
          <View style={styles.plantingWithHntaColumnFiller} />
          <View style={styles.footerTexts}>
            <TouchableOpacity
              onPress={() => props.navigation.navigate('SignUp')}
              style={styles.button2}>
              <View style={styles.createAccountFiller} />
              <Text style={styles.createAccount}>Create Account</Text>
            </TouchableOpacity>
            <View style={styles.button2Filler} />
            <Text style={styles.needHelp}>Forgot Password?</Text>
          </View>
        </ImageBackground>
      </View>
    </View>
  );
};

export default Login;
