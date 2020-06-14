import React, {useState} from 'react';
import {
  View,
  TextInput,
  TouchableOpacity,
  Text,
  ImageBackground,
  KeyboardAvoidingView,
} from 'react-native';
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
    <KeyboardAvoidingView style={styles.root}>
      <ImageBackground
        style={styles.rect}
        imageStyle={styles.rect_imageStyle}
        source={require('../../assets/images/Gradient_Jr82Lj4.png')}>
        <TextInput
          placeholder="First name"
          placeholderTextColor="white"
          style={styles.inputText}
        />
        <TextInput
          placeholder="Last name"
          placeholderTextColor="white"
          style={styles.inputText}
        />
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
          items={[
            {label: 'Male', value: true},
            {label: 'Female', value: false},
          ]}
          containerStyle={{height: 40}}
          onChangeItem={item => console.log(item.label, item.value)}
        />
        <TextInput
          placeholder="Email"
          placeholderTextColor="white"
          style={styles.inputText}
        />
        <TextInput
          placeholder="Password"
          placeholderTextColor="white"
          style={styles.inputText}
          secureTextEntry={true}
        />
        <TextInput
          placeholder="Confirm password"
          placeholderTextColor="white"
          style={styles.inputText}
          secureTextEntry={true}
        />
        <DropDownPicker
          placeholder="Country"
          items={[
            {label: 'Vietnam', value: 'Vietnam'},
            {label: 'United States', value: 'United States'},
            {label: 'Canada', value: 'Canada'},
          ]}
          containerStyle={{height: 40}}
          onChangeItem={item => console.log(item.label, item.value)}
        />
      </ImageBackground>
    </KeyboardAvoidingView>
  );
};

export default SignUp;
