using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.Sales
{
    public class State
    {
        public State(string stateAbbreviation, string stateName)
        {
            StateAbbreviation = stateAbbreviation;
            StateName = stateName;
        }
        public State() { }

        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
    }
}