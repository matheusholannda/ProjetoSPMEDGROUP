import React, { Component } from 'react';
import exit from '../../assets/images/enter.png';
import './MenuConsultas.css';
import Cadastro from '../../components/CadastroConsulta/Cadastro';
import Atualiza from '../../components/AtualizarConsulta/Atualiza';
import jwt_decode from 'jwt-decode';
import { sair } from '../../services/auth';
import { Link } from 'react-router-dom';

export default class Menu extends Component {

    render() {
        document.title = 'SPMedGroup'
        let token = localStorage.getItem("user-spmedgroup");
        var decode = jwt_decode(token);
        return (
            <div>
                <div className="toolbar"><Link onClick={sair} to='/'><img src={exit} alt="Sair da Página" /></Link></div>
                <div className="info">
                    <div className="options">
                        <ul>
                            <li>Enchimento</li>
                        </ul>
                        <ul>
                            <li>Cadastrar Paciente</li>
                            <li>Cadastrar Médico</li>
                            <Link to='/localizacao'><li>Localizações</li></Link>
                        </ul>
                        <ul>
                            <li>Todos os direitos reservados ©</li>
                        </ul>
                    </div>
                    <div className="dados">
                        <section className="cadastroListagem">

                            {decode.Permissao == "ADMIN" ? (<Cadastro />) : <div></div>}
                            {decode.Permissao == "MEDICO" ? (<Atualiza />) : <div></div>}
                        </section>
                    </div>
                </div>
            </div>
        );
    }
}