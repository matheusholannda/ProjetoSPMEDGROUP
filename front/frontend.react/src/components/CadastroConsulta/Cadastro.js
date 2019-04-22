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
            desc: '',
            situacao: '',
        }
    }
    
    cadastrarConsulta(event) {
        event.preventDefault();

        let consulta = {
            IdProntuario: this.state.prontuario,
            IdMedico: this.state.medico,
            DataConsulta: this.state.data,
            Descricao: null,
            IdTipoSituacao: this.state.situacao
        };

        fetch('http://localhost:5000/api/Consultas/', {
            method: 'POST',
            body: JSON.stringify(consulta),
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + token
            }
        })
            .then(resposta => console.log(resposta))
            .then(this.buscarConsultas())
            .catch(erro => console.log(erro))
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
        return (

            <div className="cadastro">
                <h1>Cadastrar Consulta</h1>
                <form className="formAll" onSubmit={this.cadastrarConsulta.bind(this)}>
                    <div className="formLeft">
                        <input
                            type="text"
                            value={this.state.prontuario}
                            onChange={this.atualizaEstadoProntuario.bind(this)}
                            placeholder="Prontuário"
                        />
                        <input
                            type="text"
                            value={this.state.medico}
                            onChange={this.atualizaEstadoMedico.bind(this)}
                            placeholder="Médico"
                        />
                        <input
                            type="date"
                            value={this.state.data}
                            onChange={this.atualizaEstadoData.bind(this)}
                        />
                    </div>
                    <div className="formRight">
                        <input
                            type="text"
                            value={this.state.desc}
                            onChange={this.atualizaEstadoDescricao.bind(this)}
                            placeholder="Descrição"
                        />
                        <input
                            type="text"
                            value={this.state.situacao}
                            onChange={this.atualizaEstadoSituacao.bind(this)}
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
        );
    }
}