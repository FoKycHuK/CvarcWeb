import {Component} from 'react';
import Games from './games';

class GamesFilter extends Component {
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
        return (<Games games={games}/>);
    }
};

export default GamesFilter;