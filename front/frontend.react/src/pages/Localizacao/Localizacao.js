import React, { Component } from 'react';
import GoogleMapReact from 'google-map-react';
import { sair } from '../../services/auth';
import { Link } from 'react-router-dom';
import exit from '../../assets/images/enter.png';


const AnyReactComponent = ({ text }) => <div>{text}</div>;

export default class SimpleMap extends Component {
    static defaultProps = {
        center: {
            lat: 59.95,
            lng: 30.33
        },
        zoom: 11
    };

    render() {
        return (
            // Important! Always set the container height explicitly
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
                        <div style={{ height: '80vh', width: '80%' }} className="mapa">
                            <GoogleMapReact
                                defaultCenter={this.props.center}
                                defaultZoom={this.props.zoom}
                            >
                                <AnyReactComponent
                                    lat={59.955413}
                                    lng={30.337844}
                                    text="My Marker"
                                />
                            </GoogleMapReact>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}