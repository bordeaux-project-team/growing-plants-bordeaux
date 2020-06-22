import {StyleSheet} from 'react-native';

const styles = StyleSheet.create({
  dateComponentView: {
    flex: 1,
    flexDirection: 'column',
    alignItems: 'center',
  },
  dateComponentYearText: {
    color: '#fff',
    fontSize: 20,
  },
  dateComponentDateTouchable: {
    flex: 1,
    flexDirection: 'column',
    color: '#7d7c7b',
    alignItems: 'center',
  },
  dateComponentDateView: {
    flex: 1,
    flexDirection: 'row',
    marginTop: 10,
  },
});

export default styles;
