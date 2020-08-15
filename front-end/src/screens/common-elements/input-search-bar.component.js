import React from 'react';
import {SearchBar} from 'react-native-elements';
import COLORS from '../styles/color.style';

const InputSearchBar = props => {
  return (
    <SearchBar
      containerStyle={{backgroundColor: COLORS.commonBorder}}
      lightTheme
      placeholder={props.searchText}
      onChangeText={props.textChange}
      value={props.searchValue}
    />
  );
};

export default InputSearchBar;
