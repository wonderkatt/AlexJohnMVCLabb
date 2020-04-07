import React, { Component } from 'react';

export class TeamPlayersOverview extends Component {
    static displayName = TeamPlayersOverview.name;

    constructor(props) {
        super(props);
        this.state = { playersToDisplay: [], loading: true };
        this.createPlayer = this.createPlayer.bind(this);
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
                        <th>Id</th>
                        <th>Number</th>
                        <th>Player Name</th>
                        <th>Position</th>
                    </tr>
                </thead>
                <tbody>
                    {players.map(player =>
                        <tr key={player.id}>
                            <td>{player.id}</td>
                            <td>{player.number}</td>
                            <td>{player.playername}</td>
                            <td>{player.position}</td>
                            
                        </tr>
                    )}
                    <tr>
                        {players.length < 16 &&
                            <td>
                            <Link className="btn btn-primary" onClick={thisParent.createPlayer}>Add player..</Link>
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
        this.setState({ playersToDisplay: data, loading: false });
    }

    async createPlayer(e) {
        e.preventDefault();
        let fetchConfig = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(this.state.teamid)
        }
        const response = await fetch('/team/players/create', fetchConfig);
        const data = await response.json();
        //Data gets success or fail for player
        this.populateTeamData();
    }

}