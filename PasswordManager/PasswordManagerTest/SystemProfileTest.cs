﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class SystemProfileTest
    {
        private SystemProfile systemProfile;
        private SystemProfile systemProfileWithSpecialCharactersOnPassword;
        private string validPassword = "admin";
        private string specialCharacterPsw = "3123#@@12";
        private Category category;

        [TestInitialize]
        public void Setup()
        {
            systemProfile = new PasswordManager.SystemProfile(validPassword);
            systemProfileWithSpecialCharactersOnPassword = new PasswordManager.SystemProfile(specialCharacterPsw);
            category = new Category("Work");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            systemProfile = null;
            systemProfileWithSpecialCharactersOnPassword = null;
            category = null;
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(systemProfile);
        }

        [TestMethod]
        public void ValidatePasswordParameterOnUserCreation()
        {
            Assert.AreEqual(systemProfile.SystemPassword, validPassword);
        }

        [TestMethod]
        public void CreateUserWithAPasswordUsingSpecialCharacters() 
        {
            Assert.AreEqual(systemProfileWithSpecialCharactersOnPassword.SystemPassword, specialCharacterPsw);
        }

        [TestMethod]
        public void LoginWithValidPassword()
        {
            Assert.IsTrue(systemProfile.Login(validPassword));
        }

        [TestMethod]
        public void LoginWithIncorrectPassword() 
        {
            string invalidPassword = "";
            const int STRING_LENGHT = 12;

            for (int count = 0; count <= STRING_LENGHT; count++) 
            {
                invalidPassword += "A";
            }

            Assert.IsFalse(systemProfile.Login(invalidPassword));
        }

        [TestMethod]
        public void LoginHavingAPasswordWithSpecialSimbols() 
        {
            Assert.IsTrue(systemProfileWithSpecialCharactersOnPassword.Login(specialCharacterPsw));       
        }

        [TestMethod]
        public void AddedNewCategoryExists() 
        {
            systemProfile.AddCategory(category);
            bool wasAdded = systemProfile.CategoryExists(category);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void CategoryThatWasntAddedDoesNotExists() 
        {
            Assert.IsFalse(systemProfile.CategoryExists(category));
        }
        [TestMethod]
        public void AddedNewPasswordExists()
        {
            string pass = "admin";
            string site = "aulas.ort.edu.uy";
            string user = "Ralph";
            string note = "";
            Password password = new Password(category, pass, site, user, note);
            systemProfile.AddPassword(password);
            bool wasAdded = systemProfile.PasswordExists(pass);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void PasswordThatWasntAddedDoesNotExists()
        {
            string pass = "user123";
            string site = "aulas.ort.edu.uy";
            string user = "Liza";
            string note = "";
            Password password = new Password(category, pass, site, user, note);
            Assert.IsFalse(systemProfile.PasswordExists(pass));
        }

        [TestMethod]
        public void AddedNewCreditCardExists()
        {
            string name = "Visa Gold";
            string type = "Visa";
            long creditCardNumber = 2323321323212321;
            short ccvCode = 080;
            DateTime expDate = new DateTime(2021, 5, 1);
            string note = "Limit 15K";
            CreditCard card = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            systemProfile.AddCreditCard(card);
            bool wasAdded = systemProfile.CreditCardExists(creditCardNumber);
            Assert.IsTrue(wasAdded);
        }

    }
}
