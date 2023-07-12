using ConsoleApp.Services;
using Entities.Entities;


List<UserItem> userList = new List<UserItem>();
UserService userService = new UserService();
userService.ShowUserMenu();
var option = Convert.ToInt32(Console.ReadLine());

while (option != 0)

{
    if (option == 1)
    {

        userList.Add(userService.createUser());
    }


    if (option == 2)
    {
        foreach (var u in userList)
        {
            Console.WriteLine(
                u.Name + " " +
                u.SurName
               );
        }
    }


    userService.ShowUserMenu();

    option = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Adiós, muchas gracias");

