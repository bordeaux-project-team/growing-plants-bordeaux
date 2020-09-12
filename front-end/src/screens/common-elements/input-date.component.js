import React from 'react';
import {View, StyleSheet} from 'react-native';
//import all the components we are going to use.
import DatePicker from 'react-native-datepicker';
//import DatePicker from the package we installed

const InputDate = props => {
  return (
    <DatePicker
      style={props.style}
      date={props.initialDate} //initial date from state
      mode="date" //The enum of date, datetime and time
      placeholder={props.placeholder}
      format="YYYY-MM-DD"
      minDate={props.minDate}
      maxDate={props.maxDate}
      confirmBtnText={props.confirmButtonText}
      cancelBtnText={props.cancelButtonText}
      customStyles={props.customStyles}
      onDateChange={props.onDateChange}
    />
  );
};

InputDate.defaultProps = {
  customStyles: {
    dateIcon: {
      position: 'absolute',
      left: 0,
      top: 4,
      marginLeft: 0,
    },
    dateInput: {
      width: 200,
      marginLeft: 36,
    },
  },
};

export default InputDate;
