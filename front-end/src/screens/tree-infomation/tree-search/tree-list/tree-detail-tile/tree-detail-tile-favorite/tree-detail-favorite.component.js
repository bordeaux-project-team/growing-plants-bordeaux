import React from 'react';
import Menu, {
  MenuOption,
  MenuOptions,
  MenuTrigger,
} from 'react-native-popup-menu';
import {Icon} from 'react-native-elements';
import styles from './garden-detail-show-more-menu.style';
import {Alert, View} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import {deletePlantingEnvironment} from '../../../../../../services/planting-environments-service';

const TreeDetailFavorite = props => {
  const navigation = useNavigation();

  const editButton = () => {
    navigation.navigate('GardenDetailInfoEdit', {
      gardenInfo: props.gardenInfo,
    });
  };

  const removeButton = async () => {
    const plantingEnvironmentId = props.gardenInfo.id;
    const deleteResult = await deletePlantingEnvironment(plantingEnvironmentId);
    if (deleteResult.status === 200) {
      navigation.navigate('MainScreen');
    } else {
      Alert.alert('Remove Fail!', 'There is a error', [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    }
  };

  return (
    <View style={styles.menuContainer}>
      <Menu
        opened={props.gardenInfo.isOpen}
        onBackdropPress={() => props.onBackdropPress(props.index)}>
        <MenuTrigger
          onSelect={value => props.onOptionSelect(value, props.index)}>
          <Icon
            onPress={() => props.onTriggerPress(props.index)}
            type="material"
            name="more-vert"
          />
        </MenuTrigger>
        <MenuOptions optionsContainerStyle={styles.optionStyle}>
          <MenuOption onSelect={editButton} text="Edit" />
          <MenuOption onSelect={removeButton} text="Remove" />
        </MenuOptions>
      </Menu>
    </View>
  );
};

export default TreeDetailFavorite;
