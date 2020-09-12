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
  },
  listItem: {
    backgroundColor: COLORS.commonBackground,
  },
  treeName: {
    color: 'green',
    fontWeight: 'bold',
    textAlign: 'center',
  },
  treeDetail: {
    fontSize: 12,
  },
});

export default styles;
