using System.Runtime.CompilerServices;

namespace ConsoleApp875
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            Console.WriteLine("Yeni User elave edek (Create)");
            Random rnd = new Random(); //random 
            int id = rnd.Next(1, 10);
            Console.WriteLine("name: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("email:");
            string email = Convert.ToString(Console.ReadLine());
            User newUser = new User(id, name, email);
            Console.WriteLine($"ID:{id}");
            userService.Create(newUser);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("id ye gore namein tapmaq ");
            int byid=Convert.ToInt32(Console.ReadLine());
            string  x=userService.GetByID(byid);
            if (x != null)
            {
                Console.WriteLine($"Tapildi:{x}");
            }
            else
            {
                Console.WriteLine("Tapilmadi");
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine(" gostermek ALL");
            Console.WriteLine("listimiz beledi:");
              User[] allusers =userService.GetAll();
            for (int i = 0; i < allusers.Length; i++) {

                Console.WriteLine($"Id: {allusers[i].Id} Name: {allusers[i].Name} Email:{allusers[i].Email}");
            
            
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("silmek(delete):");
            Console.WriteLine("SIlmek istediyin ID ni daxil ele(user silinecek)");
            int Q=Convert.ToInt32(Console.ReadLine());
            userService.Delete(Q);




        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;

        }


    }

    public class App
    {
        private User[] users;
        public User[] Users

        {
            get
            {
                return users;
            }
        }
        public App()
        {

            users = new User[5]
            {
                new User(1,"Ferid","ferid875@gmail.com"),
                new User(2,"Yusif","yusif17@gmail.com"),
                new User(3,"Orxan","orxan661@gmail.com"),
                new User(4,"Revan","revan111@gmail.com"),
                new User (5,"Veli","veli@gmal.com")
            };
        }

    }
    public class UserService
    {
        private readonly App _user;
        private User[] _users;
        public UserService()
        {
            _user = new App();
            _users = _user.Users;

        }
        public void Create(User user)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i].Id == user.Id)
                {
                    Console.WriteLine("artiq bu ID movcuddur , Elave olunmadi");
                    return;
                }
            }
            User[] newUsers = new User[_users.Length + 1];
            for (int i = 0; i < _users.Length; i++)
            {
                newUsers[i] = _users[i];

            }
            newUsers[newUsers.Length - 1] = user;
            _users = newUsers;
            Console.WriteLine("Yeni User Yaradildi");
        }
        public string GetByID(int id)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i].Id == id)
                {
                    return _users[i].Name;
                }

            }
            Console.WriteLine("Bele biri yoxdu");
            return null;

        }
        public User[] GetAll()
        {
            return _users;
        }
        public void Delete(int id)
        {
            bool I = false;
            for(int i=0; i< _users.Length; i++)
            {
                if(_users[i].Id == id)
                {
                    I= true; 
                    User[]  newUSers= new User[_users.Length-1];
                    int f = 0;
                    for (int j = 0; j < _users.Length; j++) {
                        if (j == i)//tapilani kecmek ucun
                        {
                            continue;
                        }
                        newUSers[f++] = _users[j];
                    
                    }
                    _users = newUSers;
                    Console.WriteLine($"ID si {id} olan silindi");
                    break;
                }
            }
            if (!I)
            {
                Console.WriteLine("Bele ID yoxdu onsuzda ");
            }
        }
    }
}
