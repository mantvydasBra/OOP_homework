
namespace skirtaUzduotis
{
    partial class frmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.btn_LogOutAdmin = new System.Windows.Forms.Button();
            this.lbox_naudotojai = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_addNewUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LogOutAdmin
            // 
            this.btn_LogOutAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LogOutAdmin.Location = new System.Drawing.Point(283, 274);
            this.btn_LogOutAdmin.Name = "btn_LogOutAdmin";
            this.btn_LogOutAdmin.Size = new System.Drawing.Size(107, 38);
            this.btn_LogOutAdmin.TabIndex = 1;
            this.btn_LogOutAdmin.Text = "Log Out";
            this.btn_LogOutAdmin.UseVisualStyleBackColor = true;
            this.btn_LogOutAdmin.Click += new System.EventHandler(this.btn_LogOutAdmin_Click);
            // 
            // lbox_naudotojai
            // 
            this.lbox_naudotojai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_naudotojai.FormattingEnabled = true;
            this.lbox_naudotojai.ItemHeight = 16;
            this.lbox_naudotojai.Location = new System.Drawing.Point(12, 36);
            this.lbox_naudotojai.Name = "lbox_naudotojai";
            this.lbox_naudotojai.ScrollAlwaysVisible = true;
            this.lbox_naudotojai.Size = new System.Drawing.Size(187, 276);
            this.lbox_naudotojai.TabIndex = 2;
            this.lbox_naudotojai.DoubleClick += new System.EventHandler(this.lbox_naudotojai_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naudotojų sąrašas";
            // 
            // bt_addNewUser
            // 
            this.bt_addNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_addNewUser.Location = new System.Drawing.Point(256, 36);
            this.bt_addNewUser.Name = "bt_addNewUser";
            this.bt_addNewUser.Size = new System.Drawing.Size(134, 51);
            this.bt_addNewUser.TabIndex = 4;
            this.bt_addNewUser.Text = "Pridėti naują moksleivį";
            this.bt_addNewUser.UseVisualStyleBackColor = true;
            this.bt_addNewUser.Click += new System.EventHandler(this.bt_addNewUser_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 338);
            this.Controls.Add(this.bt_addNewUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbox_naudotojai);
            this.Controls.Add(this.btn_LogOutAdmin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdmin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LogOutAdmin;
        private System.Windows.Forms.ListBox lbox_naudotojai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_addNewUser;
    }
}