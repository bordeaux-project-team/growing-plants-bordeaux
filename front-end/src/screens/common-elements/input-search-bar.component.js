import React from 'react';
import {SearchBar} from 'react-native-elements';

const InputSearchBar = props => {
  return (
    <SearchBar
      lightTheme
      placeholder={props.searchText}
      onChangeText={props.textChange}
      value={props.searchValue}
    />
  );
};

export default InputSearchBar;
