import {StyleSheet} from 'react-native';
import COLORS from '../../../styles/color.style';

const styles = StyleSheet.create({
  form: {
    marginLeft: 40,
    marginRight: 40,
    marginBottom: 40,
  },
  selectBoxContainer: {
    borderColor: COLORS.commonBorder,
  },
  selectBoxStyle: {
    height: 40,
    backgroundColor: COLORS.commonBorder,
    color: COLORS.commonText,
  },
  inputText: {
    marginTop: 11,
    height: 40,
    backgroundColor: COLORS.commonBorder,
    opacity: 1,
    borderRadius: 5,
    flexDirection: 'row',
  },
  buttonRow: {
    height: 40,
    marginTop: 27,
    flexDirection: 'row',
  },
  addButton: {
    height: 40,
    backgroundColor: '#29c263',
    borderRadius: 5,
    justifyContent: 'center',
    flex: 1,
    marginRight: 2,
  },
});

export default styles;
