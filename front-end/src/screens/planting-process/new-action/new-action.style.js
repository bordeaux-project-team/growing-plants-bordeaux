import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';

const styles = StyleSheet.create({
  componentContainer: {},
  selectBoxContainer: {
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
    marginLeft: 15,
    marginRight: 15,
  },
  selectBoxStyle: {
    height: 40,
    backgroundColor: COLORS.commonBackground,
    color: COLORS.commonText,
  },
  inputDateContainer: {
    margin: 15,
    backgroundColor: COLORS.commonBorder,
  },
  changeStartDateButtonText: {
    fontWeight: 'bold',
    width: '100%',
  },
  descriptionInput: {
    marginLeft: 15,
    marginRight: 15,
    marginBottom: 15,
    borderWidth: 5,
    borderColor: COLORS.commonBackground,
    backgroundColor: COLORS.commonBorder,
    height: 50,
  },
  descriptionInputText: {
    color: COLORS.commonText,
    marginRight: 11,
    marginLeft: 11,
    marginTop: -22,
  },
  boxContainer: {
    marginRight: 15,
    marginLeft: 15,
    marginBottom: 15,
    borderWidth: 2,
    borderColor: 'black',
    padding: 5,
    backgroundColor: COLORS.commonBackground,
  },
  boxTitle: {
    color: 'green',
    fontSize: 16,
  },
  amountOptions: {
    flexDirection: 'row',
    marginRight: 15,
    marginLeft: 15,
  },
  amountNumber: {
    flexDirection: 'row',
  },
  amountNumberText: {
    alignSelf: 'center',
  },
  selectAmountOptionsBoxContainer: {
    width: '100%',
  },
  selectAmountOptionsBoxStyle: {
    color: 'red',
  },
  attributeContainer: {
    flexDirection: 'row',
    marginBottom: 5,
  },
  notificationContainer: {
    marginTop: 15,
    marginLeft: 15,
    marginRight: 15,
    marginBottom: 10,
  },
  buttonContainer: {
    height: 59,
    margin: 15,
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
