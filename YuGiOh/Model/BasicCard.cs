using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YuGiOh.Model
{
    public abstract class BasicCard
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string CardType { get; set; }

        // frameType is less complictated then Type, don't use it
        //public string FrameType { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }


        
        [JsonProperty(PropertyName = "archetype")]
        public string Archetype { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; } // normal image

    }
}
