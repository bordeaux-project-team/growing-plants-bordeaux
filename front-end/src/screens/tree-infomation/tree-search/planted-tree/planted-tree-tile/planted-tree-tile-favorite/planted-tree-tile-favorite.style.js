import {Dimensions, StyleSheet} from 'react-native';
const {height} = Dimensions.get('window');

const styles = StyleSheet.create({
  menuContainer: {
    flex: 1,
  },
  optionStyle: {
    marginTop: -height * 0.12,
  },
});

export default styles;
