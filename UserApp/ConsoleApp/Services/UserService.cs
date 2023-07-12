using ConsoleApp.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class UserService : IUserServices
    {
        public UserItem createUser() {

            UserItem newUser = new UserItem();
            Console.WriteLine("Enter a name");
            newUser.Name = Console.ReadLine();
            Console.WriteLine("Enter a surname");
            newUser.SurName = Console.ReadLine();
            Console.WriteLine("Wellcome " + newUser.Name + " " + newUser.SurName);


            return newUser; 
        }


        public void ShowUserMenu()
        {
            Console.WriteLine("1.Ingresar Usuario");
            Console.WriteLine("2.Mostrar Usuarios");

        }

    }
}
