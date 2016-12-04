import {Component} from 'react';
import Games from './games';
import TeamNameFilter from './teamNameFilter';

class GamesFilter extends Component {
    constructor() {
        super();
        this.state = {};
        this.state.games = [];
        this.loadGames();
    }

    buildQuery(params) {
        return Object.keys(params).map(k => `${k}=${params[k]}`).join("&");
    }

    loadGames() {
        const params = this.__teamNameFilter ? { TeamName: this.__teamNameFilter.getValue() } : {};
        let query = "?" + (this.buildQuery(params) || document.location.search.substring(1));
        return fetch(`Games/Find${query}`, {
                    credentials: "same-origin",
                    headers: { "Content-Type": "application/json", "enctype": "json" }
                }
            ).then(data => data.json())
            .then(data => this.setState({ games: data.games }));
    }

    render() {
        return (
            <div>
                <TeamNameFilter loadGames={(query) => this.loadGames(query)} ref={(c) => this.__teamNameFilter = c}/>
                <Games games={this.state.games}/>
            </div>
        );
    }
};

export default GamesFilter;