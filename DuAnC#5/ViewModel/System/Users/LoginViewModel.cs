using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.System.Users
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool? Rememberme { get; set; }
    }
    public class LoginViewModelGoogle
    {
        public string IdToken { get; set; }
  
    }
}
