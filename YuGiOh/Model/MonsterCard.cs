using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YuGiOh.Model.Interfaces;

namespace YuGiOh.Model
{
    public class MonsterCard : BasicCard, IHasTyping
    {
        // making atk and def nullable
        // 15 april 2023;
        // Colorless, Chaos King of Dark World is the only card with atk"null" and def"null"
        // doing this to prevent everything else

        [JsonProperty(PropertyName = "atk")]
        public int? Attack { get; set; }
        [JsonProperty(PropertyName = "def")]
        public int? Defense { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }


        [JsonProperty(PropertyName = "race")]
        public string Race { get; set; }

        [JsonProperty(PropertyName = "attribute")]
        public string Attribute { get; set; }

        [JsonProperty(PropertyName = "scale")]
        public int ScaleValue { get; set; }
        

        [JsonProperty(PropertyName = "linkval")]
        public int LinkValue { get; set; }

        public string Typing => Race;
    }
}
