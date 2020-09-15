import {StyleSheet} from 'react-native';
import CONSTANTS from '../../styles/constant.style';

const styles = StyleSheet.create({
  gardenListBackground: {
    flex: 1,
    margin: CONSTANTS.commonMainMargin,
  },
  gardenTitle: {
    fontSize: 30,
    fontWeight: 'bold',
    textAlign: 'center',
    color: 'white',
  },
  logOutButtonContainer: {
    marginTop: 15,
  },
  logOutButton: {
    backgroundColor: '#1E6738',
  },
});

export default styles;
