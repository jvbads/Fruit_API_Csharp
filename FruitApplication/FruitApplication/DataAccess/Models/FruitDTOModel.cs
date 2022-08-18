﻿using System.ComponentModel.DataAnnotations;

namespace FruitApplication.Entities
{
    public class FruitDTOModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Required {0} field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required {0} field")]
        [MinLength(25, ErrorMessage = "This {0} field need to have minimun {1} caracters.")]
        public string Description { get; set; }
        //public FruitType Type { get; set; }

        public FruitDTOModel()
        {
        }
        public FruitDTOModel(int id, string name, string description/*, FruitType type*/)
        {
            Id = id;
            Name = name;
            Description = description;
            //Type = type;
        }
    }
}
