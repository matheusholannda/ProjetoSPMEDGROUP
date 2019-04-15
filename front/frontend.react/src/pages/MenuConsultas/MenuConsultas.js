import React, {Component} from 'react';
import exit from '../../assets/images/enter.png';
import './MenuConsultas.css';

export default class Menu extends Component {
    render(){
        document.title = 'SPMedGroup'
        return(
            <div>
                <div className="toolbar"><img src={exit}  alt="Sair da Página"></img></div>
                <div className="info">
                <div className="options"></div>
                <div className="dados">
                <h1>Cadastrar Consulta</h1>
                </div>
                </div>
            </div>
        );
    }
}