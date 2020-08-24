import {fetchPost, fetchGet} from './base-service';
import AsyncStorage from '@react-native-community/async-storage';

export const plantingEnvironmentModel = {
  name: '',
  width: 5,
  length: 10,
  country: 'Việt Nam',
  light: '50',
  temperature: '30 degree',
  humidity: '7',
  exposureTime: 5,
  environmentType: 'Outdoor',
  userId: 1, // required
};

const insertPlantingEnvironment = async plantingEnvironment => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  plantingEnvironment.userId = userId;
  return await fetchPost(
    'api/planting-environment/insert',
    plantingEnvironment,
    true,
  );
};

export const plantingSpotModel = {
  treeId: null, // required
  position: 20, // a number from 1 -> area = width * length of environment
  amount: 20,
  plantingEnvironmentId: null, // required
};

const insertPlantingSpot = async (envId, plantingSpot) => {
  plantingSpot.plantingEnvironmentId = envId;
  return await fetchPost(
    `api/planting-environment/${envId}/planting-spot/insert-update`,
    [plantingSpot],
    true,
  );
};

const getPlantingEnvironmentByUser = async () => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  return await fetchGet(`api/planting-environment/user/${userId}`, true);
};

export {
  insertPlantingEnvironment,
  getPlantingEnvironmentByUser,
  insertPlantingSpot,
};
