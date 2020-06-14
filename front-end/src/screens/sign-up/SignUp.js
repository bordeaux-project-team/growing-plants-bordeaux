import React, {useState} from 'react';
import {View, TextInput, TouchableOpacity, Text} from 'react-native';
import {styles} from './style';
import DateTimePicker from '@react-native-community/datetimepicker';
import DropDownPicker from 'react-native-dropdown-picker';

const SignUp = props => {
  const [dob, setDob] = useState(new Date());
  const [show, setShow] = useState(false);
  const [displayDob, setDisplayDob] = useState('');

  const openDob = () => {
    setShow(true);
  };

  const chooseDob = (event, selectedDate) => {
    setShow(false);
    setDob(selectedDate);
    setDisplayDob(selectedDate.toLocaleDateString());
  };

  return (
    <View>
      <TextInput placeholder="First name" />
      <TextInput placeholder="Last name" />
      <TouchableOpacity onPress={openDob}>
        <Text>Date of Birth {displayDob}</Text>
      </TouchableOpacity>
      {show && (
        <DateTimePicker
          value={new Date()}
          mode={'date'}
          display="default"
          onChange={chooseDob}
        />
      )}
      <DropDownPicker
        placeholder="Gender"
        items={[{label: 'Male', value: true}, {label: 'Female', value: false}]}
        containerStyle={{height: 40}}
        onChangeItem={item => console.log(item.label, item.value)}
      />
      <TextInput placeholder="Email" />
      <TextInput placeholder="Password" />
      <TextInput placeholder="Confirm password" />
    </View>
  );
};

export default SignUp;
