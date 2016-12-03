import {Component} from 'react';
import Games from './games';

class GamesFilter extends Component {
    constructor() {
        super();
        this.state = {};
        this.state.games = [];
        var params = { GameName: "TestGame" };
        var query = Object.keys(params)
            .map(k => encodeURIComponent(k) + "=" + encodeURIComponent(params[k]))
            .join("&");
        fetch(`Games/Find?${query}`, {
                    credentials: "same-origin",
                    headers: { "Content-Type": "application/json", "enctype": "json" }
                }
            )
            .then(data => data.json())
            .then(data => this.setState({ games: data.games }));
    }

    render() {
        var games = [
            {
                "GameId": 1,
                "GameName": "TestGame",
                "PathToLog": "C:/",
                "TeamGameResults": [
                  {
                      "TeamGameResultId": 1,
                      "Team": {
                          "TeamId": 1,
                          "Name": "Pizdec Kakoe Dlinnoe Imya Komandy",
                          "Owner": null,
                          "CvarcTag": "123",
                          "LinkToImage": "qwe",
                          "Members": null
                      },
                      "Results": [
                        {
                            "ResultId": 1,
                            "Scores": 10,
                            "ScoresType": "MainScores"
                        },
                        {
                            "ResultId": 2,
                            "Scores": 20,
                            "ScoresType": "OtherScores"
                        }
                      ]
                  }
                ]
            },
            {
                "GameId": 2,
                "GameName": "Second Game",
                "PathToLog": "C:/",
                "TeamGameResults": [
                  {
                      "TeamGameResultId": 3,
                      "Team": {
                          "TeamId": 3,
                          "Name": "Pizdec Kakoe Dlinnoe Imya Komandy",
                          "Owner": null,
                          "CvarcTag": "123",
                          "LinkToImage": "qwe",
                          "Members": null
                      },
                      "Results": [
                        {
                            "ResultId": 5,
                            "Scores": 10,
                            "ScoresType": "MainScores"
                        },
                        {
                            "ResultId": 6,
                            "Scores": 20,
                            "ScoresType": "OtherScores"
                        }
                      ]
                  },
                  {
                      "TeamGameResultId": 4,
                      "Team": {
                          "TeamId": 4,
                          "Name": "Bleat' Pizdec Kakoe Dlinnoe Imya Komandy",
                          "Owner": null,
                          "CvarcTag": "1234",
                          "LinkToImage": "qwer",
                          "Members": null
                      },
                      "Results": [
                        {
                            "ResultId": 7,
                            "Scores": 50,
                            "ScoresType": "MainScores"
                        },
                        {
                            "ResultId": 8,
                            "Scores": 70,
                            "ScoresType": "OtherScores"
                        }
                      ]
                  }
                ]
            },
            {
                "GameId": 3,
                "GameName": "TestGame",
                "PathToLog": "C:/",
                "TeamGameResults": [
                    {
                        "TeamGameResultId": 3,
                        "Team": {
                            "TeamId": 1,
                            "Name": "Winners",
                            "Owner": null,
                            "CvarcTag": "123",
                            "LinkToImage": "qwe",
                            "Members": null
                        },
                        "Results": [
                        {
                            "ResultId": 1,
                            "Scores": 10,
                            "ScoresType": "MainScores"
                        },
                        {
                            "ResultId": 2,
                            "Scores": 20,
                            "ScoresType": "OtherScores"
                        }
                        ]
                    },
                    {
                        "TeamGameResultId": 2,
                        "Team": {
                            "TeamId": 2,
                            "Name": "Loosers",
                            "Owner": null,
                            "CvarcTag": "1234",
                            "LinkToImage": "qwer",
                            "Members": null
                        },
                        "Results": [
                        {
                            "ResultId": 3,
                            "Scores": 5,
                            "ScoresType": "MainScores"
                        },
                        {
                            "ResultId": 4,
                            "Scores": 7,
                            "ScoresType": "OtherScores"
                        }
                        ]
                    }
                ]
            }
        ];
        //games = [];
        var i = 4;
        //var moreGames = games.map(g => {
        //    var game = JSON.parse(JSON.stringify(g));
        //    game.GameId = i++;
        //    return game;
        //});
        //games = games.concat(moreGames);
        //var moreGames = games.map(g => {
        //    var game = JSON.parse(JSON.stringify(g));
        //    game.GameId = i++;
        //    return game;
        //});
        //games = games.concat(moreGames);
        var moreGames = games.map(g => {
            var game = JSON.parse(JSON.stringify(g));
            game.GameId = i++;
            return game;
        });
        games = games.concat(moreGames);

        return (<Games games={this.state.games}/>);
    }
};

export default GamesFilter;