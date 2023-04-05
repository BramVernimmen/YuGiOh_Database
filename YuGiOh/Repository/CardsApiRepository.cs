using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOh.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;

namespace YuGiOh.Repository
{
    public class CardsApiRepository : ICardsRepository
    {
        private string _endPoint = "https://db.ygoprodeck.com/api/v7/cardinfo.php";

        private List<BasicCard> _cards;

        public async Task<List<BasicCard>> GetCardsAsync()
        {
            if (_cards != null)
                return _cards;

            _cards = new List<BasicCard>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(_endPoint);

                    if (!response.IsSuccessStatusCode) // check if failed
                        throw new HttpRequestException(response.ReasonPhrase);

                    // read results as string
                    string json = await response.Content.ReadAsStringAsync();

                    // deserialize json
                    var cardTokens = JToken.Parse(json).SelectToken("data");

                    foreach (var token in cardTokens)
                    {
                        BasicCard card;
                        // check what type of cards we need to create
                        string frameType = token.SelectToken("frameType").Value<string>();
                        if (frameType == "spell" || frameType == "trap")
                        {
                            card = token.ToObject<SpellTrapCard>();
                        }
                        else if (frameType == "skill")
                        {
                            continue;
                        }
                        else
                        {
                            card = token.ToObject<MonsterCard>();
                        }

                        if (card.Archetype == null)
                            card.Archetype = "N/A";

                        _cards.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }

            }

            return _cards;
        }

        public async Task<List<string>> GetCardTypes()
        {
            List<string> types = new List<string>();

            var cards = await GetCardsAsync();

            foreach (var card in cards)
            {
                bool foundString = false;
                foreach (var typing in types) 
                { 
                    if (typing.Equals(card.CardType))
                    {
                        foundString = true;
                        break;
                    }
                }

                if (!foundString)
                    types.Add(card.CardType);
            }

            types.Sort();
            types.Insert(0, "Select Type");

            return types;
        }

        public async Task<List<BasicCard>> GetCardsOfType(string type)
        {
            List<BasicCard> cardsOfType = new List<BasicCard>();

            var allCards = await GetCardsAsync();

            if (type == null)
                return allCards;

            if (type.Equals("Select Type"))
                return allCards;

            foreach (var card in allCards) 
            { 
                if (card.CardType == type)
                    cardsOfType.Add(card);
            }

            return cardsOfType;
        }

        public async Task<List<string>> GetArcheTypes()
        {
            List<string> archetypes = new List<string>();

            var cards = await GetCardsAsync();

            foreach (var card in cards)
            {
                bool foundString = false;
                foreach (var currArchetype in archetypes)
                {
                    if (currArchetype.Equals(card.Archetype))
                    {
                        foundString = true;
                        break;
                    }
                }

                if (!foundString)
                    archetypes.Add(card.Archetype);
            }

            archetypes.Sort();
            archetypes.Insert(0, "Select Archetype");

            return archetypes;
        }

        public async Task<List<BasicCard>> GetCardsFromArcheType(string archetype)
        {
            List<BasicCard> cardsOfArcheType = new List<BasicCard>();

            var allCards = await GetCardsAsync();

            if (archetype == null)
                return allCards;

            if (archetype.Equals("Select Archetype"))
                return allCards;

            foreach (var card in allCards)
            {
                if (card.Archetype == archetype)
                    cardsOfArcheType.Add(card);
            }

            return cardsOfArcheType;
        }
    }
}
