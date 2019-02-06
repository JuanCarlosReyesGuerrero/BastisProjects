using System;
using System.ComponentModel.DataAnnotations;

namespace Bastis.Models.Entities
{
    public  class Permission
    {
        [Key]
        [Required(ErrorMessage = "xxxxx")]
        public int PermissionID { get; set; }
               
        [Required(ErrorMessage = "xxxxx")]
        public Guid RoleID { get; set; }
                
        [Required(ErrorMessage = "xxxxx")]
        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
        
    }
}