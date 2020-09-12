import React, {Component} from 'react';
import {SafeAreaView, ScrollView, Text, View} from 'react-native';
import styles from './planting-process-overview.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {useNavigation} from '@react-navigation/native';
import TreeWallpaper from './tree-wallpaper/tree-wallpaper.component';
import CalendarProcess from './calendar-process/calendar-process.component';
import TouchButton from '../../common-elements/button.component';
import {ListItem} from 'react-native-elements';

class PlantingProcessOverview extends Component {
  constructor(props) {
    super(props);
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    this.state = {
      amountOfTree: 0,
    };
  }

  _addAction = () => {
    const {navigation} = this.props;
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    navigation.navigate('NewAction', {
      treeInfo,
    });
  };

  render() {
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const amountOfTree = this.props.route
      ? this.props.route.params.amountOfTree
      : 0;
    return (
      <BackgroundScreen>
        <SafeAreaView style={styles.componentContainer}>
          <ScrollView>
            <TreeWallpaper treeInfo={treeInfo} />

            <View style={styles.boxContainer}>
              <CalendarProcess />
              <View style={styles.addActionContainer}>
                <TouchButton
                  doPress={this._addAction}
                  buttonTypeStyle={styles.addActionButton}
                  buttonTextStyle={styles.addActionButtonText}
                  buttonText="Add New Action"
                />
              </View>
            </View>

            <View style={styles.boxContainer}>
              <Text>Actions for Today</Text>
              <ListItem
                roundAvatar={true}
                containerStyle={styles.listItem}
                leftAvatar={{
                  source: require('../../../assets/images/task-icon.jpg'),
                  size: 'medium',
                }}
                title={'Water'}
                titleStyle={styles.actionName}
                subtitle={
                  <View>
                    <Text style={styles.actionDetail}>Repeat Every 2 days</Text>
                    <Text style={styles.actionDetail}>Amount 50 ml</Text>
                  </View>
                }
              />
              <ListItem
                roundAvatar={true}
                containerStyle={styles.listItem}
                leftAvatar={{
                  source: require('../../../assets/images/task-icon.jpg'),
                  size: 'medium',
                }}
                title={'Water'}
                titleStyle={styles.actionName}
                subtitle={
                  <View>
                    <Text style={styles.actionDetail}>Repeat Every 2 days</Text>
                    <Text style={styles.actionDetail}>Amount 50 ml</Text>
                  </View>
                }
              />
              <ListItem
                roundAvatar={true}
                containerStyle={styles.listItem}
                leftAvatar={{
                  source: require('../../../assets/images/task-icon.jpg'),
                  size: 'medium',
                }}
                title={'Water'}
                titleStyle={styles.actionName}
                subtitle={
                  <View>
                    <Text style={styles.actionDetail}>Repeat Every 2 days</Text>
                    <Text style={styles.actionDetail}>Amount 50 ml</Text>
                  </View>
                }
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
  return <PlantingProcessOverview {...props} navigation={navigation} />;
};
