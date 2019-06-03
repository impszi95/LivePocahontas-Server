// <copyright file="ConsoleWithInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Database.DataLayer.Structures;
    using Logic;

    /// <summary>
    /// The show the working program
    /// </summary>
    public static class ConsoleWithInput
    {
        /// <summary>
        /// Handle all the method calls
        /// </summary>
        public static void HandeCalls()
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

        /// <summary>
        /// Structure s, logic
        /// </summary>
        private static void RegistrateNewUser(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Registrate a new user!");
            Console.WriteLine("Type the name of the user:");
            string name = Console.ReadLine();
            Console.WriteLine("Type the password of the user:");
            string password = Console.ReadLine();
            logic.UserManagement.Registration(name, password);
            Console.WriteLine("Give him some credit (new users start with 500)");
            Console.WriteLine("Quantity of credits:");
            int credit = int.Parse(Console.ReadLine());
            logic.UserManagement.AddCredit(0, credit);

            List<User> users = logic.UserManagement.Users.ToList();
            User user = users.First();

            Console.WriteLine("User details : ID: {0} Name: {1} Credit: {2}", user.Id, user.Name, user.Credit);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void CreateContent(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Create a new content for your user!");
            Console.WriteLine("Type the title of the content:");
            string title = Console.ReadLine();
            Console.WriteLine("Type the text of the content:");
            string text = Console.ReadLine();

            User user = logic.UserManagement.Users.ToList().First();
            logic.ContentManagement.CreateContent(title, text, (int)user.Id);
            List<Content> contents = logic.ContentManagement.Contents.ToList();
            Content content = contents.First();
            Console.WriteLine("Your new content:");
            Console.WriteLine("{0} - {1}\n{2}\n", content.User.username, content.Name, content.File);

            Console.ReadKey();
        }

        /// <summary>
        /// Structure s
        /// </summary>
        private static void CreateAnotherUserWithContent(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Create another user with one content!");
            Console.WriteLine("Type the name of the user:");
            string name = Console.ReadLine();
            Console.WriteLine("Type the password of the user:");
            string password = Console.ReadLine();

            logic.UserManagement.Registration(name, password);

            User user = logic.UserManagement.Users.ToList().Find(x => x.Name == name);

            Console.WriteLine("Type the title of the content:");
            string title = Console.ReadLine();
            Console.WriteLine("Type the text of the content:");
            string text = Console.ReadLine();
            logic.ContentManagement.CreateContent(title, text, (int)user.Id);
        }

        /// <summary>
        /// Structure s
        /// </summary>
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

        /// <summary>
        /// Structure s
        /// </summary>
        private static void SendGift(LogicClass logic)
        {
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine("Send some gift to the second user!");
            Console.WriteLine("Quantity of sending credits (must be smaller than yours, 500):");
            int credit = int.Parse(Console.ReadLine());

            logic.AnalyticsManagement.SendGift(1, 0, 1, credit);

            Analytic analytic = logic.AnalyticsManagement.GetAnalyticsForUser(1).ToList().First();

            Console.WriteLine("Data of the analytic:");
            Console.WriteLine("Owner: {0}\nBuyer: {1}\nContent title: {2}\nCredit: {3}\nTimestamp: {4}", analytic.Owner.username, analytic.Buyer.username, analytic.Content.name, analytic.Credit, analytic.Timestamp);
        }
    }
}
