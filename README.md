# Project of Universite de Bordeaux

**Run the front-end:**  
Step 0: Follow this link to set up environment for React Native: https://reactnative.dev/docs/environment-setup  
Step 1: Clone project  
Step 2: Open Terminal in the project folder or Use Terminal of IDE after open the project  
Step 3: `npm install`  
Step 4: Open emulator   
Step 5: Open two terminal in folder /front-end/   
Step 6: `npx react-native start`  
Step 7: `npx react-native run-android`  

With `Task :app:generateDebugResValues` issue:  
Run `cd android; ./gradlew clean`

**Run the back-end:**  
Step 0: Install Visual Studio & MS SQL Server   
Step 1: Run GrowingPlants.sln in \back-end\GrowingPlants\   
Step 2: Edit \back-end\GrowingPlants\GrowingPlants.Apis\appsettings.Development.json with appropriate value     
Ex: `"GrowingPlantsDb": "Data Source=LAPTOP-6G9AE7GU\\SQLEXPRESS;Initial Catalog=GrowingPlants;Integrated Security=SSPI;"`    
Step 3: Run GrowingPlants.Apis by Visual Studio   
Step 4: For localhost server: Need to run adb reverse to forward the port to emulator   
`cd %ANDROID_HOME%\platform-tools`  
`adb reverse tcp:64160 tcp:64160`   
(For Windows, remember remove 'adb' in Task Management > Processes before turn off PC)

**Run with the real server:**     
Do not open the emulator before below steps   
Step 1: Run adb   
`cd %ANDROID_HOME%\platform-tools`  
`adb kill-server` (if needed or stuck port)   
`adb start-server`    
Step 2: Open emulator   
Step 3: Connect ADB   
`adb tcpip 49172`   
`adb connect 52.163.200.27:49172`   
Step 4: Start front-end   
`npx react-native start`  
`npx react-native run-android`  
