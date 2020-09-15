import {StyleSheet} from 'react-native';
import CONSTANTS from '../../../styles/constant.style';

const styles = StyleSheet.create({
  listContainer: {
    marginTop: CONSTANTS.commonDetailMargin,
  },
  loadMore: {
    textDecorationLine: 'underline',
    fontWeight: 'bold',
  },
  loadBack: {
    textDecorationLine: 'underline',
    fontWeight: 'bold',
  },
});

export default styles;
