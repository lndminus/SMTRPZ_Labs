using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalLab.Models
{
    public interface ICinemaSystem
    {
        void GetTicketsForClient(Client client);
        Client GetClient(int id);
        Session GetSession(int id);
        void AddClient(IEnumerable<Client> clients);
        void AddSession(IEnumerable<Session> sessions);
        void AddTickets(IEnumerable<Ticket> tickets);
        bool CanBuyTicket(Session session, Client client);
        Ticket BuyTicket(Session session, Client client);
        bool ClientExist(string login, string password);
        Client GetClientByLogin(string login);
    }
}