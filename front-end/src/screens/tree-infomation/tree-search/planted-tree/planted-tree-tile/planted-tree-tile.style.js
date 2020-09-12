import {StyleSheet} from 'react-native';
import COLORS from '../../../../styles/color.style';

const styles = StyleSheet.create({
  tileContainer: {
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
    marginBottom: 1,
  },
  avatarItem: {
    margin: 20,
    textAlign: 'center',
  },
  listItem: {
    backgroundColor: COLORS.commonBackground,
  },
  treeName: {
    color: 'green',
    fontWeight: 'bold',
  },
  treeDetail: {
    fontSize: 12,
  },
});

export default styles;
