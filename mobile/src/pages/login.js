import React, { Component } from 'react';
import { Text, Image, StyleSheet, View, TextInput, TouchableOpacity, AsyncStorage, ImageBackground } from "react-native";
import api from '../services/api';

export default class Login extends Component {
    static navigationOptions = {
        header: null
    };

    constructor(props) {
        super(props);
        this.state = {
            email: ""
            , senha: ""
        }
    }

    realizarLogin = async () => {
        const resposta = await api.post("/login", {
            email: this.state.email,
            senha: this.state.senha
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem("user-spmedgroup", token);
        this.props.navigation.navigate("MainNavigator");
    }

    render() {
        return (
            <ImageBackground
            source={require("../assets/img/background.png")}
            style={{width: '100%', height: '100%'}}
            >
                <View style={styles.body}>
                    <Image
                        source={require('../assets/img/logo.png')}
                        style={styles.logo}
                    />
                    <TextInput style={styles.input}
                        onChangeText={email => this.setState({ email })}
                        placeholder="Email"
                    />
                    <TextInput style={styles.input}
                        onChangeText={senha => this.setState({ senha })}
                        placeholder="Senha"
                        secureTextEntry={true}
                    />
                    <TouchableOpacity
                        style={styles.button}
                        onPress={this.realizarLogin}
                    >
                        <Text style={styles.buttontxt}>Entrar</Text>
                    </TouchableOpacity>
                </View>
            </ImageBackground>
        );
    }
}

const styles = StyleSheet.create({
    input: {
        width: 250,
        backgroundColor: "transparent",
        borderBottomColor: "#707070",
        borderBottomWidth: 2,
        alignItems: "center",
        position: "relative",
        left: 80,
        top: 50
    },

    button: {
        height: 39,
        width: 124,
        backgroundColor: "#388E3C",
        borderBottomColor: "#1B5E20",
        borderWidth: 0.5,
        borderRadius: 5,
        position: "relative",
        left: 140,
        textAlign: "center",
        top: 150,
        shadowOffset: { width: 100, height: 100, },
        shadowColor: 'black',
        shadowOpacity: 1.0,
    },

    buttontxt: {
        textAlign: "center",
        color: "white",
        fontSize: 20,
        position: "relative",
        top: 5,
    },

    logo: {
        height: 100,
        width: 100,
        left: 155,
        resizeMode: "contain",
        marginTop: 100
    },

    body: {
        backgroundColor: '#FFFFFF',
        opacity: 0.8,
        width: '80%',
        height: '80%',
        marginTop: 70,
        marginLeft: 43
    }
});