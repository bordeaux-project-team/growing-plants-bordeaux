import {StyleSheet} from 'react-native';

export const styles = StyleSheet.create({
  root: {
    flex: 1,
    backgroundColor: 'rgb(255,255,255)',
  },
  background: {
    flex: 1
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
    marginTop: 100,
  },
  username: {
    height: 59,
    backgroundColor: 'rgba(251,247,247,0.25)',
    opacity: 1,
    borderRadius: 5,
    flexDirection: 'row',
  },
  emailIcon: {
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
  lockIcon: {
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
  loginButton: {
    height: 59,
    backgroundColor: 'rgba(31,178,204,1)',
    borderRadius: 5,
    justifyContent: 'center',
  },
  loginText: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
  plantingWithHntaColumn: {
    marginTop: 100,
    marginLeft: 41,
    marginRight: 41,
  },
  plantingWithHntaColumnFiller: {
    flex: 0.25,
  },
  accountActions: {
    flexDirection: 'row',
    flex: 0.125,
    justifyContent: 'space-between',
    marginLeft: 41,
    marginRight: 41,
  },
  signUpButton: {
  },
  createAccountText: {
    color: 'white',
  },
  forgetPasswordButton: {
  },
  forgetPasswordText: {
    color: 'white',
  },
});
