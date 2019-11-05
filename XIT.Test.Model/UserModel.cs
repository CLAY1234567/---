using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIT.Test.Model
{
   public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Passwords { get; set; }

        public int Sex { get; set; }


        public int Phone { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public int IaDelete { get; set; }
    }
}
