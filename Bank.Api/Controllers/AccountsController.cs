using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Core.Commands;
using Bank.Core.Transporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IMessageBus bus;

        public AccountsController(IMessageBus bus)
        {
            this.bus = bus;
        }

        /// <summary>
        /// SUMMARY INFORMATION!
        /// </summary>
        /// <remarks>
        /// REMARKS are awesome because they become implementation notes!
        ///     
        ///     {
        ///         "WithSome": "Tab support for code blocks!"
        ///     }
        /// 
        /// Documentation power at your fingertips!
        /// </remarks>
        [HttpPost]
        [Route("/create")]
        public async Task CreateAccount(string currency, int personId)
        {
            //bus.SendAsync<CreateAccount>(new 
            //{
            //    PersonId = personId,
            //    Currency = 1
            //});
        }

        /// <summary>
        /// Test endpoint
        /// </summary>
        [HttpGet]
        [Route("/test")]
        public string SayHello()
        {
            return "Hello world!!!";
        }
    }
}
