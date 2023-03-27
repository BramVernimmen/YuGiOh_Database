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


        public async Task<List<BasicCard>> GetCardsAsync()
        {
            List<BasicCard> cards = new List<BasicCard>();

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
                        string test = token.SelectToken("frameType").Value<string>();
                        if (test == "spell" || test == "trap")
                        {
                            card = token.ToObject<SpellTrapCard>();
                        }
                        else if (test == "skill")
                        {
                            continue;
                        }
                        else
                        {
                            card = token.ToObject<MonsterCard>();
                        }

                        cards.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }

            }

            return cards;
        }
    }
}
