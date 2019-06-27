using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using AutoMapper;
using BankSystem.BankSystemService;
using BankSystem.Models;
using System.Data;
using Microsoft.AspNet.Identity;

namespace BankSystem.Controllers
{
    public class CardsController : Controller
    {
        BankSystemServiceClient client;

        [HttpGet]
        public ActionResult Historia(ulong Nr)
        {
            if (client == null) client = new BankSystemServiceClient();

            if (Nr != null)
            {
                var result = new List<HistoriaResult>();

                foreach (var historia in client.GetTransaktionsByNrCard(Nr))
                {
                    var newhistoria = new HistoriaResult();

                    newhistoria.Amount = historia.TransactionAmount;
                    newhistoria.Balance = historia.TransactionBalance;
                    newhistoria.Date = historia.Date.Value.ToShortDateString();
                    newhistoria.Title = historia.Title;

                    result.Add(newhistoria);
                }
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
       
        public ActionResult Card()
        {
            if (client == null) client = new BankSystemServiceClient();
            var result = new List<CardsResult>();

            foreach (var card in client.GetCards(User.Identity.GetUserId()))
            {
                var newCard = new CardsResult();

                newCard.Id = card.Id;
                newCard.Name = card.Name;
                newCard.UserId = card.UserId;
                newCard.CardNumber = card.CardNumber;
                newCard.Available = card.Available;
                newCard.Balance = card.Balance;

                result.Add(newCard);
            }
            //List<CardsResult> result = Mapper.Map<CardsView[], List<CardsResult>>
            //(client.GetCards(User.Identity.GetUserId()));
            return View(result);
        }
        public ActionResult AddCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCard(CardsModel model)
        {
            if (ModelState.IsValid)
            {
                if (client == null) client = new BankSystemServiceClient();
                MembershipCreateStatus createStatus = client.AddCard(User.Identity.GetUserId(), model.Nazwa, model.Nr_karta);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    return RedirectToAction("Card", "Cards");
                }
                else
                {
                    ModelState.AddModelError("", createStatus.ToString());

                }
            }
            else
            {
                ModelState.AddModelError("", "Pola nie moga byc puste");

            }
            return View();
        }
        public ActionResult AddNewCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCard(AddNewCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (client == null) client = new BankSystemServiceClient();
                MembershipCreateStatus createStatus = client.AddNewCard(model.Nr_card, model.Srodki, model.Saldo);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    return RedirectToAction("Card", "Cards");
                }
                else
                {
                    ModelState.AddModelError("", createStatus.ToString());

                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Pola nie moga byc puste");

                return View();
            }
            
        }
        public ActionResult Doladowania()
        {
            if (client == null) client = new BankSystemServiceClient();

            ViewBag.Cards = client.GetCards(User.Identity.GetUserId());

            return View();
        }
        [HttpPost]
        public ActionResult Doladowania(DoladowanieModel model)
        {
            if (client == null) client = new BankSystemServiceClient();

            ViewBag.Cards = client.GetCards(User.Identity.GetUserId());
            //DataTable table = new DataTable();
            //table = cardService.getCards(membershipService.getIdByUserName(HttpContext.User.Identity.Name));
            //ViewData["Cards"] = table;
            if (ModelState.IsValid)
            {
                
                string Tytul = "Doladowanie telefonu" + model.Numer;
                DateTime? date = DateTime.Now;
                float saldo = client.GetSaldoByCardName(model.SelectedCardName,
                    User.Identity.GetUserId());
                if (saldo > model.Kwota)
                {
                    MembershipCreateStatus createStatus = client.CreateTransaktion(
                        User.Identity.GetUserId(), date, Tytul, model.Kwota, saldo,
                            client.GetIdByCardName(model.SelectedCardName,User.Identity.GetUserId()));

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Konto nie bylo doladowane");

                        return View();
                    }

                }
                else
                    ModelState.AddModelError("", "Kwota nie moze byc wieksza od dostepnych srodków");

                return View();
            }
            else
            {
                ModelState.AddModelError("", "Pola nie moga byc puste");

                return View();
            }
           

        }
           public ActionResult Przelewy()
           {
               if (client == null) client = new BankSystemServiceClient();

               ViewBag.Cards = client.GetCards(User.Identity.GetUserId());

               return View();
           }
         
        [HttpPost]
        public ActionResult Przelewy(PrzelewyModel model)
        {

            if (client == null) client = new BankSystemServiceClient();

            ViewBag.Cards = client.GetCards(User.Identity.GetUserId());
            //DataTable table = new DataTable();
            //table = cardService.getCards(membershipService.getIdByUserName(HttpContext.User.Identity.Name));
            //ViewData["Cards"] = table;

                if (ModelState.IsValid)
                {   
                    DateTime? date = DateTime.Now;
                    float saldo = client.GetSaldoByCardName(model.SelectedCardName,User.Identity.GetUserId());
                    if (saldo > model.Kwota)
                    {
                        client.GetExistingCard(model.Nr_Card, model.Kwota);
                        MembershipCreateStatus createStatus = client.CreateFullTransaktion(
                            User.Identity.GetUserId(),
                            date, model.Tytul, model.Nr_Card, model.Name, model.Miejscowosc, model.Ulica,
                            model.Kod, model.Kwota, saldo,
                            client.GetIdByCardName(model.SelectedCardName, User.Identity.GetUserId()));

                        if (createStatus == MembershipCreateStatus.Success)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Konto nie bylo doladowane");

                            return View();
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Kwota nie moze byc wieksza od dostepnych srodków");

                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Pola nie moga byc puste");

                    return View();
                }
            }
        }
    }

