import {StyleSheet} from 'react-native';
import commonStyles from '../../styles/common.style';
import CONSTANTS from '../../styles/constant.style';

const styles = StyleSheet.create({
  form: commonStyles.loginForm,
  footerTexts: {
    marginTop: CONSTANTS.commonDetailMargin,
    flexDirection: 'row',
  },
});

export default styles;
