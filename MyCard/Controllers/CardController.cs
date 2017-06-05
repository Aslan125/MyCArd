using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCard.Services;
using MyCard.Models;
using System.Net;
using MyCard.DB;

namespace MyCard.Controllers
{
    [RoutePrefix("api")]
    public class CardController : Controller
    {
        ICardService CardService { get; set; }
        public CardController(ICardService CardService)
        {
            this.CardService = CardService;
        }
   
        [Route("card")]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<Card> Cards = CardService.GetAllCards();

            if (Cards == null || Cards.Count() < 1)
            {
                return new HttpNotFoundResult();
            }


            return Json(Cards, JsonRequestBehavior.AllowGet);
        }


        [Route("category")]
        [HttpGet]
        public ActionResult Categories()
        {
            IEnumerable<Category> Categories = CardService.GetCategories();

            if (Categories == null || Categories.Count() < 1)
            {
                return new HttpNotFoundResult();
            }
            return Json(Categories, JsonRequestBehavior.AllowGet);
        }



        [Route("card/{Id}")]
        [HttpGet]
        public ActionResult GetCard(int Id)
        {
            Card Card = CardService.GetCard(Id);
            if(Card==null) return new HttpNotFoundResult();
            return Json(Card, JsonRequestBehavior.AllowGet);
        }

        [Route("card")]
        [HttpPost]
        public ActionResult CreateCard(Card Card)
        {
        
            if (!CardService.CreateCard(Card)) return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed);
            return   new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        [Route("card")]
        [HttpPut]
        public ActionResult UpdateCard(Card Card)
        {
            if (!CardService.UpdateCard(Card)) return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [Route("card/{Id}")]
        [HttpDelete]
        public ActionResult DeleteCard(int Id)
        {
            if (!CardService.DeleteCard(Id)) return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}