import {fetchGet, fetchPost} from './base-service';
import AsyncStorage from '@react-native-community/async-storage';

export const searchTreeModel = {
  text: '',
  plantType: '',
  temperature: '',
  waterLevel: null,
  pageNumber: 1,
};

const searchTree = async searchTreeModel => {
  let response = await fetchPost('api/tree/search', searchTreeModel, true);
  return await response.json();
};

const getPlantedTrees = async limitNumberOfShownTrees => {
  const userId = JSON.parse(await AsyncStorage.getItem('user')).id;
  if (!userId) {
    return null;
  }
  let response = await fetchGet(
    `api/tree/user/${userId}/planted-trees/limit/${limitNumberOfShownTrees}`,
    true,
  );
  return await response.json();
};

export {searchTree, getPlantedTrees};
