using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCard.Models;
using MyCard.DB;
using System.Data.Entity;

namespace MyCard.Services
{
    public class CardService : ICardService
    {



        public bool CreateCard(Card Card)
        {
            if (Card == null) return false;

            Context DB = new Context();

            List<Category> Categories = DB.Categories.ToList();
       
            //foreach (var item in Categories)
            //{
            //    if (Card.Categories.Exists(c => c.Id == item.Id))
            //    {
            //        Card.Categories.RemoveAll(c => c.Id == item.Id);

            //        Card.Categories.Add(item);
            //    }

            //}

            DB.Cards.Add(Card);
            try
            {

                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool DeleteCard(int Id)
        {
            Context DB = new Context();

            Card Card = DB.Cards.Where(c => c.Id == Id).FirstOrDefault();

            if (Card == null) return false;
            DB.Entry(Card).Collection(c => c.Categories).Load();
            DB.Cards.Remove(Card);
            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }


            return true;
        }

        public IEnumerable<Card> GetAllCards()
        {
            List<Card> Cards = null;
            Context DB = new Context();


            Cards = DB.Cards.ToList();

            if (Cards == null || Cards.Count() < 1)
            {
                return null;
            }


            return Cards;

        }

        public Card GetCard(int Id)
        {
            Context DB = new Context();

            return DB.Cards.Where(c => c.Id == Id).ToList().FirstOrDefault();


        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> Categories = null;
            Context DB = new Context();


            Categories = DB.Categories.ToList();
            if (Categories == null || Categories.Count() < 1)
            {
                return null;
            }
            return Categories;

        }

        public bool UpdateCard(Card Card)
        {
            if (Card == null || Card.Id == null) return false;
            Context DB = new Context();

            Card _card = DB.Cards.Where(c => c.Id == Card.Id).FirstOrDefault();
   
            if (Card == null) return false;

            //List<Category> Categories = DB.Categories.ToList();
            //foreach (var item in Categories)
            //{
            //    _card.Categories.Remove(item);

            //}
            //foreach (var item in Categories)
            //{
            //    if (Card.Categories.Exists(c => c.Id == item.Id))
            //    {
            //        _card.Categories.Add(item);
            //    }        

            //}

            _card.Categories.RemoveRange(0, _card.Categories.Count );
            _card.Categories.AddRange(Card.Categories);
            _card.Name = Card.Name;
            _card.Description = Card.Description;

            try
            {
                DB.Entry(_card).State = EntityState.Modified;
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }


            return true;
        }
    }
}