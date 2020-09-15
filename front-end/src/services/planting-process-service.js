import {fetchPost, fetchGet} from './base-service';
import AsyncStorage from '@react-native-community/async-storage';

export const plantingProcessModel = {
  treeId: 1, // required
  userId: 1, // required
  startDate: '2020-07-01', // YYYY-MM-DD
  germinationDate: '2020-08-01', // YYYY-MM-DD
  vegetativeDate: '2020-08-01', // YYYY-MM-DD
  floweringDate: '2020-08-01', // YYYY-MM-DD
  harvestDate: '2020-08-01', // YYYY-MM-DD
  plantingSpotId: 1,
};

const insertPlantingProcess = async plantingProcess => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  plantingProcess.userId = userId;
  const insertResult = await fetchPost(
    'api/planting-process/insert',
    plantingProcess,
    true,
  );
  return insertResult.json();
};

export const plantingActionModel = {
  name: '',
  processStepId: 1, // required
  measurementUnit: 'mL',
  description: 'Describe somethings',
  actionTime: '2020-08-23T17:30', // Need only time part (HH:mm)
  amount: 100,
  status: 0,
};

const insertPlantingAction = async plantingAction => {
  return await fetchPost(
    'api/planting-process/planting-action/insert',
    plantingAction,
    true,
  );
};

const getPlantingProcessesByUser = async () => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  return await fetchGet(`api/planting-process/user/${userId}`, true);
};

const getPlantingSpotById = async spotId => {
  const response = await fetchGet(
    `api/planting-process/planting-spot/${spotId}`,
    true,
  );
  return response.json();
};

export {
  insertPlantingProcess,
  insertPlantingAction,
  getPlantingProcessesByUser,
  getPlantingSpotById,
};
