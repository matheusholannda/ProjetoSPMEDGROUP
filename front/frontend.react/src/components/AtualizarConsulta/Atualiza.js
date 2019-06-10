import React, { Component } from 'react';

let token = localStorage.getItem("user-spmedgroup");

export default class Cadastrar extends Component {

    constructor() {
        super();
        this.state = {
            lista: [],
            prontuario: '',
            medico: '',
            data: '',
            hora: '',
            dataConsulta: '',
            desc: '',
            situacao: 1,
            listaMedicos: [],
            listaPacientes: [],
            listaSituacoes: []
        }
    }

    buscarMedicos() {
        fetch('http://192.168.3.129:5000/api/Usuarios/ListarMedico', {
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-Type': 'application/json'
            }
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ listaMedicos: data }))
            .catch(erro => console.log(erro))
    }

    buscarPacientes() {
        fetch('http://192.168.3.129:5000/api/Usuarios/ListarPaciente', {
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-Type': 'application/json'
            }
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ listaPacientes: data }))
            .catch(erro => console.log(erro))
    }

    buscarConsultas() {
        fetch('http://192.168.3.129:5000/api/Consultas/', {
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-Type': 'application/json'
            }
        })
            .then(resposta => resposta.json())
            .then(data => {
                this.setState({ lista: data })})
            .catch(erro => console.log(erro))
    }

    atualizarConsulta(event) {
        event.preventDefault();

        let consulta = {
            IdProntuario: this.state.prontuario,
            IdMedico: this.state.medico,
            DataConsulta: this.state.data + "T" + this.state.hora,
            Descricao: this.state.desc,
            IdTipoSituacao: this.state.situacao
        };

        fetch('http://192.168.3.129:5000/api/Consultas/', {
            method: 'PUT',
            body: JSON.stringify(consulta),
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + token
            }
        })
            .then(resposta => {
                console.log(resposta)
            })
            .then(this.buscarConsultas())
            .catch(erro => console.log(erro))
    }

    buscarPorId(event) {
        event.preventDefault();
        // const idConsulta = (event.taget.getAttribute('id'))

        console.log(event.target.key);

        // fetch('http://192.168.3.129:5000/api/Consultas/buscarPorId/' + idConsulta, {
        //     headers: {
        //         'Authorization': 'Bearer ' + token,
        //         'Content-Type': 'application/json'
        //     }
        // })
        //     .then(resposta => resposta.json())
        //     // .then(data => this.setState({ lista: data }))
        //     .then(data => console.log(data))
        //     .catch(erro => console.log(erro))
        // buscar na api pelo id - fetch

        // preencher o state        
    }

    atualizaEstado(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    componentDidMount() {
        this.buscarConsultas();
        this.buscarPacientes();
        this.buscarMedicos();
    }

    render() {
        var that = this
        return (
            <div className="cadastro">
                <h1>Atualizar Consulta</h1>
                <form className="formAll" onSubmit={this.atualizarConsulta.bind(this)}>
                    <div className="formLeft">

                        <select
                            name="prontuario"
                            value={this.state.prontuario}
                            onChange={this.atualizaEstado.bind(this)}>
                            <option>Selecione um paciente</option>
                            {
                                this.state.listaPacientes.map(function (element) {
                                    return (
                                        <option value={element.id} key={element.id}>{element.idUsuarioNavigation.nome}</option>
                                    );
                                })
                            }
                        </select>

                        <select
                            name="medico"
                            value={this.state.medico}
                            onChange={this.atualizaEstado.bind(this)}>
                            <option>Selecione um médico</option>
                            {
                                this.state.listaMedicos.map(function (element) {
                                    return (
                                        <option value={element.id} key={element.id}>{element.nome}</option>
                                    );
                                })
                            }
                        </select>

                        <input
                            type="date"
                            name="data"
                            value={this.state.data}
                            onChange={this.atualizaEstado.bind(this)}
                        />
                    </div>
                    <div className="formRight">

                        <input
                            type="time"
                            name="hora"
                            value={this.state.hora}
                            onChange={this.atualizaEstado.bind(this)}
                        />

                        <input
                            type="text"
                            name="desc"
                            value={this.state.desc}
                            onChange={this.atualizaEstado.bind(this)}
                            placeholder="Descrição"
                        />

                        <select
                            name="situacao"
                            value={this.state.situacao}
                            onChange={this.atualizaEstado.bind(this)}>
                            <option>Altere o estado da consulta</option>
                            {
                                this.state.listaSituacoes.map(function (element) {
                                    return (
                                        <option value={element.id} key={element.id}>{element.situacao}</option>
                                    );
                                })
                            }
                        </select>

                        <button
                            type="submit"
                            className="RightBtn"
                        >
                            Atualizar
                                            </button>
                    </div>
                </form>

                <h2>Consultas</h2>
                <div className="listagem">
                    <table id="tabela-lista">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Prontuario</th>
                                <th>Medico</th>
                                <th>Data da Consulta</th>
                                <th>Observações</th>
                                <th>Situação da Consulta</th>
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
                                            <td>{consulta.descricao}</td>
                                            <td>{consulta.idTipoSituacaoNavigation.situacao}</td>
                                        </tr>
                                    );
                                })
                            }
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}