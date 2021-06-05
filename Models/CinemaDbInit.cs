using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalLab.Models
{
    public class CinemaDbInit : DropCreateDatabaseAlways<CinemaContext>
    {
        protected override void Seed(CinemaContext db)
        {
            db.Sessions.Add(new Session { NameOfFilm = "Бегущий в лабиринте", TimeOfStart = new DateTime(2021,7,13,12,30,00), Coast = 100 });
            db.Sessions.Add(new Session { NameOfFilm = "Бегущий в лабиринте 2", TimeOfStart = new DateTime(2021, 7, 14, 12, 30, 00), Coast = 120 });
            db.Sessions.Add(new Session { NameOfFilm = "Бегущий в лабиринте 3", TimeOfStart = new DateTime(2021, 7, 15, 12, 30, 00), Coast = 140 });

            db.Clients.Add(new Client { Name = "Vlad", Balance = 500, Login = "asd", Password = "asd" });

            base.Seed(db);
        }
    }
}