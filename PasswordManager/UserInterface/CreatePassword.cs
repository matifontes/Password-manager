using System;
using System.Windows.Forms;

namespace UserInterface
{
    public delegate void HandlePasswordSuggest();
    public delegate void HandlePasswordCreation();
    public partial class CreatePassword : UserControl
    {
        private event HandlePasswordCreation CreatePasswordEvent;
        private event HandlePasswordSuggest SuggestPasswordImprovementEvent; 
        public CreatePassword()
        {
            InitializeComponent();
        }

        public void AddListener(HandlePasswordCreation del) 
        {
            CreatePasswordEvent += del;
        }

        /*public void AddListener(HandlePasswordSuggest del)
        {
            SuggestPasswordImprovementEvent += del;
        }*/
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreatePasswordEvent();
            SuggestPasswordImprovementEvent();
        }
    }
}
