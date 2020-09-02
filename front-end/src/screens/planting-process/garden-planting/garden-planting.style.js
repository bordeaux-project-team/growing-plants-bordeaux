import {StyleSheet} from 'react-native';

const styles = StyleSheet.create({
  item: {
    flex: 1,
    height: 35,
    margin: 5,
    backgroundColor: '#9B6300',
  },
  itemText: {
    textAlign: 'center',
  },
  gridContainer: {},
  list: {
    flex: 1,
    margin: 25,
  },
  emptyCount: {
    backgroundColor: '#035e7b',
    height: '8%',
    width: '100%',
    padding: 12,
    paddingLeft: 30,
    position: 'absolute',
    bottom: 150,
  },
  emptyText: {
    color: 'white',
  },
  treeInfo: {
    height: 150,
    width: '100%',
    position: 'absolute',
    bottom: 0,
  },
});

export default styles;
