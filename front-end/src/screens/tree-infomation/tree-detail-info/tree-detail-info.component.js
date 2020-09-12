import React, {Component} from 'react';
import {SafeAreaView, ScrollView, Text, View} from 'react-native';
import styles from './tree-detail-info.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import TreeDetailPicture from './tree-detail-picture/tree-detail-picture.component';
import {Icon} from 'react-native-elements';
import TouchButton from '../../common-elements/button.component';
import {useNavigation} from '@react-navigation/native';

class TreeDetailInfo extends Component {
  constructor(props) {
    super(props);
    const treeInfo = props.route ? props.route.params.treeInfo : {};
    this.state = {
      treeInfo,
    };
  }

  _doPlant = () => {
    const {navigation} = this.props;
    const {treeInfo} = this.state;
    navigation.navigate('PlantNewTree', {
      treeInfo,
    });
  };

  _doBack = () => {
    const {navigation} = this.props;
    navigation.goBack();
  };

  render() {
    const {treeInfo} = this.state;
    return (
      <BackgroundScreen>
        <SafeAreaView style={styles.detailContainer}>
          <ScrollView>
            <TreeDetailPicture treeInfo={treeInfo} />
            <View style={styles.boxContainer}>
              <Text style={styles.titleText}>Planting Guide</Text>
              <View style={styles.lineContainer}>
                <View style={styles.attributeContainer}>
                  <Icon color="#c68020" type="fontisto" name="rain" />
                  <Text> Water Level: {treeInfo.waterLevel}</Text>
                </View>
                <View style={styles.attributeContainer}>
                  <Text>Humidity: {treeInfo.humidity} </Text>
                  <Icon color="#c68020" type="fontisto" name="fog" />
                </View>
              </View>
              <View style={styles.lineContainer}>
                <View style={styles.attributeContainer}>
                  <Icon color="#c68020" type="fontisto" name="day-sunny" />
                  <Text> Light: {treeInfo.light}</Text>
                </View>
                <View style={styles.attributeContainer}>
                  <Text>Plant Type: {treeInfo.plantType} </Text>
                  <Icon color="#c68020" type="fontisto" name="rain" />
                </View>
              </View>
              <View style={styles.lineContainer}>
                <View style={styles.attributeContainer}>
                  <Icon color="#c68020" type="fontisto" name="thermometer" />
                  <Text> Temperature: {treeInfo.temperature}</Text>
                </View>
                <View style={styles.attributeContainer}>
                  <Text>Env. Type: {treeInfo.environmentType} </Text>
                  <Icon color="#c68020" type="fontisto" name="rainbow" />
                </View>
              </View>
              <Text>{treeInfo.plantingGuide}</Text>
              <View style={styles.attributeContainer}>
                <Icon type="fontisto" name="lightbulb" />
                <Text> Exposure Time: {treeInfo.exposureTime} hours</Text>
              </View>
              <View style={styles.attributeContainer}>
                <Icon type="fontisto" name="clock" />
                <Text> Germination Time: {treeInfo.germinationTime} days</Text>
              </View>
              <View style={styles.attributeContainer}>
                <Icon type="fontisto" name="clock" />
                <Text> Vegetative Time: {treeInfo.vegetativeTime} days</Text>
              </View>
              <View style={styles.attributeContainer}>
                <Icon type="fontisto" name="clock" />
                <Text> Flowering Time: {treeInfo.floweringTime} days</Text>
              </View>
              <View style={styles.attributeContainer}>
                <Icon type="fontisto" name="clock" />
                <Text> Harvest Time: {treeInfo.harvestTime} days</Text>
              </View>
            </View>

            <View style={styles.boxContainer}>
              <Text style={styles.titleText}>Plant's detail information</Text>
              <Text>{treeInfo.description}</Text>
            </View>

            <View style={styles.boxContainer}>
              <Text style={styles.titleText}>Where to plant</Text>
              <Text>Comparison with: {treeInfo.comparisonWith}</Text>
              <Text>Comparison against: {treeInfo.comparisonAgainst}</Text>
            </View>

            <View style={styles.buttonContainer}>
              <TouchButton
                doPress={this._doPlant}
                buttonTypeStyle={styles.leftButton}
                buttonTextStyle={styles.leftButtonText}
                buttonText="Plant"
              />
              <TouchButton
                doPress={this._doBack}
                buttonTypeStyle={styles.rightButton}
                buttonTextStyle={styles.rightButtonText}
                buttonText="Back"
              />
            </View>
          </ScrollView>
        </SafeAreaView>
      </BackgroundScreen>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <TreeDetailInfo {...props} navigation={navigation} />;
};
