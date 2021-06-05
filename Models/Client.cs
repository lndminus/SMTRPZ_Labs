using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalLab.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public List<Ticket> Tickets = new List<Ticket>();
    }
}