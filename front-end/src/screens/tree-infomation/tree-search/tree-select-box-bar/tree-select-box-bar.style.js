import {StyleSheet} from 'react-native';
import COLORS from '../../../styles/color.style';
import CONSTANTS from '../../../styles/constant.style';

const styles = StyleSheet.create({
  conditionContainer: {},
  selectBoxContainer: {
    marginTop: CONSTANTS.commonDetailMargin,
    marginBottom: CONSTANTS.commonDetailMargin,
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
  },
  selectBoxStyle: {
    height: 40,
    backgroundColor: COLORS.commonBackground,
    color: COLORS.commonText,
  },
});

export default styles;
