@echo off
REM Create all necessary files for DSatUz project
echo Creating DSatUz project files...

REM Create directories
mkdir src\screens 2>nul

REM Create package.json
(
echo {
echo   "name": "dsatuz",
echo   "version": "1.0.0",
echo   "description": "SAT Exam Preparation Application",
echo   "main": "node_modules/expo/AppEntry.js",
echo   "scripts": {
echo   "start": "expo start",
echo     "android": "expo start --android",
echo     "ios": "expo start --ios",
echo  "web": "expo start --web"
echo   },
echo   "dependencies": {
echo     "expo": "~49.0.0",
echo     "react": "18.2.0",
echo     "react-native": "0.72.6",
echo     "@react-navigation/native": "^6.1.9",
echo     "@react-navigation/bottom-tabs": "^6.5.11",
echo     "@react-navigation/stack": "^6.3.20"
echo   },
echo   "private": true
echo }
) > package.json

REM Create app.json
(
echo {
echo   "expo": {
echo     "name": "DSatUz",
echo     "slug": "dsatuz",
echo     "version": "1.0.0",
echo     "assetBundlePatterns": ["**/*"]
echo   }
echo }
) > app.json

REM Create index.js
(
echo import { AppRegistry } from 'react-native';
echo import App from './src/App';
echo import { name as appName } from './app.json';
echo AppRegistry.registerComponent(appName, () => App);
) > index.js

echo Files created successfully!
echo.
echo Next step:
echo npm install
echo npm start
pause
