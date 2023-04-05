using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YuGiOh.Model
{
    public class SpellTrapCard : BasicCard
    {
        [JsonProperty(PropertyName = "race")]
        public string Typing { get; set; } // sets the type of spell/trap

    }
}
