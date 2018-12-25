using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Core.Commands;
using Bank.Core.Domain;
using Bank.Core.Transporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    
    public class AccountsController : Controller
    {
        private readonly ICommandBus bus;
        //private readonly IPrinter printer;

        public AccountsController(ICommandBus bus)
        {
            //this.printer = printer;
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
        public void CreateAccount(string currency, int personId)
        {
            bus.Send<CreateAccount>(new
            {
                Id = Guid.NewGuid(),
                PersonId = 1,
                Currency = currency
            });
        }

        /// <summary>
        /// With Authorization
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("test")]
        public string SayHello()
        {
            return "Hello world!!!";
            //return printer.Print("Hello world!!!");
        }

        /// <summary>
        /// Without Authorization
        /// </summary>
        [HttpGet]
        [Route("test2")]
        public string SayHello2()
        {
            return "Hello world!!! 2";
        }
    }
}
