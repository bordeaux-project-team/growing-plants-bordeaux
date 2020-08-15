import React from 'react';
import {View} from 'react-native';
import ScrollPicker from 'react-native-wheel-scroll-picker';
import COLORS from '../styles/color.style';

const ScrollSelectBox = props => {
  return (
    <View style={props.containerStyle}>
      <ScrollPicker
        dataSource={props.dataSource}
        selectedIndex={1}
        renderItem={(data, index, isSelected) => {
          props.renderItem(data, index, isSelected);
        }}
        onValueChange={(data, selectedIndex) => {
          props.onValueChange(data, selectedIndex);
        }}
        wrapperHeight={180}
        wrapperWidth={150}
        wrapperBackground={COLORS.commonBackground}
        itemHeight={60}
        highlightColor={'#d8d8d8'}
        highlightBorderWidth={2}
        activeItemColor={'#222121'}
        itemColor={'#B4B4B4'}
      />
    </View>
  );
};

export default ScrollSelectBox;
