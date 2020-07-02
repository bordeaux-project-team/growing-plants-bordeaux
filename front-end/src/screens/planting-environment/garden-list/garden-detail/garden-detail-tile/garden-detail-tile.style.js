import {StyleSheet} from 'react-native';
import COLORS from '../../../../styles/color.style';

const styles = StyleSheet.create({
  tileContainer: {
    borderWidth: 5,
    borderColor: COLORS.borderGrey,
    marginBottom: 1,
  },
  listItem: {
    backgroundColor: COLORS.backgroundGrey,
  },
  gardenName: {
    color: 'green',
    fontWeight: 'bold',
  },
  gardenDetail: {
    fontSize: 12,
  },
});

export default styles;
