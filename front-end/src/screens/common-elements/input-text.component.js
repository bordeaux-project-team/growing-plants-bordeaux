import React from 'react';
import {View, TextInput} from 'react-native';
import Icon from 'react-native-vector-icons/EvilIcons';

const InputText = props => {
  return (
    <View style={props.inputStyle}>
      <Icon name={props.iconName} style={props.iconStyle} />
      <TextInput
        onChangeText={props.onChangeText}
        value={props.value}
        placeholder={props.placeholder}
        placeholderTextColor="#77C67E"
        secureTextEntry={false}
        style={props.textInputStyle}
      />
    </View>
  );
};

export default InputText;
