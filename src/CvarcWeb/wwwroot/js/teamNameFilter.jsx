import {Component} from 'react';

class TeamNameFilter extends Component {
    componentDidMount() {
        this.setSpinner();
        let chain = Promise.resolve();
        let changed = false;
        $(this.__input).on('input', () => {
            changed = true;
            setTimeout(() => changed = false, 200);
            setTimeout(() => {
                this.showSpinner();
                chain = chain.then(() => !changed && this.props.loadGames().then(() => this.hideSpinner()));
            }, 300);
        });
    }

    setSpinner() {
        this.__spinnerContainer.appendChild(document.querySelector("#spinner-source"));
        this.__spinner = this.__spinnerContainer.firstElementChild;
        this.__spinner.removeAttribute("id");
        this.hideSpinner();
    }

    hideSpinner() {
        this.__spinner.style.display = "none";
    }

    showSpinner() {
        this.__spinner.style.display = "block";
    }

    getValue() {
        return this.__input.value;
    }

    render() {
        return (
            <div className="team-name-filter">
                <div className="row-fluid">
                    <div className="form-group">
                        <input type="text" className="typeahead form-control" placeholder="Team name" autoComplete="off" ref={(c) => this.__input = c}/>
                    </div>
                </div>
                <div ref={(c) => this.__spinnerContainer = c}/>
            </div>);
    }
};

export default TeamNameFilter;