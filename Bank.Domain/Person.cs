using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain
{
    public class Person
    {
        public Person(int id, string name, string email)
        {
            Id = Id;
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
