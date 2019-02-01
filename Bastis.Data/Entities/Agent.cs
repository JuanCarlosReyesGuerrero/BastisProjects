using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bastis.Data.Entities
{
    public class Agent
    {
        [Key]
        [Column(Order = 1)]
        public Guid CustomerID { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmploymentCharge { get; set; }

        public string Expirience { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
                
        public string Phone { get; set; }

        [Required]
        [MaxLength(128)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(128)]
        public string AboutMe { get; set; }
        //Facebook
        //twitter
        //Google+
        //LinkedIn
        //Instagram
        //Pinterest

        [Required]
        [MaxLength(128)]
        public string SocialNetworks { get; set; }

        public string Website { get; set; }


        //[Required]
        //[MaxLength(128)]
        public string ProfilePicture { get; set; }

        public Guid UserRegisters { get; set; }
        public DateTime DateRegister { get; set; }
        public Guid UserModifies { get; set; }
        public DateTime DateModified { get; set; }
    }
}
