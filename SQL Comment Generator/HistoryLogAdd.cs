using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Comment_Generator
{
    public partial class HistoryLogAdd : Form
    {
        public string UpdatedDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public HistoryLogAdd(string DefaultAuthor = "")
        {
            InitializeComponent();
            
            txtAuthor.Text = DefaultAuthor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtAuthor.Text.Length > 0 && txtDescription.Text.Length > 0)
            {
                UpdatedDate = datUpdatedDate.Value.ToShortDateString();
                Author = txtAuthor.Text;
                Description = txtDescription.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
