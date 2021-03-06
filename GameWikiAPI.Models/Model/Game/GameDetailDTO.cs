using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWikiAPI.Models.Model.Game
{
    public class GameDetailDTO
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public IEnumerable<CharacterList> Characters {get; set;}
    }
}