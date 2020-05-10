using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models

{
    public class CharacterItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Defence { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }

    }
}
