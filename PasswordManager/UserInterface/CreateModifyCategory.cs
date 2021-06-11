using System;
using System.Drawing;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class CreateModifyCategory : Form
    {
        private event HandleModification PostModified;
        private CategoryRepository categories;
        private ProfileController profile;
        private Category category;
        public CreateModifyCategory(CategoryRepository categories, ProfileController profile, HandleModification PostModified)
        {
            InitializeComponent();
            this.categories = categories;
            this.profile = profile;
            this.PostModified += PostModified;
            CreateCategoryPanel();
        }

        public CreateModifyCategory(CategoryRepository categories, Category category , ProfileController profile, HandleModification PostModified)
        {
            InitializeComponent();
            this.categories = categories;
            this.category = category;
            this.profile = profile;
            this.PostModified += PostModified;
            CreateModifyPanel();
        }

        private void CreateCategoryPanel() 
        {
            CreateCategory createCategoryPanel = new CreateCategory(categories, this.profile);
            createCategoryPanel.AddListener(PostModified);
            optionPanel.Controls.Add(createCategoryPanel);
            ReSizeForm(createCategoryPanel.Width,createCategoryPanel.Height);
        }

        private void CreateModifyPanel() 
        {
            ModifyCategory modifyCategoryPanel = new ModifyCategory(category, this.categories);
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
