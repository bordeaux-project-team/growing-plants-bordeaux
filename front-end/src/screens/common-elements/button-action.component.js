import React from 'react';
import ActionButton from 'react-native-action-button';

const ButtonAction = props => {
  return (
    <ActionButton buttonColor="rgba(231,76,60,1)" onPress={props.doPress} />
  );
};

export default ButtonAction;
