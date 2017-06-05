using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCard.Services;
using MyCard.Models;
using MyCard.DB;
namespace MyCard.Controllers
{
    public class HomeController : Controller
    {
        ICardService CardService { get; set; }

        public HomeController(ICardService CardService)
        {
            this.CardService = CardService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [Route("Card")]
        [HttpGet]
        public ActionResult CardDetail()
        {
            return PartialView("Card");
        }

        [Route("CardList")]
        [HttpGet]
        public ActionResult CardList()
        {
            return PartialView("~/Views/Home/CardList.cshtml");
        }

        [Route("CardModal")]
        [HttpGet]
        public ActionResult CardModal()
        {
            return PartialView("~/Views/Home/CardModal.cshtml");
        }


    }
}