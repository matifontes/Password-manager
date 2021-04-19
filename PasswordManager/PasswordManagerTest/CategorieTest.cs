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
            Category personal = new Category(name);
            Assert.IsNotNull(personal);
        }
    }
}
