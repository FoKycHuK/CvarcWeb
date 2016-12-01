import {Component} from 'react';
import Game from './game';

class Games extends Component {
    render() {
        const gameItems = this.props.games.map(g => <Game {...g} key={g.GameId}/>);
        return (
            <table className="games-results">
                <thead>
                    <tr>
                        <td>ID</td>
                        <td>Name</td>
                        <td>Log</td>
                        <td>Team 1</td>
                        <td></td>
                        <td></td>
                        <td>Team 2</td>
                    </tr>
                </thead>
                <tbody>    
                    {gameItems}
                </tbody>
            </table>
        );
    }
};

export default Games;