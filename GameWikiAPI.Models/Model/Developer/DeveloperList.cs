using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DeveloperList
    {
        public int Id {get;set;}

        public string Name {get;set;}

        public DateTime YearCreated {get;set;}

        public string CEO {get;set;}

        public List<GameEntity> Games {get;set;}
    }
