import React from 'react';
import {View, TextInput} from 'react-native';
import Icon from 'react-native-vector-icons/EvilIcons';

const InputText = props => {
  return (
    <View style={props.inputStyle}>
      <Icon name={props.iconName} style={props.iconStyle} />
      <TextInput
        placeholder={props.placeholder}
        placeholderTextColor="rgba(255,255,255,1)"
        secureTextEntry={false}
        style={props.textInputStyle}
      />
    </View>
  );
};

export default InputText;
