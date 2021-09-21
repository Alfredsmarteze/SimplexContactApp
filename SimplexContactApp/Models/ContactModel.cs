using Microsoft.EntityFrameworkCore;
using SimplexContactApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimplexContactApp.Models
{
    public class ContactModel : IPerson
    {
        //public int Id { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name"), MinLength(3, ErrorMessage = "Name cannot be less than three letter"), MaxLength(29, ErrorMessage = "Name cannot be less than three letter")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a name"), MinLength(3), MaxLength(29)]
        public string LastName { get; set; }
        [Required(ErrorMessage ="This is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone number"), MaxLength(14)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter an email"), DataType(DataType.EmailAddress)]
        public string Email { get; set ; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "Please tick your skill(s)"), DisplayName("Software Skills")]
        [NotMapped]
        public List<Skillss> skill { get; set; }
        public string GoalSelect { get; set; }
        public string GoalName { get; set; }
        //public bool Selected { get; set; }

       // public Goal Setgoal { get; set; }
    }

    //[Keyless]
    public class Skillss
    {

        //  public List<Skills> skill { get; set; }
        public int SelectedId { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }

    }

    public enum Goal
    {
        CSharp, jQuery, DotNet, BootStrap
    }
    


}