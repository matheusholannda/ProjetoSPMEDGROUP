import React, { Component } from 'react';
import exit from '../../assets/images/enter.png';
import './MenuConsultas.css';

let token = localStorage.getItem("user-spmedgroup");

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

    cadastrarConsulta(event) {
        event.preventDefault();

        fetch('http://localhost:5000/api/Consultas/', {
            method: 'POST',
            body: JSON.stringify({
                IdProntuario: this.state.prontuario,
                IdMedico: this.state.medico,
                DataConsulta: this.state.data,
                Descricao: null,
                IdTipoSituacao: this.state.situacao
            }),
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + token
            }
        })
            .then(resposta => resposta)
            .then(this.buscarTiposEventos())
            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarConsultas();
    }

    atualizaEstadoProntuario(event) {
        this.setState({ prontuario: event.target.value })
    }

    atualizaEstadoMedico(event) {
        this.setState({ medico: event.target.value })
    }

    atualizaEstadoData(event) {
        this.setState({ data: event.target.value })
    }

    atualizaEstadoDescricao(event) {
        this.setState({ desc: event.target.value })
    }

    atualizaEstadoSituacao(event) {
        this.setState({ situacao: event.target.value })
    }

    render() {
        document.title = 'SPMedGroup'
        return (
            <div>
                <div className="toolbar"><img src={exit} alt="Sair da Página" /></div>
                <div className="info">
                    <div className="options"></div>
                    <div className="dados">
                        <section className="cadastroListagem">
                            <div className="cadastro">
                                <h1>Cadastrar Consulta</h1>
                                <form className="formAll" onSubmit={this.cadastrarConsulta.bind(this)}>
                                    <div className="formLeft">
                                        <input
                                            type="text"
                                            value={this.state.prontuario}
                                            onChange={this.atualizaEstadoProntuario.bind(this)}
                                            id="nome-tipo-evento"
                                            placeholder="Prontuário"
                                        />
                                        <input
                                            type="text"
                                            value={this.state.medico}
                                            onChange={this.atualizaEstadoMedico.bind(this)}
                                            id="nome-tipo-evento"
                                            placeholder="Médico"
                                        />
                                        <input
                                            type="text"
                                            value={this.state.data}
                                            onChange={this.atualizaEstadoData.bind(this)}
                                            id="nome-tipo-evento"
                                            placeholder="Data e hora da consulta"
                                        />
                                    </div>
                                    <div className="formRight">
                                        <input
                                            type="text"
                                            value={this.state.desc}
                                            onChange={this.atualizaEstadoDescricao.bind(this)}
                                            id="nome-tipo-evento"
                                            placeholder="Descrição"
                                        />
                                        <input
                                            type="text"
                                            value={this.state.situacao}
                                            onChange={this.atualizaEstadoSituacao.bind(this)}
                                            id="nome-tipo-evento"
                                            placeholder="Situação"
                                        />
                                        <button
                                            type="submit"
                                            className="RightBtn"
                                        >
                                            Cadastrar
                                            </button>
                                    </div>
                                </form>
                            </div>
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