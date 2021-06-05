using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalLab.Models
{
    public class Session
    {
        public int SessionId {get;set;}
        public string NameOfFilm { get; set; }
        public DateTime TimeOfStart { get; set; }
        public int Coast { get; set; }
    }
}