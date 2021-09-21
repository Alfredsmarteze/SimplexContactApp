using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplexContactApp.Data;
using SimplexContactApp.Models;
using SimplexContactApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace SimplexContactApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactPersonServices _contactPersonService;
        private readonly ContactPersonContext _contactPersonContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IContactPersonServices contactPersonService, ContactPersonContext contactPersonContext)
        {
            _contactPersonService = contactPersonService;
            _contactPersonContext = contactPersonContext;
            _logger = logger;
        }

        //[HttpGet]
        //public IActionResult Indexx()
        //{
        //    var c1 = new CheckBoxClass
        //    {
        //        Id = 1,
        //        Name = "Smart"
        //    };

        //    var c2 = new CheckBoxClass
        //    {
        //        Id = 2,
        //        Name = "Smart"
        //    };

        //    var c3 = new CheckBoxClass
        //    {
        //        Id = 1,
        //        Name = "Smart"
        //    };

        //    List<CheckBoxClass> checkBox = new List<CheckBoxClass>();
        //    checkBox.Add(c1);
        //    checkBox.Add(c2);
        //    checkBox.Add(c3);

        //    var qwe = new CheckBoxList
        //    {
        //        checkBoxClass = checkBox
        //    };

        //    return View(qwe);
        //}

        //[HttpPost]
        //public  IActionResult Indexx(CheckBoxClass checkBox1)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _contactPersonContext.CheckList.Add(checkBox1);
        //        _contactPersonContext.SaveChanges();
                 
        //    }
        //    return View();
        //}
        

        [HttpGet]
        public IActionResult Index()
        {
            var s1 = new Skillss
            {
                SelectedId = 1,
                Name = "Smart1",
            };

            var s2 = new Skillss
            {
                SelectedId = 2,
                Name = "Smart2",
            };

            var s3 = new Skillss
            {
                SelectedId = 3,
                Name = "Smart3",
            };

            List<Skillss> skills = new List<Skillss>();

            skills.Add(s1);
            skills.Add(s2);
            skills.Add(s3);

            var wsd = new ContactModel();
            wsd.skill = skills;

            var goa = new Goal();
            ContactModel rf = new ContactModel
            {
                GoalName = goa.ToString(),
                GoalSelect=skills.ToString()
            };
            return View(wsd);
        }


        //Create a contact
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index( ContactModel contactModel)
        {


            

                if (ModelState.IsValid)
                {
                //foreach (Skills item in skill)
                //{
                //    Skills skil = _contactPersonContext.GetSkills.ToList().Find(q => q.SelectedId == item.SelectedId);

                //    skil.Selected = skil.Selected;
                //}


                //var goal = contactModel.Setgoal;
                //ViewBag.Goal = goal.ToString();
                   _contactPersonContext.Add(contactModel);
                await   _contactPersonContext.SaveChangesAsync();



                //  await _contactPersonService.AddContact(contactModel);
                ModelState.Clear();
                    ViewData["Message"] = "Contact Successfully Added.";
                    return View();
                }
                else //if (!ModelState.IsValid)
                

                    
                
                return View();
            
        }

        //Get contact by Id
        [HttpGet]
        public  IActionResult EditContact(int? id)
        {

            //var retContactId =  _contactPersonService.GetContactId(id);
            var retContactId = _contactPersonContext.Contact.Find(id);
            if (retContactId==null)
            {
                return NotFound();
            }

           return View(retContactId);
            
        }

        //Update a contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContact(int id,  ContactModel contactModel )
        {
            //[Bind("Id,FirstName, LastName, PhoneNumber, Email, Address, Gender")]  This is optional but useful.

            if (id != contactModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               await _contactPersonService.UpdateContact(contactModel);
                
            }
          
            return View();
        }

        //Get contact to delete
        [HttpGet]
        public async Task<IActionResult> DeleteContact(int? id)
        {
            var contactDelete = _contactPersonContext.Contact.FirstOrDefault(s => s.Id == id);
            if (contactDelete == null)
            {
                return NotFound();
            }
            return View(contactDelete);

            
        }

        //Delete Contact
        [HttpPost,ActionName("DeleteContact")]
        public async Task<IActionResult> DeleteContactId(int id)
        {

            if (id==null)
            {
                return NotFound();
            }
            _contactPersonService.DeleteContacById(id);

            
            return View("DeleteContact");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
