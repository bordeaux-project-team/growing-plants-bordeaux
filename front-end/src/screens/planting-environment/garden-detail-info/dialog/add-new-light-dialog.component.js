import React from 'react';
import {View} from 'react-native';
import styles from './add-new-light-dialog.style';
import loginInputStyles from '../../../common-elements/login-common.style';
import InputText from '../../../common-elements/input-text.component';
import TouchButton from '../../../common-elements/button.component';
import SelectBox from '../../../common-elements/select-box.component';

const AddNewLightDialog = props => {
  return (
    <View style={styles.form}>
      <SelectBox
        containerStyle={styles.selectBoxContainer}
        selectBoxStyle={styles.selectBoxStyle}
        items={props.lightTypeItems}
        onValueChange={props.setSelectedLightTypeItemsState}
        selectedValue={props.selectedLightTypeItems}
      />
      <InputText
        onChangeText={wattage => props.setWattageState(wattage)}
        inputStyle={styles.inputText}
        placeholder="Wattage"
        textInputStyle={loginInputStyles.usernameInput}
      />
      <InputText
        onChangeText={colorTemperature =>
          props.setColorTemperatureState(colorTemperature)
        }
        inputStyle={styles.inputText}
        placeholder="Color Temperature (Kelvins)"
        textInputStyle={loginInputStyles.usernameInput}
      />
      <View style={styles.buttonRow}>
        <TouchButton
          doPress={props.doNewLightAdd}
          buttonTypeStyle={styles.addButton}
          buttonTextStyle={loginInputStyles.mainButtonText}
          buttonText={props.lightText}
        />
      </View>
    </View>
  );
};

export default AddNewLightDialog;
