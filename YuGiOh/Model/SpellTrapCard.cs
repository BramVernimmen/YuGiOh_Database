using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YuGiOh.Model.Interfaces;

namespace YuGiOh.Model
{
    public class SpellTrapCard : BasicCard, IHasTyping
    {
        [JsonProperty(PropertyName = "race")]
        public string Speed { get; set; } // sets the type of spell/trap, also known as SpellSpeed

        public string Typing => Speed;
    }
}
