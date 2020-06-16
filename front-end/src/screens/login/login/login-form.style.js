import {StyleSheet} from 'react-native';
import commonStyles from '../../styles/common.style';

const styles = StyleSheet.create({
  form: {
    height: 230,
    marginTop: 108,
  },
  loginButton: {
    height: 59,
    backgroundColor: 'rgba(31,178,204,1)',
    borderRadius: 5,
    justifyContent: 'center',
    marginTop: 27,
  },
  loginButtonText: commonStyles.whiteCenterText,
  footerTexts: {
    height: 14,
    flexDirection: 'row',
    marginTop: 27,
    marginBottom: 36,
    marginLeft: 37,
    marginRight: 36,
  },
});

export default styles;
