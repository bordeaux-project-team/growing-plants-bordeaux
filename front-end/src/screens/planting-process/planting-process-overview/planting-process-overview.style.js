import {StyleSheet} from 'react-native';
import COLORS from '../../styles/color.style';

const styles = StyleSheet.create({
  componentContainer: {},
  boxContainer: {
    marginLeft: 15,
    marginRight: 15,
    marginBottom: 15,
    borderWidth: 2,
    borderColor: 'black',
    padding: 5,
    backgroundColor: COLORS.commonBackground,
  },
  addActionContainer: {
    marginTop: 15,
  },
  addActionButton: {
    height: 40,
    backgroundColor: '#29c263',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
  addActionButtonText: {
    color: 'rgba(255,255,255,1)',
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
});

export default styles;
