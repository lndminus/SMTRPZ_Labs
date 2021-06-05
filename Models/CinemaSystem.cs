using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalLab.Models
{
    public class CinemaSystem : ICinemaSystem
    {
        public List<Client> Clients = new List<Client>();
        public List<Ticket> Tickets = new List<Ticket>();
        public List<Session> Sessions = new List<Session>();

        public void GetTicketsForClient(Client client)
        {
            foreach (Ticket t in this.Tickets)
            {
                if (client.ClientId == t.ClientId)
                {
                    client.Tickets.Add(t);
                }
            }
        }
        public Client GetClient(int id)
        {
            foreach (Client c in this.Clients)
            {
                if (c.ClientId == id)
                {
                    return c;
                }
            }
            return null;
        }
        public Session GetSession(int id)
        {
            foreach (Session s in this.Sessions)
            {
                if (s.SessionId == id)
                {
                    return s;
                }
            }
            return null;
        }
        public void AddClient(IEnumerable<Client> clients)
        {
            foreach (Client c in clients)
            {
                this.Clients.Add(c);    
            }
        }
        public void AddSession(IEnumerable<Session> sessions)
        {
            foreach (Session s in sessions)
            {
                this.Sessions.Add(s);
            }
        }
        public void AddTickets(IEnumerable<Ticket> tickets)
        {
            foreach (Ticket t in tickets)
            {
                this.Tickets.Add(t);
            }
        }
        public bool CanBuyTicket(Session session, Client client) 
        {
            if (session.Coast <= client.Balance)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public Ticket BuyTicket(Session session, Client client) 
        {
            client.Balance = client.Balance - session.Coast;
            return new Ticket() { ClientId = client.ClientId, SessionId = session.SessionId };
        }

        public bool ClientExist(string login, string password) 
        {
            foreach (Client c in this.Clients) 
            {
                if (c.Login == login & c.Password == password) 
                {
                    return true;
                }
            }
            return false;
        }
        public Client GetClientByLogin(string login)
        {
            foreach (Client c in this.Clients) 
            {
                if (c.Login == login) 
                {
                    return c;
                }
            }
            return null;
        } 

    } 
}