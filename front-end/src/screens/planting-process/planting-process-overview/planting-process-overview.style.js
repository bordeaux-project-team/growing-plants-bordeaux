import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';
import CONSTANTS from '../../styles/constant.style';

const styles = StyleSheet.create({
  componentContainer: {},
  boxContainer: {
    marginLeft: CONSTANTS.commonDetailMargin,
    marginRight: CONSTANTS.commonDetailMargin,
    marginBottom: CONSTANTS.commonDetailMargin,
    borderWidth: 2,
    borderColor: 'black',
    padding: 5,
    backgroundColor: COLORS.commonBackground,
  },
  canNotAddActionMessage: {
    textAlign: 'center',
  },
  addActionContainer: {
    marginTop: CONSTANTS.commonDetailMargin,
  },
  addActionButton: {
    height: 40,
    backgroundColor: '#93e058',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
  addActionButtonText: {
    color: COLORS.commonBorder,
    alignSelf: 'center',
  },
  listItem: {
    backgroundColor: COLORS.commonBackground,
  },
  actionName: {
    color: 'green',
    fontWeight: 'bold',
  },
  actionDetail: {
    fontSize: 12,
  },
  attributeContainer: {
    flexDirection: 'row',
  },
  gardenButtonContainer: {
    height: 59,
    margin: CONSTANTS.commonDetailMargin,
    flexDirection: 'row',
  },
  gardenButton: {
    height: 40,
    backgroundColor: '#29c263',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
  gardenButtonText: {
    color: 'rgba(255,255,255,1)',
    alignSelf: 'center',
  },
});

export default styles;
