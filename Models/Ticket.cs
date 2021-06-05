using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalLab.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int ClientId { get; set; }
        public int SessionId { get; set; }
    }
}