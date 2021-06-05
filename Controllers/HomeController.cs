using FinalLab.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalLab.Controllers
{
    public class HomeController : Controller
    {
        CinemaContext db = new CinemaContext();
        private ICinemaSystem repo;

        public HomeController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICinemaSystem>().To<CinemaSystem>();
            repo = ninjectKernel.Get<ICinemaSystem>();
        }

        public void ViewData()
        {
            throw new NotImplementedException();
        }

        public ActionResult Indexx()
        {
            return View(repo.ClientExist("asd","asd"));
        }

        [HttpGet]
        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Session> sessions = db.Sessions;
            IEnumerable<Client> clients = db.Clients;
            IEnumerable<Ticket> tickets = db.Tickets;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Sessions = sessions;
            // возвращаем представление
            return View();
        }
        [HttpPost]
        public ActionResult Index(string login, string password)
        {
            IEnumerable<Session> sessions = db.Sessions;
            IEnumerable<Client> clients = db.Clients;
            IEnumerable<Ticket> tickets = db.Tickets;
            CinemaSystem s = new CinemaSystem();
            s.AddSession(sessions);
            s.AddClient(clients);
            s.AddTickets(tickets);
            if (s.ClientExist(login, password))
            {
                return View("~/Views/Home/Menu.cshtml");
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }
        [HttpGet]
        public ActionResult BuyTicket()
        {
            return View();
        }
        [HttpPost]
        public string BuyTicket(string login, string password, int SessionId)
        {
            IEnumerable<Session> sessions = db.Sessions;
            IEnumerable<Client> clients = db.Clients;
            IEnumerable<Ticket> tickets = db.Tickets;
            CinemaSystem s = new CinemaSystem();
            s.AddSession(sessions);
            s.AddClient(clients);
            s.AddTickets(tickets);
            if (s.ClientExist(login, password))
            {
                Client client = s.GetClientByLogin(login);
                Session session = s.GetSession(SessionId);
                if (s.CanBuyTicket(session, client))
                {
                    db.Tickets.Add(s.BuyTicket(session, client));
                    db.SaveChanges();
                    return "Билет успешно преобретен";
                }
                else
                {
                    return "Недостаточно средств";
                }
            }
            else
            {
                return "Неправельный логин или пароль";
            }
        }
        public ActionResult Poster(string number)
        {
            ViewBag.N = number;
            IEnumerable<Session> sessions = db.Sessions;
            ViewBag.Sessions = sessions;
            return View();
        }
        [HttpGet]
        public ActionResult ShowTickets()
        {
            return View();
        }
        [HttpPost]
        public string ShowTickets(string login, string password)
        {
            IEnumerable<Session> sessions = db.Sessions;
            IEnumerable<Client> clients = db.Clients;
            IEnumerable<Ticket> tickets = db.Tickets;
            CinemaSystem s = new CinemaSystem();
            s.AddSession(sessions);
            s.AddClient(clients);
            s.AddTickets(tickets);
            if (s.ClientExist(login, password))
            {
                Client client = s.GetClientByLogin(login);
                s.GetTicketsForClient(client);
                string answer = "";
                foreach (Ticket t in client.Tickets)
                {
                    answer = answer + "\nБилет";
                }
                return answer;
            }
            else
            {
                return "Неправельный логин или пароль";
            }
        }
        [HttpGet]
        public ActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autorization(string login, string password)
        {
            IEnumerable<Session> sessions = db.Sessions;
            IEnumerable<Client> clients = db.Clients;
            IEnumerable<Ticket> tickets = db.Tickets;
            CinemaSystem s = new CinemaSystem();
            s.AddSession(sessions);
            s.AddClient(clients);
            s.AddTickets(tickets);
            if (s.ClientExist(login, password))
            {
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View("~/Views/Home/Autorization.cshtml");
            }
        }
        public ActionResult Menu(string number)
        {
            ViewBag.Number = number;
            return View();
        }
    }
}