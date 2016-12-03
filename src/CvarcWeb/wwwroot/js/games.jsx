import {Component} from 'react';
import Game from './game';

class Games extends Component {
    render() {
        const gameItems = this.props.games.map(g => <Game {...g} key={g.GameId}/>);
        return (
            <div className="games-list">{gameItems}</div>
        );
    }
};

export default Games;