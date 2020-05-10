using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Models

{
    public class CharacterItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Defence { get; set; }
        [Range(100.0,2000.0)]
        public int Strength { get; set; }
        [Range(100.0,2000.0)]
        public int Intelligence { get; set; }
        [Range(100.0,2000.0)]

    }
}
