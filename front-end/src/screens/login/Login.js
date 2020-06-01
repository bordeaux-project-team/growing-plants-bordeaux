import React from 'react';
import {
  StyleSheet,
  View,
  StatusBar,
  ImageBackground,
  Text,
  TextInput,
  TouchableOpacity,
} from 'react-native';
import Icon from 'react-native-vector-icons/EvilIcons';

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
                    placeholder="Username"
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

const styles = StyleSheet.create({
  root: {
    flex: 1,
    backgroundColor: 'rgb(255,255,255)',
  },
  background: {
    flex: 1,
  },
  rect: {
    flex: 1,
  },
  rect_imageStyle: {},
  plantingWithHnta: {
    fontFamily: 'roboto-regular',
    color: 'rgba(255,255,255,1)',
    fontSize: 24,
    textAlign: 'center',
    marginLeft: 8,
  },
  form: {
    height: 230,
    marginTop: 108,
  },
  username: {
    height: 59,
    backgroundColor: 'rgba(251,247,247,0.25)',
    opacity: 1,
    borderRadius: 5,
    flexDirection: 'row',
  },
  icon22: {
    color: 'rgba(255,255,255,1)',
    fontSize: 30,
    marginLeft: 20,
    alignSelf: 'center',
  },
  usernameInput: {
    color: 'rgba(255,255,255,1)',
    flex: 1,
    marginRight: 11,
    marginLeft: 11,
  },
  password: {
    height: 59,
    backgroundColor: 'rgba(253,251,251,0.25)',
    opacity: 1,
    borderRadius: 5,
    flexDirection: 'row',
    marginTop: 27,
  },
  icon2: {
    color: 'rgba(255,255,255,1)',
    fontSize: 33,
    marginLeft: 20,
    alignSelf: 'center',
  },
  passwordInput: {
    color: 'rgba(255,255,255,1)',
    flex: 1,
    marginRight: 17,
    marginLeft: 8,
  },
  usernameColumn: {},
  usernameColumnFiller: {
    flex: 1,
  },
  button: {
    height: 59,
    backgroundColor: 'rgba(31,178,204,1)',
    borderRadius: 5,
    justifyContent: 'center',
  },
  text2: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
  plantingWithHntaColumn: {
    marginTop: 164,
    marginLeft: 41,
    marginRight: 41,
  },
  plantingWithHntaColumnFiller: {
    flex: 1,
  },
  footerTexts: {
    height: 14,
    flexDirection: 'row',
    marginBottom: 36,
    marginLeft: 37,
    marginRight: 36,
  },
  button2: {
    width: 104,
    height: 14,
    alignSelf: 'flex-end',
  },
  createAccountFiller: {
    flex: 1,
  },
  createAccount: {
    color: 'rgba(255,255,255,0.5)',
  },
  button2Filler: {
    flex: 1,
    flexDirection: 'row',
  },
  needHelp: {
    color: 'rgba(255,255,255,0.5)',
    alignSelf: 'flex-end',
    marginRight: -1,
  },
});

export default Login;
