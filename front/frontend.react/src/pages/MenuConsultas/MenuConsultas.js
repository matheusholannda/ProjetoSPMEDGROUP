import React, { Component } from 'react';
import exit from '../../assets/images/enter.png';
import './MenuConsultas.css';
import Cadastro from '../../components/CadastroConsulta/Cadastro';
import jwt_decode from 'jwt-decode';
import axios from 'axios';
import { sair } from '../../services/auth';
import { Link } from 'react-router-dom';

export default class Menu extends Component {
    constructor() {
        super();
        this.state = {
            lista: [],
            prontuario: '',
            medico: '',
            data: '',
            desc: '',
            situacao: ''
        }
    }

    buscarConsultas() {
        axios.get('http://localhost:5000/api/Consultas',
            {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem("user-spmedgroup"),
                    'Content-Type': 'application/json'
                }
            })

            .then(data => {
                console.log(data.data);
                this.setState({ lista: data.data })
            })
            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        document.title = 'SPMedGroup'
        let token = localStorage.getItem("user-spmedgroup");
        var decode = jwt_decode(token);

        var that = this

        return (
            <div>
                <div className="toolbar"><Link onClick={sair} to='/'><img src={exit} alt="Sair da Página" /></Link></div>
                <div className="info">
                    <div className="options"></div>
                    <div className="dados">
                        <section className="cadastroListagem">

                            {decode.Permissao == "ADMIN" ? (<Cadastro />) : <div></div>}

                            <h2>Consultas</h2>
                            <div className="listagem">
                                <table id="tabela-lista">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Prontuario</th>
                                            <th>Medico</th>
                                            <th>Data da Consulta</th>
                                            <th>Tipo Situação</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        {
                                            that.state.lista.map(consulta => {
                                                return (
                                                    <tr key={consulta.id}>
                                                        <td>{consulta.id}</td>
                                                        <td>{consulta.idProntuarioNavigation.idUsuarioNavigation.nome}</td>
                                                        <td>{consulta.idMedicoNavigation.nome}</td>
                                                        <td>{consulta.dataConsulta}</td>
                                                        <td>{consulta.idTipoSituacaoNavigation.situacao}</td>
                                                    </tr>
                                                );
                                            })
                                        }
                                    </tbody>
                                </table>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        );
    }
}