import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';

const styles = StyleSheet.create({
  dateComponentView: {
    alignItems: 'center',
    backgroundColor: COLORS.commonBackground,
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
  },
  dateComponentYearText: {
    color: 'black',
    fontSize: 20,
  },
  dateComponentDateTouchable: {
    flex: 1,
    flexDirection: 'column',
    color: 'black',
    alignItems: 'center',
  },
  dateComponentDateView: {
    flexDirection: 'row',
    marginTop: 10,
    color: 'black',
  },
});

export default styles;
