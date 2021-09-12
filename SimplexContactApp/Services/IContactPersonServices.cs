using Microsoft.AspNetCore.Mvc;
using SimplexContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplexContactApp.Services
{
   public interface IContactPersonServices
    {
        public Task AddContact(ContactModel contactModel);
        public Task UpdateContact(ContactModel contact);
        public Task DeleteContacById(int id);
        public Task GetContactToDelete(int? id);
    }
}
