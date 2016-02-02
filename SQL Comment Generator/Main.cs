using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SQL_Comment_Generator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void txtCreatedBy_TextChanged(object sender, EventArgs e)
        {
            GenerateComments();

            if (lvwHistory.Items.Count > 0)
            {
                if(lvwHistory.Items[0].SubItems[2].Text == "Initial Creation")
                {
                    lvwHistory.Items[0].SubItems[1].Text = txtCreatedBy.Text;
                    lvwHistory.Items[0].Text = DateTime.Today.ToShortDateString();
                }
            }
        }

        private void txtPurpose_TextChanged(object sender, EventArgs e)
        {
            GenerateComments();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            GenerateComments();
        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {
            GenerateComments();
        }

        private void txtInputValues_TextChanged(object sender, EventArgs e)
        {
            GenerateComments();
        }

        private void txtOutputValues_TextChanged(object sender, EventArgs e)
        {
            GenerateComments();
        }

        private void GenerateComments()
        {
            StringBuilder Comments = new StringBuilder();

            Comments.AppendLine("/**************************************************************************************");
            Comments.AppendLine();
            Comments.AppendLine("  Created By:  	" + txtCreatedBy.Text);
            Comments.AppendLine("  Purpose:     	" + txtPurpose.Text);
            Comments.AppendLine("  File:			" + txtFileName.Text);
            Comments.AppendLine("  Version:      " + txtVersion.Text);
            Comments.AppendLine();
            Comments.AppendLine("  Input Values:");
            Comments.AppendLine(GetSpacedInputValues(txtInputValues.Text));
            Comments.AppendLine("  Output Values:");
            Comments.AppendLine(GetSpacedInputValues(txtOutputValues.Text));
            Comments.AppendLine("  Addl Notes:  ");
            Comments.AppendLine(GetSpacedInputValues(txtAdditionalNotes.Text));
            Comments.AppendLine("  History:");
            Comments.AppendLine("  Date			Author				Description");
            Comments.AppendLine("  ----------	------------------	---------------------------------------------------------");
            Comments.AppendLine("  10/21/2014    Larry Wang          Initial Creation");
            Comments.AppendLine("  11/12/2014    Mike Young          Updated formating and output");
            Comments.AppendLine("  11/24/2014    Mike Young          Updated counts to include child gids first");
            Comments.AppendLine();
            Comments.AppendLine("*********************************************************************************************/");

            txtComments.Text = Comments.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateComments();

            if (lvwHistory.Items.Count > 0)
            {
                if (lvwHistory.Items[0].SubItems[2].Text == "Initial Creation")
                {
                    lvwHistory.Items[0].SubItems[1].Text = txtCreatedBy.Text;
                    lvwHistory.Items[0].Text = DateTime.Today.ToShortDateString();
                }
            }
        }

        private string GetSpacedInputValues(string Value)
        {
            StringBuilder tmpInputs = new StringBuilder();

            using (StringReader reader = new StringReader(Value))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tmpInputs.AppendLine("			    " + line);
                }
            }

            return tmpInputs.ToString();
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtComments.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HistoryLogAdd History = new HistoryLogAdd();
            History.ShowDialog();

            if (History.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem NewItem = new ListViewItem();
                NewItem.Text = History.UpdatedDate;
                NewItem.SubItems.Add(History.Author);
                NewItem.SubItems.Add(History.Description);

                lvwHistory.Items.Add(NewItem);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        public void AddHistoryItem(string Date, string Author, string Description)
        {

        }



    }
}
