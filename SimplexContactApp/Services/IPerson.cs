using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplexContactApp.Services
{
  public  interface IPerson
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
