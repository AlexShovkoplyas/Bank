using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    
    public class AccountsController : Controller
    {
        //private readonly IMessageBus bus;
        private readonly IPrinter printer;

        public AccountsController(IPrinter printer)
        {
            this.printer = printer;
            //this.bus = bus;
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
            //bus.SendAsync<CreateAccount>(new 
            //{
            //    PersonId = personId,
            //    Currency = 1
            //});
        }

        /// <summary>
        /// With Authorization
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("test")]
        public string SayHello()
        {
            return printer.Print("Hello world!!!");
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
