import {fetchPost} from "./base-service";


export const plantingProcessModel = {
  treeId: 1, // required
  userId: 1, // required
  startDate: "2020-07-01", // YYYY-MM-DD
  germinationDate: "2020-08-01", // YYYY-MM-DD
  vegetativeDate: "2020-08-01", // YYYY-MM-DD
  floweringDate: "2020-08-01", // YYYY-MM-DD
  harvestDate: "2020-08-01", // YYYY-MM-DD
}

const insertPlantingProcess = async (plantingProcess) => {
  return await fetchPost(`api/planting-process/insert`, plantingProcess, true);
};


export const plantingActionModel = {
  processStepId: 0, // required
  measurementUnitId: 0,

}
const insertPlantingAction = async (plantingAction) => {
  return await fetchPost(`api/planting-process/insert`, plantingActionModel, true);
}

export {insertPlantingProcess, insertPlantingAction}
