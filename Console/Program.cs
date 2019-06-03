// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.DataLayer.Structures;
    using Logic;

    /// <summary>
    /// Class to demonstrate the application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Structure s
        /// </summary>
        private static void Main()
        {
            // HandeCalls();
            ConsoleWithInput.HandeCalls();
        }

        private static void HandeCalls()
        {
            using (LogicClass logic = new LogicClass())
            {
                RegistrateNewUser(logic);
                CreateContent(logic);
                CreateAnotherUserWithContent(logic);
                ListAllUsersAndContents(logic);
                SendGift(logic);
            }

            Console.ReadKey();
        }

        private static void RegistrateNewUser(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Registrate a new user!");
            logic.UserManagement.Registration("John Doe", "alma25");
            Console.WriteLine("John Doe is registered: {0}", logic.UserManagement.IsRegistrated("John Doe", "alma25"));

            Console.WriteLine("Give him some credit");
            logic.UserManagement.AddCredit(0, 500);

            List<User> users = logic.UserManagement.Users.ToList();
            User user = users.Find(x => x.Name == "John Doe");

            Console.WriteLine("User details : ID: {0} Name: {1} Credit: {2}", user.Id, user.Name, user.Credit);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void CreateContent(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Create a new content for John Doe!");

            User user = logic.UserManagement.Users.ToList().Find(x => x.Name == "John Doe");
            logic.ContentManagement.CreateContent("FirstTitle", "Very nice content text!!!", (int)user.Id);
            List<Content> contents = logic.ContentManagement.Contents.ToList();
            Content content = contents.First();
            Console.WriteLine("{0} - {1}\n{2}\n", content.User.username, content.Name, content.File);

            Console.ReadKey();
        }

        private static void CreateAnotherUserWithContent(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Create another user with one content!");

            logic.UserManagement.Registration("Jane Roe", "alma36");
            User user = logic.UserManagement.Users.ToList().Find(x => x.Name == "Jane Roe");
            logic.ContentManagement.CreateContent("Title", "I love to use this application!!", (int)user.Id);
        }

        private static void ListAllUsersAndContents(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("List all users and contents!");

            List<User> users = logic.UserManagement.Users.ToList();
            List<Content> contents = logic.ContentManagement.Contents.ToList();

            Console.WriteLine("/////////USERS//////////");
            foreach (User user in users)
            {
                Console.WriteLine("{0} - {1}\n", user.Id, user.Name);
            }

            Console.WriteLine("/////////CONTENS//////////");
            foreach (Content content in contents)
            {
                Console.WriteLine("{0} - {1}\n{2}\n", content.User.username, content.Name, content.File);
            }
        }

        private static void SendGift(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Jane Roe send gift to John Doe's content!");

            logic.AnalyticsManagement.SendGift(0, 1, 0, 250);

            Analytic analyticsForJohn = logic.AnalyticsManagement.GetAnalyticsForUser(0).ToList().First();

            Console.WriteLine("Owner: {0}\nBuyer: {1}\nContent title: {2}\nCredit: {3}\nTimestamp: {4}", analyticsForJohn.Owner.username, analyticsForJohn.Buyer.username, analyticsForJohn.Content.name, analyticsForJohn.Credit, analyticsForJohn.Timestamp);
        }
    }
}
