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
};

const insertPlantingProcess = async plantingProcess => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  plantingProcess.userId = userId;
  return await fetchPost('api/planting-process/insert', plantingProcess, true);
};

export const plantingActionModel = {
  processStepId: 1, // required
  measurementUnitId: null,
  description: 'Fuck IEI and Bộc đô',
  actionTime: '2020-08-23T17:30', // Need only time part (HH:mm)
  amount: 100,
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

export {
  insertPlantingProcess,
  insertPlantingAction,
  getPlantingProcessesByUser,
};
