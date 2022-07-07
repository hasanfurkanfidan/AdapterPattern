using System;

namespace AdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new UserAnotherServiceAdapter());
            userManager.GetUsers();
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Projenin ana servisi
        /// </summary>
        class UserManager
        {
            IUserConnection _userConnection;
            public UserManager(IUserConnection userConnection)
            {
                _userConnection = userConnection;
            }
            public void GetUsers()
            {
                _userConnection.GetUsers();
            }
        }

        /// <summary>
        /// Kullanıcıları getirmek üzere çalışacak metodun imzası
        /// </summary>
        interface IUserConnection
        {
            void GetUsers();
        }

        /// <summary>
        /// Kullanıcıların db den geleceği fonksiyon
        /// </summary>
        class UserDbConnection : IUserConnection
        {
            public void GetUsers()
            {
                Console.Write("Users brought from db");
            }
        }

        /// <summary>
        /// Kullanıcıları getirirken farklı bir sisteme adapte olunacak kodların yazıldığı class
        /// </summary>
        class UserAnotherServiceAdapter : IUserConnection
        {
            AnotherService anotherService = new AnotherService();
            public void GetUsers()
            {
                anotherService.GetUsersFromAnotherService();
            }
        }

        /// <summary>
        /// Farklı sistem
        /// </summary>
        class AnotherService
        {
            public void GetUsersFromAnotherService()
            {
                Console.Write("Users brought from Another Service");
            }
        }
    }
}
