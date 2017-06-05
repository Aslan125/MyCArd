using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCard.Models;
namespace MyCard.Services
{
   public interface ICardService
    {
        bool CreateCard(Card Card);
        bool UpdateCard(Card Card);
        Card GetCard(int Id);
        bool DeleteCard( int Id);
        IEnumerable<Card> GetAllCards();
        IEnumerable<Category> GetCategories();
    }
}
