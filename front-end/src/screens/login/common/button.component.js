import React from 'react';
import {View, Text, TouchableOpacity} from 'react-native';

const Button = props => {
  return (
    <TouchableOpacity onPress={props.doPress} style={props.buttonTypeStyle}>
      <Text style={props.buttonTextStyle}>{props.buttonText}</Text>
    </TouchableOpacity>
  );
};

export default Button;
