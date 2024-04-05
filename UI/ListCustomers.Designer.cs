namespace NatyBeauty.UI
{
    partial class ListCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDeleteMessage = new System.Windows.Forms.Label();
            this.lblEditMessage = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeleteMessage
            // 
            this.lblDeleteMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeleteMessage.AutoSize = true;
            this.lblDeleteMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDeleteMessage.Location = new System.Drawing.Point(663, 625);
            this.lblDeleteMessage.Name = "lblDeleteMessage";
            this.lblDeleteMessage.Size = new System.Drawing.Size(230, 13);
            this.lblDeleteMessage.TabIndex = 21;
            this.lblDeleteMessage.Text = "You must select a row into the table to delete it.";
            this.lblDeleteMessage.Visible = false;
            // 
            // lblEditMessage
            // 
            this.lblEditMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEditMessage.AutoSize = true;
            this.lblEditMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEditMessage.Location = new System.Drawing.Point(278, 625);
            this.lblEditMessage.Name = "lblEditMessage";
            this.lblEditMessage.Size = new System.Drawing.Size(218, 13);
            this.lblEditMessage.TabIndex = 20;
            this.lblEditMessage.Text = "You must select a row into the table to edit it.";
            this.lblEditMessage.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(137)))), ((int)(((byte)(151)))));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(786, 584);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 38);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(137)))), ((int)(((byte)(151)))));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(171, 584);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 38);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(137)))), ((int)(((byte)(151)))));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(279, 584);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 38);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gridCustomers
            // 
            this.gridCustomers.AllowUserToAddRows = false;
            this.gridCustomers.AllowUserToDeleteRows = false;
            this.gridCustomers.AllowUserToOrderColumns = true;
            this.gridCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCustomers.BackgroundColor = System.Drawing.Color.White;
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridCustomers.Location = new System.Drawing.Point(171, 164);
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.ReadOnly = true;
            this.gridCustomers.Size = new System.Drawing.Size(710, 382);
            this.gridCustomers.TabIndex = 16;
            // 
            // ListCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1051, 698);
            this.Controls.Add(this.lblDeleteMessage);
            this.Controls.Add(this.lblEditMessage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.gridCustomers);
            this.Name = "ListCustomers";
            this.Load += new System.EventHandler(this.ListCustomers_Load);
            this.Controls.SetChildIndex(this.gridCustomers, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.lblEditMessage, 0);
            this.Controls.SetChildIndex(this.lblDeleteMessage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeleteMessage;
        private System.Windows.Forms.Label lblEditMessage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView gridCustomers;
    }
}
