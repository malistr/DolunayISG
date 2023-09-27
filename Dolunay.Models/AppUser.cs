using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolunay.Models
{
	[Table("Users")]
	public class AppUser : BaseModel
	{
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gsm { get; set; }
        [MaxLength(11)]
        public string TCKN { get; set; } = "11111111111";
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }  
    }
}
