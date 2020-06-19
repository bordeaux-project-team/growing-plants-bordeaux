import {StyleSheet} from 'react-native';
import commonStyles from '../../styles/common.style';

const styles = StyleSheet.create({
  form: commonStyles.loginForm,
  buttonRow: {
    height: 59,
    marginTop: 27,
    flexDirection: 'row',
  },
  sendButton: {
    height: 59,
    backgroundColor: 'rgba(31,178,204,1)',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
  cancelButton: {
    height: 59,
    backgroundColor: 'rgba(230,58,81,1)',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginLeft: 2,
  },
});

export default styles;
