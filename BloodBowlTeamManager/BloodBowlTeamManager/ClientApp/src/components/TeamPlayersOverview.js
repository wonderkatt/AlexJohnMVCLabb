import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class TeamPlayersOverview extends Component {
    static displayName = TeamPlayersOverview.name;

    constructor(props) {
        super(props);
        this.state =
        {
            playersToDisplay: [],
            loading: true,
            teamid: ""
        };
    }

    componentDidMount() {
        
        const teamid = this.props.location.state.id;
        this.populatePlayersData(teamid);
    }

    static renderPlayersOverview(players, thisParent) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Number</th>
                        <th>Player Name</th>
                        <th>Position</th>
                        <th>Cost</th>
                    </tr>
                </thead>
                <tbody>
                    {players.map(player =>
                        <tr key={player.id}>
                            <td>{player.number}</td>
                            <td>{player.playername}</td>
                            <td>{player.position}</td>
                            <td>{player.cost}</td>                        
                        </tr>
                    )}
                    <tr>
                        {players.length < 16 &&
                            <td>
                            <Link to={{
                                pathname: '/team/players/positions',
                                state: {
                                    id: thisParent.state.teamid
                                }
                            }} className="btn btn-primary" >Add player..</Link>
                            </td>
                        }               
                    </tr>
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : TeamPlayersOverview.renderPlayersOverview(this.state.playersToDisplay, this);
        return (
            <div>
                <h1 id="tabelLabel" >Players Overview</h1>
                {contents}
            </div>
        );
    }

    async populatePlayersData(teamid) {
        const response = await fetch('/team/players?teamid=' +  teamid );
        const data = await response.json();
        this.setState({ playersToDisplay: data, loading: false, teamid: teamid });
    }
}