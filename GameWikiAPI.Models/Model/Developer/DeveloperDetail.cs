using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWikiAPI.Models.Model.Game;

public class DeveloperDetail
    {
        public int Id {get;set;}

        public string Name {get;set;}

        public DateTime YearCreated {get;set;}

        public string CEO {get;set;}

        public IEnumerable<GameListDTO> Games {get;set;}

        // public List<CharacterEntity> Characters {get;set;}
    }
