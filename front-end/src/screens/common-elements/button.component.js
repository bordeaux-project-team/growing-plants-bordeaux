import React from 'react';
import {Text, TouchableOpacity} from 'react-native';

const TouchButton = props => {
  return (
    <TouchableOpacity onPress={props.doPress} style={props.buttonTypeStyle}>
      <Text style={props.buttonTextStyle}>{props.buttonText}</Text>
    </TouchableOpacity>
  );
};

export default TouchButton;
