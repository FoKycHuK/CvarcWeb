import {Component} from 'react';
import Rx from 'Rx';

class TeamNameFilter extends Component {
    constructor() {
        super();
        this.state = {};
    }

    componentDidMount() {
        var teams = new Bloodhound({
            datumTokenizer: function (datum) {
                return Bloodhound.tokenizers.whitespace(datum.value);
            },
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                wildcard: "%QUERY",
                url: "/Teams/?teamNamePrefix=%QUERY",
                transform: function(response) {
                    return $.map(response.teams, function(team) {
                        return {
                            value: team
                        };
                    });
                }
            }
        });
        $(this.__input).typeahead({
            highlight: true,
            minLength: 2
        }, {
            display: 'value',
            source: teams
        });
    }

    render() {
        return (
            <div className="team-name-filter">
                <div className="row-fluid">
                    <form role="form">
                    <div className="form-group">
                        <input type="text" className="typeahead form-control" placeholder="Team name" autoComplete="off" ref={(c) => this.__input = c}/>
                    </div>
                    </form>
                </div>
                <div className="row-fluid">
                    <ul id="results" ref={(c) => this.__results = c}></ul>
                </div>
            </div>);
    }
};

export default TeamNameFilter;