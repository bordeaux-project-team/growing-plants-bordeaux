import React from 'react';
import Menu, {
  MenuOption,
  MenuOptions,
  MenuTrigger,
} from 'react-native-popup-menu';
import {Icon} from 'react-native-elements';
import styles from './garden-detail-show-more-menu.style';

const GardenDetailShowMoreMenu = props => {
  return (
    <Menu
      opened={props.info.isOpen}
      onBackdropPress={() => props.onBackdropPress(props.index)}>
      <MenuTrigger onSelect={value => props.onOptionSelect(value, props.index)}>
        <Icon
          onPress={() => props.onTriggerPress(props.index)}
          type="material"
          name="more-vert"
        />
      </MenuTrigger>
      <MenuOptions>
        <MenuOption value={1} text="Edit" />
        <MenuOption value={3} disabled={true} text="Remove" />
      </MenuOptions>
    </Menu>
  );
};

export default GardenDetailShowMoreMenu;
