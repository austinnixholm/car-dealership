using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Sales;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockStateRepository : IStateRepository
    {
        private List<State> _states;

        public MockStateRepository()
        {
            SetStates();
        }

        private void SetStates()
        {
            _states = new List<State>(50);
            _states.Add(new State("AL", "Alabama"));
            _states.Add(new State("AK", "Alaska"));
            _states.Add(new State("AZ", "Arizona"));
            _states.Add(new State("AR", "Arkansas"));
            _states.Add(new State("CA", "California"));
            _states.Add(new State("CO", "Colorado"));
            _states.Add(new State("CT", "Connecticut"));
            _states.Add(new State("DE", "Delaware"));
            _states.Add(new State("DC", "District Of Columbia"));
            _states.Add(new State("FL", "Florida"));
            _states.Add(new State("GA", "Georgia"));
            _states.Add(new State("HI", "Hawaii"));
            _states.Add(new State("ID", "Idaho"));
            _states.Add(new State("IL", "Illinois"));
            _states.Add(new State("IN", "Indiana"));
            _states.Add(new State("IA", "Iowa"));
            _states.Add(new State("KS", "Kansas"));
            _states.Add(new State("KY", "Kentucky"));
            _states.Add(new State("LA", "Louisiana"));
            _states.Add(new State("ME", "Maine"));
            _states.Add(new State("MD", "Maryland"));
            _states.Add(new State("MA", "Massachusetts"));
            _states.Add(new State("MI", "Michigan"));
            _states.Add(new State("MN", "Minnesota"));
            _states.Add(new State("MS", "Mississippi"));
            _states.Add(new State("MO", "Missouri"));
            _states.Add(new State("MT", "Montana"));
            _states.Add(new State("NE", "Nebraska"));
            _states.Add(new State("NV", "Nevada"));
            _states.Add(new State("NH", "New Hampshire"));
            _states.Add(new State("NJ", "New Jersey"));
            _states.Add(new State("NM", "New Mexico"));
            _states.Add(new State("NY", "New York"));
            _states.Add(new State("NC", "North Carolina"));
            _states.Add(new State("ND", "North Dakota"));
            _states.Add(new State("OH", "Ohio"));
            _states.Add(new State("OK", "Oklahoma"));
            _states.Add(new State("OR", "Oregon"));
            _states.Add(new State("PA", "Pennsylvania"));
            _states.Add(new State("RI", "Rhode Island"));
            _states.Add(new State("SC", "South Carolina"));
            _states.Add(new State("SD", "South Dakota"));
            _states.Add(new State("TN", "Tennessee"));
            _states.Add(new State("TX", "Texas"));
            _states.Add(new State("UT", "Utah"));
            _states.Add(new State("VT", "Vermont"));
            _states.Add(new State("VA", "Virginia"));
            _states.Add(new State("WA", "Washington"));
            _states.Add(new State("WV", "West Virginia"));
            _states.Add(new State("WI", "Wisconsin"));
            _states.Add(new State("WY", "Wyoming"));
        }

        public List<State> GetAll()
        {
            return _states;
        }

        public State GetByAbbreviation(string stateAbbreviation)
        {
            return _states.FirstOrDefault(s => s.StateAbbreviation.ToLower().Equals(stateAbbreviation.ToLower()));
        }
    }
}