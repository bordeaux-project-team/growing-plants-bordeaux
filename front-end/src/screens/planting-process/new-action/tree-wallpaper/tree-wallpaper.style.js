import {StyleSheet} from 'react-native';
import COLORS from '../../../styles/color.style';
import CONSTANTS from '../../../styles/constant.style';

const styles = StyleSheet.create({
  container: {
    backgroundColor: COLORS.commonBackground,
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
    margin: CONSTANTS.commonDetailMargin,
  },
  avatarItem: {
    margin: 20,
    textAlign: 'center',
  },
  treeName: {
    fontSize: 30,
    fontWeight: 'bold',
  },
});

export default styles;
