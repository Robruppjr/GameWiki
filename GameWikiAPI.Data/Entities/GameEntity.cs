using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class GameEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(Developer))]
        public int DevId { get; set; }
        public virtual DeveloperEntity Developer { get; set; }
        public List<CharacterEntity> Characters { get; set; }
    }
