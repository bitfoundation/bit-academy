using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ToDoApp.Pages
{
    public partial class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool ShowLoginErrorMessage = false;

        public void Signin()
        {
            if (UserName != "test" || Password != "test")
            {
                ShowLoginErrorMessage = true;
            }
            else
            {
                NavigationManager.NavigateTo("/Todo");
            }
        }
    }
}

