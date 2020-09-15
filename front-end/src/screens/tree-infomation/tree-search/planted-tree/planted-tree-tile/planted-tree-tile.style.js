import {StyleSheet} from 'react-native';
import COLORS from '../../../../styles/color.style';

const styles = StyleSheet.create({
  tileContainer: {
    borderWidth: 4,
    borderColor: COLORS.commonBorder,
    marginBottom: 1,
  },
  avatarItem: {
    margin: 20,
    textAlign: 'center',
  },
  listItem: {
    height: 50,
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
