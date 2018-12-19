using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Core.Commands;
using Bank.Core.Transporting;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IMessageBus bus;

        public AccountsController(IMessageBus bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        [Route("/create")]
        public async Task CreateAccount(string currency, int personId)
        {
            bus.SendAsync<CreateAccount>(new 
            {
                PersonId = personId,
                Currency = 1
            });
        } 

    }
}
