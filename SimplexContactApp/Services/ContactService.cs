using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplexContactApp.Data;
using SimplexContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplexContactApp.Services
{
    public class ContactService:IContactPersonServices
    {
        private readonly ContactPersonContext _contactpersonContext;

        public ContactService(ContactPersonContext contactpersonContext)
        {
            _contactpersonContext = contactpersonContext;
        }

        //Save contact
        public  Task AddContact(ContactModel addcontact)
        {
             _contactpersonContext.Contact.AddAsync(addcontact);
           return  _contactpersonContext.SaveChangesAsync();

        }

        //Update contact 
        public async Task UpdateContact(ContactModel contact)
        {
            // _contactPersonContext.Update(contact);  You can use either .Update() or .Entry().State=EntityState.Modified
            _contactpersonContext.Entry(contact).State = EntityState.Modified;
            await _contactpersonContext.SaveChangesAsync();
        }


        public  async  Task GetContactToDelete(int? id)
        {
             _contactpersonContext.Contact.FirstOrDefault(q => q.Id == id);

        }

            //Delete contact by Id
        public async Task DeleteContacById(int id)
        {
            var getId = _contactpersonContext.Contact.Find(id);
            _contactpersonContext.Contact.Remove(getId);
            _contactpersonContext.SaveChangesAsync();
        }

       
    }
}
