import {Component} from 'react';
import Games from './games';
import TeamNameFilter from './teamNameFilter';

class GamesFilter extends Component {
    constructor() {
        super();
        this.state = {};
        this.state.games = [];
        fetch(`Games/Find${document.location.search}`, {
                    credentials: "same-origin",
                    headers: { "Content-Type": "application/json", "enctype": "json" }
                }
        ).then(data => data.json())
         .then(data => this.setState({ games: data.games }));
    }

    render() {
        return (
            <div>
                <TeamNameFilter/>
                <Games games={this.state.games}/>
            </div>
        );
    }
};

export default GamesFilter;