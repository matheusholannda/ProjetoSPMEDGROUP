import React, { Component } from 'react';
import { StyleSheet, View, Text, AsyncStorage } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';

import api from '../services/api';

export default class Consultas extends Component {
    constructor(props) {
        super(props);

        this.state = {
            lista: [],
            token: ""
        }
    }

    static navigationOptions = {
        header: null
    }

    componentDidMount() {
        this.carregarConsulta();
    };

    carregarConsulta = async () => {
        let token = await AsyncStorage.getItem('user-spmedgroup');
        const resposta = await api.get('/Consultas', {
            headers: {
                'Authorization': "Bearer " + token
            }
        });
        const dadosDaApi = resposta.data;
        this.setState({ lista: dadosDaApi });
    }

    render() {
        return (
            <View>
                <Text style={styles.headers}>Consultas</Text>
                <View style={styles.list}>
                    <FlatList
                        data={this.state.lista}
                        keyExtractor={item => item.id}
                        renderItem={this.renderizaItem}
                    />
                </View>
            </View>
        )
    }

    renderizaItem = ({ item }) => (
        <View style={styles.consultas}>
            <Text>Data: {item.dataConsulta}</Text>
            <Text>Status: {item.idTipoSituacaoNavigation.situacao}</Text>
            <Text>{item.idProntuarioNavigation.idUsuarioNavigation.nome}</Text>
            <Text>{item.idProntuarioNavigation.dataNascimento}</Text>
            <Text>{item.idMedicoNavigation.nome}</Text>
            <Text>Obs: {item.descricao}</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    headers: {
        color: "green"
        , width: 100
        , marginLeft: 160
        , fontSize: 20
        , marginTop: 20
    }
    , consultas: {
        padding: 10,
        backgroundColor: "#ededed"
        , width: '90%'
        , marginLeft: '5%'
        , marginTop: '5%'
        , fontSize: 12
    }
    , list: {
        paddingBottom: 120,
        paddingTop: 20
    }
})