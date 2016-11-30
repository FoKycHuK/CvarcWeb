import {Component} from 'react';
import Game from './game';

class Games extends Component {
    render() {
        return (<ul>{this.props.games.map(g => {
                return <li key={g.GameId}>
                            <Game {...g}/>
                       </li>;
            })}</ul>);
    }
};

export default Games;