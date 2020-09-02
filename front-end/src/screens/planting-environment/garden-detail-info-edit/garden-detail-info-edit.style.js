import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';
import commonStyles from '../../styles/common.style';

const styles = StyleSheet.create({
  gardenDetailInfoBackground: {
    marginTop: 21,
    marginLeft: 21,
    marginRight: 21,
    flex: 1,
  },
  gardenNameInput: {
    height: 59,
    backgroundColor: COLORS.commonBackground,
    flexDirection: 'row',
    margin: 11,
    borderColor: COLORS.commonBorder,
    borderWidth: 5,
  },
  gardenNameTextInput: {
    color: COLORS.commonText,
    marginRight: 11,
    marginLeft: 11,
  },
  gardenSize: {
    margin: 11,
    flexDirection: 'row',
  },
  widthAndLengthSelectBoxContainer: {
    width: '50%',
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
  },
  noticeText: {
    margin: 11,
    alignSelf: 'center',
  },
  gardenCondition: {
    margin: 11,
  },
  selectBoxContainer: {
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
  },
  selectBoxStyle: {
    height: 40,
    backgroundColor: COLORS.commonBackground,
    color: COLORS.commonText,
  },
  gardenType: {
    flexDirection: 'row',
    alignSelf: 'center',
    margin: 11,
  },
  gardenTypeSwitch: {
    marginLeft: 11,
    marginRight: 11,
  },
  gardenTypeText: {
    fontWeight: 'bold',
    fontSize: 16,
    margin: 4,
  },
  gardenLight: {
    margin: 11,
    borderColor: 'black',
    borderWidth: 1,
  },
  addNewLightButton: {
    height: 40,
    backgroundColor: 'green',
    borderRadius: 5,
    justifyContent: 'center',
    margin: 11,
  },
  addNewLightButtonText: commonStyles.whiteCenterText,
  exposureTime: {},
  exposureTimeText: {
    marginTop: 5,
    marginLeft: 5,
  },
  exposureSelectBoxContainer: {
    borderWidth: 5,
    borderColor: COLORS.commonBorder,
    margin: 11,
  },
  exposureSelectBoxStyle: {
    height: 20,
    backgroundColor: COLORS.commonBackground,
    color: COLORS.commonText,
  },
  sliderStyle: {
    height: 60,
    width: '95%',
    margin: 10,
  },
  buttonContainer: {
    height: 59,
    margin: 10,
    flexDirection: 'row',
  },
  createButton: {
    height: 40,
    backgroundColor: '#29c263',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
  createButtonText: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
  cancelButton: {
    height: 40,
    backgroundColor: '#6eb88a',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginLeft: 2,
  },
  cancelButtonText: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
});

export default styles;
