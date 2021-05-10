using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class CreateModifyCategory : Form
    {
        private event HandleModification PostModified;
        private CategoriesController categories;
        private Category category;
        public CreateModifyCategory(CategoriesController categories, HandleModification del)
        {
            InitializeComponent();
            this.categories = categories;
            PostModified += del;
            CreateCategoryPanel();
        }

        public CreateModifyCategory(CategoriesController categories, Category category, HandleModification del)
        {
            InitializeComponent();
            this.categories = categories;
            this.category = category;
            PostModified += del;
            CreateModifyPanel();
        }

        private void CreateCategoryPanel() 
        {
            CreateCategory createCategoryPanel = new CreateCategory(categories);
            createCategoryPanel.AddListener(PostModified);
            optionPanel.Controls.Add(createCategoryPanel);
            ReSizeForm(createCategoryPanel.Width,createCategoryPanel.Height);
        }

        private void CreateModifyPanel() 
        {
            ModifyCategory modifyCategoryPanel = new ModifyCategory(category);
            modifyCategoryPanel.AddListener(PostModified);
            optionPanel.Controls.Add(modifyCategoryPanel);
            ReSizeForm(modifyCategoryPanel.Width, modifyCategoryPanel.Height);
        }

        private void ReSizeForm(int width, int height) 
        {
            int BORDER_MARGIN = 20;
            optionPanel.Size = new Size(width, height);
            this.Size = new Size(width + BORDER_MARGIN, height + BORDER_MARGIN);
        }
    }
}
