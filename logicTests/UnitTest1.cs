// <copyright file="UnitTest1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LogicTests
{
    using System.Collections.Generic;
    using Database.DataLayer;
    using Database.DataLayer.Structures;
    using Logic;
    using NUnit.Framework;

    [TestFixture]

    /// <summary>
    /// Structure s
    /// </summary>
    public class UnitTest1
    {
        /// <summary>
        /// Structure s
        /// </summary>
        private LogicClass l = new LogicClass();
      private Repo r = new Repo();

        /// <summary>
        /// Structure s
        /// </summary>
        private List<User> userLista;
        private List<Content> contentLista;

      [SetUp]
        public void Init()
        {
          this.l = new LogicClass();
         this.r = new Repo();
         this.userLista = new List<User>();
         this.contentLista = new List<Content>();
         this.l.UserManagement.Registration("Teszt", "jelszo");
        }

        [Test]
        public void CreatingUser()
        {
            User ujuser = new User();
            ujuser.Id = 999;
            ujuser.Name = "Béla";
            Assert.That(ujuser.Id, Is.EqualTo(999));
            Assert.That(ujuser.Name, Is.EqualTo("Béla"));
        }
        [Test]
        public void Registrate()
        {
            this.userLista = (List<User>)this.r.UserRepo.GetAllUsers();
            Assert.That(this.userLista.Count, Is.Not.Null);
        }

        [Test]
        public void AddCredit()
        {
            this.l.UserManagement.AddCredit(0, 500);
            this.userLista = (List<User>)this.r.UserRepo.GetAllUsers();
            User user = this.userLista.Find(x => x.Id == 0);
            Assert.That(user.Credit, Is.EqualTo(1000));
        }

        [Test]
        public void CreateContent()
        {
            this.l.ContentManagement.CreateContent("Teszt", "Content", 0);
            this.contentLista = (List<Content>)this.r.ContentRepo.GetAllContents();
            Content content = this.contentLista.Find(x => x.User.uniqueID == 0);
            Assert.That(content.Name, Is.EqualTo("Teszt"));
            Assert.That(content.File, Is.EqualTo("Content"));
        }

        [Test]
        public void SendGift()
            {
            this.l.UserManagement.Registration("Teszt2", "password");
            this.userLista = (List<User>)this.r.UserRepo.GetAllUsers();
            int teszt1Credits = this.userLista.Find(x => x.Id == 0).Credit;
            int teszt2Credits = this.userLista.Find(x => x.Id == 1).Credit;
            this.l.ContentManagement.CreateContent("Teszt", "Content", 0);
            this.l.AnalyticsManagement.SendGift(1, 0, 0, 500);
            this.userLista = (List<User>)this.r.UserRepo.GetAllUsers();
            Assert.That(teszt1Credits - 500, Is.EqualTo(this.userLista.Find(x => x.Id == 0).Credit));
            Assert.That(teszt2Credits + 500, Is.EqualTo(this.userLista.Find(x => x.Id == 1).Credit));
        }

        [Test]
        public void WrongPassword()
        {
           bool registrated = this.l.UserManagement.IsRegistrated("Teszt", "rosszjelszo");
            Assert.That(registrated, Is.EqualTo(false));
        }

        [Test]
        /// <summary>
        /// Structure s
        /// </summary>
        public void GoodPassword()
        {
            string name = "Béla";
            string password = "jelszo";
            this.l.UserManagement.Registration(name, password);
            bool registrated = this.l.UserManagement.IsRegistrated(name, password);
            Assert.That(registrated, Is.EqualTo(true));
        }

        [Test]
        /// <summary>
        /// Structure s
        /// </summary>
        public void NotEnoughMoney()
        {
            this.l.UserManagement.Registration("Teszt2", "password");
            this.userLista = (List<User>)this.r.UserRepo.GetAllUsers();
            this.l.ContentManagement.CreateContent("Teszt", "Content", 0);
            int teszt1Credits = this.userLista.Find(x => x.Id == 0).Credit;
            int teszt2Credits = this.userLista.Find(x => x.Id == 1).Credit;
            this.l.AnalyticsManagement.SendGift(1, 0, 0, 5000);
            this.userLista = (List<User>)this.r.UserRepo.GetAllUsers();
            Assert.That(teszt1Credits, Is.EqualTo(this.userLista.Find(x => x.Id == 0).Credit));
            Assert.That(teszt2Credits, Is.EqualTo(this.userLista.Find(x => x.Id == 1).Credit));
        }
    }
}
