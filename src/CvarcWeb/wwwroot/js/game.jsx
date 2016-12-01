import {Component} from 'react';

class Game extends Component {
    render() {
        const game = this.props;
        const teams = game.TeamGameResults.map(r => <td className="team-name" key={r.Team.TeamId}>{r.Team.Name}</td>);
        const results = game.TeamGameResults.map(r => <td className="team-result" key={r.Results.map(res => res.ResultId).join("/")}>{r.Results.map(res => res.Scores).join("/")}</td>);
        return (
            <tr className="game-item">
                <td className="game-id">{game.GameId}</td>
                <td className="game-name">{game.GameName}</td>
                <td className="game-log-link"><a href={game.PathToLog}>download</a></td>
                {teams[0]}{results[0]}{game.TeamGameResults.length == 2 ? [teams[1], results[1]] : [1, 2].map(i => <td key={i}></td>)}
            </tr>
        );
    }
};

export default Game;