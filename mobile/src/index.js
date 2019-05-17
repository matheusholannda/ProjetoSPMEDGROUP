import {
    createAppContainer,
    createStackNavigator,
    createSwitchNavigator
} from "react-navigation";
import Login from "./pages/login";
import Lista from "./pages/lista";

const AuthStack = createStackNavigator({ Login });

const MainNavigator = createStackNavigator({ Lista })

export default createAppContainer(
    createSwitchNavigator(
        {
            MainNavigator,
            AuthStack
        },
        {
            initialRouteName: "AuthStack"
        }
    )
);
