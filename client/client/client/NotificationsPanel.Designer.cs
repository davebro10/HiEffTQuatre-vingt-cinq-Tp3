namespace client
{
    partial class NotificationsPanel
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.NotificationsListView = new System.Windows.Forms.ListView();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.DeclineButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.Groupe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Admin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // NotificationsListView
            // 
            this.NotificationsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Groupe,
            this.Admin});
            this.NotificationsListView.Location = new System.Drawing.Point(14, 14);
            this.NotificationsListView.Name = "NotificationsListView";
            this.NotificationsListView.Size = new System.Drawing.Size(354, 209);
            this.NotificationsListView.TabIndex = 0;
            this.NotificationsListView.UseCompatibleStateImageBehavior = false;
            this.NotificationsListView.View = System.Windows.Forms.View.Details;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(58, 239);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 1;
            this.AcceptButton.Text = "Accepter";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_ClickAsync);
            // 
            // DeclineButton
            // 
            this.DeclineButton.Location = new System.Drawing.Point(150, 239);
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.Size = new System.Drawing.Size(75, 23);
            this.DeclineButton.TabIndex = 2;
            this.DeclineButton.Text = "Refuser";
            this.DeclineButton.UseVisualStyleBackColor = true;
            this.DeclineButton.Click += new System.EventHandler(this.DeclineButton_ClickAsync);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(240, 239);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Retour";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Groupe
            // 
            this.Groupe.Text = "Groupe";
            // 
            // Admin
            // 
            this.Admin.Text = "Admin";
            // 
            // NotificationsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.NotificationsListView);
            this.Name = "NotificationsPanel";
            this.Size = new System.Drawing.Size(384, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView NotificationsListView;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button DeclineButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ColumnHeader Groupe;
        private System.Windows.Forms.ColumnHeader Admin;
    }
}
