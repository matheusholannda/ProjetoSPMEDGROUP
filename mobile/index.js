import {AppRegistry} from 'react-native';
import {name as appName} from './app.json';
import Navigator from './src/pages/lista';

AppRegistry.registerComponent(appName, () => Navigator);
