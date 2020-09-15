import {StyleSheet} from 'react-native';
import CONSTANTS from '../../styles/constant.style';

const styles = StyleSheet.create({
  item: {
    flex: 1,
    height: 35,
    margin: 5,
    backgroundColor: '#bab419',
  },
  grownItem: {
    flex: 1,
    height: 35,
    margin: 5,
    backgroundColor: '#e7d3bb',
  },
  itemText: {
    textAlign: 'center',
  },
  gridContainer: {
    height: '70%',
  },
  list: {
    flex: 1,
    margin: 25,
  },
  emptyCount: {
    backgroundColor: '#035e7b',
    width: '100%',
    padding: 12,
    paddingLeft: CONSTANTS.commonMainMargin,
  },
  emptyText: {
    color: 'white',
  },
  treeInfo: {
    width: '100%',
  },
  container: {
    backgroundColor: '#a5f3dd',
  },
  avatarItem: {
    margin: 20,
    textAlign: 'center',
  },
  treeName: {
    fontWeight: 'bold',
  },
});

export default styles;
