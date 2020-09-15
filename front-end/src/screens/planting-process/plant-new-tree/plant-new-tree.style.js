import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';
import CONSTANTS from '../../styles/constant.style';

const styles = StyleSheet.create({
  componentContainer: {},
  numberOfTreeInput: {
    marginLeft: CONSTANTS.commonDetailMargin,
    marginRight: CONSTANTS.commonDetailMargin,
    marginBottom: CONSTANTS.commonDetailMargin,
    borderWidth: 5,
    borderColor: COLORS.commonBackground,
    backgroundColor: COLORS.commonBorder,
  },
  numberOfTreeTextInput: {
    color: COLORS.commonText,
    marginRight: 11,
    marginLeft: 11,
    marginTop: -CONSTANTS.commonDetailMargin,
  },
  boxContainer: {
    marginLeft: CONSTANTS.commonDetailMargin,
    marginRight: CONSTANTS.commonDetailMargin,
    marginBottom: CONSTANTS.commonDetailMargin,
    borderWidth: 2,
    borderColor: 'black',
    padding: 5,
    backgroundColor: COLORS.commonBackground,
  },
  timeline: {
    textAlign: 'center',
    backgroundColor: '#F08080',
    color: 'white',
    padding: 5,
    borderRadius: 13,
  },
  optionTimeline: {
    paddingTop: 10,
    paddingLeft: 10,
  },
  changeStartDateButton: {
    flex: 1,
    alignItems: 'flex-end',
    justifyContent: 'flex-end',
    padding: 16,
  },
  changeStartDateButtonText: {
    backgroundColor: COLORS.commonBorder,
    fontWeight: 'bold',
    textAlign: 'right',
    width: 200,
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
