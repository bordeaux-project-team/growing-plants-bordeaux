# Project of Universite de Bordeaux
Run the front-end:  
Step 0: Follow this link to set up environment for React Native: https://reactnative.dev/docs/environment-setup  
Step 1: Clone project  
Step 2: Open Terminal in the project folder or Use Terminal of IDE after open the project  
Step 3: `npm install`  
Step 4: `npx react-native start`  
Step 5: Open emulator  
Step 6: `npx react-native run-android`  

With `Task :app:generateDebugResValues` issue:  
Run `cd android; ./gradlew clean`

For localhost server: Need to run adb reverse to forward the port to emulator
`adb reverse tcp:64160 tcp:64160`
