using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YuGiOh.Model
{
    public class MonsterCard : BasicCard
    {
        [JsonProperty(PropertyName = "atk")]
        public int Attack { get; set; }
        [JsonProperty(PropertyName = "def")]
        public int Defense { get; set; }

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





    }
}
