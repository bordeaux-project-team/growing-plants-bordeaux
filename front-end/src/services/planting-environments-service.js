import {fetchPost, fetchGet, fetchPut, fetchDelete} from './base-service';
import AsyncStorage from '@react-native-community/async-storage';

export const plantingEnvironmentModel = {
  name: '',
  width: 5,
  length: 10,
  country: 'Vietnam',
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

const updatePlantingEnvironment = async (
  plantingEnvironmentId,
  plantingEnvironment,
) => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId || !plantingEnvironmentId) {
    return null;
  }
  plantingEnvironment.userId = userId;
  return await fetchPut(
    `api/planting-environment/${plantingEnvironmentId}/update`,
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

const getPlantingSpotsByPlantingEnvironmentId = async envId => {
  const plantingSpots = await fetchPut(
    `api/planting-environment/${envId}/planting-spot`,
    true,
  );
  return plantingSpots.json();
};

const getPlantingEnvironmentByUser = async () => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  const plantingEnvironment = await fetchGet(
    `api/planting-environment/user/${userId}`,
    true,
  );
  return plantingEnvironment.json();
};

const deletePlantingEnvironment = async envId => {
  return await fetchDelete(`api/planting-environment/${envId}`, true);
};

export {
  insertPlantingEnvironment,
  updatePlantingEnvironment,
  getPlantingEnvironmentByUser,
  deletePlantingEnvironment,
  getPlantingSpotsByPlantingEnvironmentId,
  insertPlantingSpot,
};
