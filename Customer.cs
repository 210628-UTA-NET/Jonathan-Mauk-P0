using System;
using System.Collections.Generic;

namespace P0 
{
    class Customer 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Orders> Orders { get; set; }
        public Customer()
        {
            
        }
    }
}