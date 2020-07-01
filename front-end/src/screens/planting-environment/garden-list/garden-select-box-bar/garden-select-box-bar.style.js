import {StyleSheet} from 'react-native';
import COLORS from '../../../styles/color.style';

const styles = StyleSheet.create({
  conditionContainer: {
    flexDirection: 'row',
  },
  selectBoxContainer: {
    marginTop: 15,
    borderWidth: 5,
    borderColor: COLORS.borderGrey,
  },
  selectBoxStyle: {
    height: 40,
    width: 100,
    backgroundColor: COLORS.backgroundGrey,
    color: COLORS.textGrey,
  },
});

export default styles;
