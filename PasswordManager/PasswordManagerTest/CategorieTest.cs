using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategorieTest
    {
        [TestMethod]
        public void CreateCategorie()
        {
            string name = "Personal";
            Categorie personal = new Categorie(name);
            Assert.IsNotNull(personal);
        }
    }
}
