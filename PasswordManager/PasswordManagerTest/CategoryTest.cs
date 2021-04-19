using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CreateCategory()
        {
            string name = "Personal";
            Category personal = new Category(name);
            Assert.IsNotNull(personal);
        }
    }
}
