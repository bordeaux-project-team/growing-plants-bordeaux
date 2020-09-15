import {StyleSheet} from 'react-native';
import COLORS from '../../../styles/color.style';
import CONSTANTS from '../../../styles/constant.style';

const styles = StyleSheet.create({
  conditionContainer: {
    flexDirection: 'row',
  },
  selectBoxContainer: {
    marginTop: CONSTANTS.commonDetailMargin,
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
  },
  selectBoxStyle: {
    height: 40,
    width: 100,
    backgroundColor: COLORS.commonBackground,
    color: COLORS.commonText,
  },
});

export default styles;
