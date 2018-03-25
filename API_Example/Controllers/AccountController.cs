using API_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Example.Controllers
{
    public class AccountController : ApiController
    {
        List<Account> acc = new List<Account>
        {
            new Account{id=1, username="duongdz", password="123456"},
            new Account{id=2, username="duongpro", password="123456"},
            new Account{id=3, username="duongbaby", password="123456"}
        };

        //[HttpGet]
        public List<Account> GetAllAccounts()
        {
            return acc;
        }

        public Account GetAccount (string username)
        {
            return acc.Find(x => x.username == username);
        }
        public Account GetAccount (int id)
        {
            return acc.Find(x => x.id == id);
        }
    }

    
}
