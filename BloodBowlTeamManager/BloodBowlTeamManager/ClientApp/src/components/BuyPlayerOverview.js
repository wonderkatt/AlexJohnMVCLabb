import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class BuyPlayerOverview extends Component {
    static displayName = BuyPlayerOverview.name;

    constructor(props) {
        super(props);
        this.state =
        {
            playersToDisplay: [],
            loading: true,
            teamid: "",
            PlayerPosition: "",
            PlayerName: "",
            redirect: null
            
        };
        this.buyPlayer = this.buyPlayer.bind(this);
        
    }

    componentDidMount() {

        const teamid = this.props.location.state.id;
        this.populatePlayersData(teamid);
    }

    static renderPlayersOverview(players, parent) {
        return (
            <form onSubmit={parent.buyPlayer}>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Position</th>
                        <th>Cost</th>
                        <th>Name</th>
                    </tr>
                </thead>
                
                <tbody>
                    {players.map(player =>
                        <tr key={player.id}>
                            <td>{player.position}</td>
                            <td>{player.cost}</td>
                            <td><input type="radio" onChange={parent.handleChange} value={player.position} name="PlayerPosition" className="form-control"></input></td>
                        </tr>
                    )}
                    <tr>
                        <td><input onChange={parent.handleChange} placeholder="Enter player name..." name="PlayerName" className="form-control"></input></td>
                        <td><input type="submit" value="Buy" className="form-control"></input></td>
                        <td><input type="hidden" id="teamId" name="TeamId" value={parent.state.teamid}></input></td>
                    </tr>
                </tbody>
                
            </table>
            </form>
        );
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value })
        console.log(this.state)
    }

    render() {
        if (this.state.redirect) {
            return <Redirect to={{
                pathname: this.state.redirect,
                state: { teamid: this.state.teamid }
            }} />
        }
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BuyPlayerOverview.renderPlayersOverview(this.state.playersToDisplay, this);
        return (
            <div>
                <h1 id="tabelLabel" >Buy positionals</h1>
                    {contents}
            </div>
        );
    }

    async populatePlayersData(teamid) {
        const response = await fetch('/team/players/positions?teamid=' + teamid);
        const data = await response.json();
        this.setState({ playersToDisplay: data, loading: false, teamid : teamid });
    }


    async buyPlayer(event) {
        event.preventDefault();
        let fetchConfig = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(this.state)

        }
        const response = await fetch('/team/players/create', fetchConfig);
        const data = await response.json();
        this.setState({ redirect: "/team/players" })
        //Data gets success or fail for player creation
        //this.populateTeamData();
    }

}