using System;
using System.Drawing;
using System.Windows.Forms;

namespace NatyBeauty.UI
{
    public partial class CustomDialog : Form
    {
        /// <summary>
        /// Custom Dialog to be used as Popup.
        /// </summary>
        /// <param name="caller">Current Form that is opening the Popup Window.</param>
        /// <param name="buttonType">Type of MessageBoxButtons to be used. Can be: YesNo or OK.</param>
        /// <param name="textMessage">Message that will show up into the Popup.</param>
        public CustomDialog(Form caller, MessageBoxButtons buttonType, string textMessage)
        {
            InitializeComponent();

            this.lblMessage.Text = textMessage;

            if (lblMessage.Width > 320)
                this.Width = lblMessage.Width + 40;

            panelBack.Width = this.Width - 16;
            picLogo.Width = panelBack.Width - 74;

            this.lblMessage.Left = (ClientSize.Width - lblMessage.Width) / 2;
            this.panelButtons.Left = (ClientSize.Width - panelButtons.Width) / 2;

            int width = (caller.Width - this.Width) / 2;
            int height = (caller.Height - this.Height) / 2;

            Point point = new Point(caller.Left + width, caller.Top + height);

            this.Location = point;
            this.StartPosition = FormStartPosition.Manual;

            switch(buttonType)
            {
                case MessageBoxButtons.YesNo:
                    btnYes.Text = "Yes";
                    btnNo.Text = "No";
                    break;
                case MessageBoxButtons.OK:
                    btnNo.Text = "Ok";
                    btnYes.Visible = false;
                    this.btnNo.Left = (panelButtons.Width - btnNo.Width) / 2;
                    break;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
