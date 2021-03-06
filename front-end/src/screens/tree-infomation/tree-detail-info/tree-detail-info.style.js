import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';
import CONSTANTS from '../../styles/constant.style';

const styles = StyleSheet.create({
  boxContainer: {
    marginLeft: CONSTANTS.commonDetailMargin,
    marginRight: CONSTANTS.commonDetailMargin,
    marginBottom: CONSTANTS.commonDetailMargin,
    borderWidth: 2,
    borderColor: 'black',
    padding: 5,
    backgroundColor: COLORS.commonBackground,
  },
  titleText: {
    fontWeight: 'bold',
  },
  lineContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  attributeContainer: {
    flexDirection: 'row',
  },
  buttonContainer: {
    height: 59,
    margin: CONSTANTS.commonDetailMargin,
    flexDirection: 'row',
  },
  leftButton: {
    height: 40,
    backgroundColor: '#29c263',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
  leftButtonText: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
  rightButton: {
    height: 40,
    backgroundColor: '#6eb88a',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginLeft: 2,
  },
  rightButtonText: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
});

export default styles;
