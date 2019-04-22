import React, { Component } from 'react';
import exit from '../../assets/images/enter.png';
import './MenuConsultas.css';
import Cadastro from '../../components/CadastroConsulta/Cadastro'

let token = localStorage.getItem("user-spmedgroup");

// let jwtDecode = require("jwt-decode");

// let decode = jwtDecode(token);

export default class Menu extends Component {
    constructor() {
        super();
        this.state = {
            lista: [],
            prontuario: '',
            medico: '',
            data: '',
            desc: '',
            situacao: '',
        }
    }

    buscarConsultas() {
        fetch('http://localhost:5000/api/Consultas/', {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ lista: data }))
            .catch(erro => console.log(erro))
    }

    logout(event) {
        event.preventDefault();

        localStorage.removeItem("user-spmedgroup");
        this.props.history.push("/");
    }

    render() {
        document.title = 'SPMedGroup'
        return (
            <div>
                <div className="toolbar"><img src={exit} onClick={this.logout} alt="Sair da Página" /></div>
                <div className="info">
                    <div className="options"></div>
                    <div className="dados">
                        <section className="cadastroListagem">

                            {/* {decode.tipoUsuario == "Admin" ? (
                                <Cadastro />
                            ) : (
                                    <div></div>
                                )} */}
                                <Cadastro />
                            <h2>Consultas</h2>
                            <div className="listagem">
                                <table id="tabela-lista">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Id-Prontuario</th>
                                            <th>Id-Medico</th>
                                            <th>Data da Consulta</th>
                                            <th>Id-TipoSituação</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        {
                                            this.state.lista.map(function (consulta) {
                                                return (
                                                    <tr key={consulta.id}>
                                                        <td>{consulta.id}</td>
                                                        <td>{consulta.idProntuario}</td>
                                                        <td>{consulta.idMedico}</td>
                                                        <td>{consulta.dataConsulta}</td>
                                                        <td>{consulta.idTipoSituacao}</td>
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