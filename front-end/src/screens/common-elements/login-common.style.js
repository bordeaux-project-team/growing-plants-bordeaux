import {StyleSheet} from 'react-native';
import commonStyles from '../styles/common.style';

const styles = StyleSheet.create({
  username: {
    height: 59,
    backgroundColor: 'rgba(251,247,247,0.25)',
    opacity: 1,
    borderRadius: 5,
    flexDirection: 'row',
  },
  usernameIcon: {
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
  passwordIcon: {
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
  createAccountButton: {
    width: 104,
    height: 14,
    alignSelf: 'flex-end',
  },
  createAccount: {
    color: 'rgba(255,255,255,1)',
  },
  forgotPasswordButton: {
    flex: 1,
  },
  forgotPassword: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'flex-end',
  },
  mainButton: {
    height: 59,
    backgroundColor: 'rgba(31,178,204,1)',
    borderRadius: 5,
    justifyContent: 'center',
    marginTop: 27,
  },
  mainButtonText: commonStyles.whiteCenterText,
});

export default styles;
