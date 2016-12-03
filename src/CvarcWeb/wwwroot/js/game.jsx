import {Component} from 'react';

class Game extends Component {
    render() {
        const game = this.props;
        const results = game.TeamGameResults.map((r, i) => {
            var isMainScores = (scoreType) => scoreType === "MainScores";
            var allMainScores = game.TeamGameResults.map(teamRes => teamRes.Results.filter(res => isMainScores(res.ScoresType))[0].Scores);
            var isPvp = game.TeamGameResults.length > 1;
            var isWinner = isPvp && allMainScores.filter(s => s < allMainScores[i]).length === allMainScores.length - 1;
            var classes = isWinner ? "team-result winner" : isPvp ? "team-result looser" : "team-result";
            return <div className={classes} key={r.Results.map(res => res.ResultId).join("/")}>
                       <div className="team-name">{r.Team.Name}</div>
                       {r.Results.map(res =>
                           <div className="scores" key={res.ResultId}>
                               <div className="score-type">{res.ScoresType}</div>
                               <div className="score">{res.Scores}</div>
                           </div>)}
                   </div>;
        });
        return (
            <li className="game">
                <div className="game-id">
                    <a href={game.PathToLog}>#{game.GameId}</a>
                </div>
                <div className="game-log">
                    <a href={game.PathToLog}>Посмотреть запись</a>
                </div>
                <div className="game-results">{results}</div>
            </li>
        );
    }
};

export default Game;