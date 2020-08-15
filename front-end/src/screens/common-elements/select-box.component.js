import React from 'react';
import {View} from 'react-native';
import {Picker} from '@react-native-community/picker';

const SelectBox = props => {
  return (
    <View style={props.containerStyle}>
      <Picker
        selectedValue={props.selectedValue}
        style={props.selectBoxStyle}
        onValueChange={props.onValueChange}>
        {props.items.map((item, index) => {
          return (
            <Picker.Item key={index} value={item.value} label={item.label} />
          );
        })}
      </Picker>
    </View>
  );
};

export default SelectBox;
