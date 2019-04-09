namespace client
{
    partial class GroupPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AdminNameLabel = new System.Windows.Forms.Label();
            this.MemberListBox = new System.Windows.Forms.ListBox();
            this.MembersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PromoteAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveMember = new System.Windows.Forms.ToolStripMenuItem();
            this.FileListView = new System.Windows.Forms.ListView();
            this.InviteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.Return = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.MembersContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminNameLabel
            // 
            this.AdminNameLabel.AutoSize = true;
            this.AdminNameLabel.Location = new System.Drawing.Point(88, 21);
            this.AdminNameLabel.Name = "AdminNameLabel";
            this.AdminNameLabel.Size = new System.Drawing.Size(64, 13);
            this.AdminNameLabel.TabIndex = 1;
            this.AdminNameLabel.Text = "AdminName";
            // 
            // MemberListBox
            // 
            this.MemberListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemberListBox.ContextMenuStrip = this.MembersContextMenu;
            this.MemberListBox.FormattingEnabled = true;
            this.MemberListBox.Location = new System.Drawing.Point(334, 37);
            this.MemberListBox.Name = "MemberListBox";
            this.MemberListBox.Size = new System.Drawing.Size(120, 394);
            this.MemberListBox.TabIndex = 2;
            // 
            // MembersContextMenu
            // 
            this.MembersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PromoteAdmin,
            this.RemoveMember});
            this.MembersContextMenu.Name = "MembersContextMenu";
            this.MembersContextMenu.Size = new System.Drawing.Size(220, 48);
            // 
            // PromoteAdmin
            // 
            this.PromoteAdmin.Name = "PromoteAdmin";
            this.PromoteAdmin.Size = new System.Drawing.Size(219, 22);
            this.PromoteAdmin.Text = "Promouvoir Administrateur";
            this.PromoteAdmin.Click += new System.EventHandler(this.PromoteAdmin_Click);
            // 
            // RemoveMember
            // 
            this.RemoveMember.Name = "RemoveMember";
            this.RemoveMember.Size = new System.Drawing.Size(219, 22);
            this.RemoveMember.Text = "Retirer du groupe";
            this.RemoveMember.Click += new System.EventHandler(this.RemoveMember_Click);
            // 
            // FileListView
            // 
            this.FileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileListView.Location = new System.Drawing.Point(6, 37);
            this.FileListView.MultiSelect = false;
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(322, 394);
            this.FileListView.TabIndex = 3;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.View = System.Windows.Forms.View.Details;
            // 
            // InviteButton
            // 
            this.InviteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InviteButton.Location = new System.Drawing.Point(358, 440);
            this.InviteButton.Name = "InviteButton";
            this.InviteButton.Size = new System.Drawing.Size(75, 23);
            this.InviteButton.TabIndex = 7;
            this.InviteButton.Text = "Inviter";
            this.InviteButton.UseVisualStyleBackColor = true;
            this.InviteButton.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administrateur :";
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupNameLabel.Location = new System.Drawing.Point(3, 0);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(136, 16);
            this.GroupNameLabel.TabIndex = 8;
            this.GroupNameLabel.Text = "NOM DU GROUPE";
            // 
            // Return
            // 
            this.Return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Return.Location = new System.Drawing.Point(7, 440);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(75, 23);
            this.Return.TabIndex = 12;
            this.Return.Text = "Retour";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.Location = new System.Drawing.Point(88, 440);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(75, 23);
            this.Supprimer.TabIndex = 13;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.UseVisualStyleBackColor = true;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // GroupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.GroupNameLabel);
            this.Controls.Add(this.InviteButton);
            this.Controls.Add(this.FileListView);
            this.Controls.Add(this.MemberListBox);
            this.Controls.Add(this.AdminNameLabel);
            this.Controls.Add(this.label2);
            this.Name = "GroupPanel";
            this.Size = new System.Drawing.Size(457, 466);
            this.MembersContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label AdminNameLabel;
        private System.Windows.Forms.ListBox MemberListBox;
        private System.Windows.Forms.ListView FileListView;
        private System.Windows.Forms.Button InviteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.ContextMenuStrip MembersContextMenu;
        private System.Windows.Forms.ToolStripMenuItem PromoteAdmin;
        private System.Windows.Forms.ToolStripMenuItem RemoveMember;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Button Supprimer;
    }
}
