using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOh.Model;

namespace YuGiOh.Repository
{
    public interface ICardsRepository
    { 
        Task<List<BasicCard>> GetCardsAsync();

        Task<List<string>> GetCardTypes();

        Task<List<BasicCard>> GetCardsOfType(string type);
    }
}
