namespace client
{
    partial class HomePanel
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.GroupesLabel = new System.Windows.Forms.Label();
            this.GroupesListView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NomClientLabel = new System.Windows.Forms.Label();
            this.VoirGroupeButton = new System.Windows.Forms.Button();
            this.CreerButton = new System.Windows.Forms.Button();
            this.ClientsListView = new System.Windows.Forms.ListView();
            this.ClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Connecte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(22, 56);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Nom";
            // 
            // GroupesLabel
            // 
            this.GroupesLabel.AutoSize = true;
            this.GroupesLabel.Location = new System.Drawing.Point(22, 91);
            this.GroupesLabel.Name = "GroupesLabel";
            this.GroupesLabel.Size = new System.Drawing.Size(47, 13);
            this.GroupesLabel.TabIndex = 1;
            this.GroupesLabel.Text = "Groupes";
            // 
            // GroupesListView
            // 
            this.GroupesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nom});
            this.GroupesListView.Location = new System.Drawing.Point(25, 114);
            this.GroupesListView.MultiSelect = false;
            this.GroupesListView.Name = "GroupesListView";
            this.GroupesListView.Size = new System.Drawing.Size(279, 213);
            this.GroupesListView.TabIndex = 2;
            this.GroupesListView.UseCompatibleStateImageBehavior = false;
            this.GroupesListView.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            // 
            // NomClientLabel
            // 
            this.NomClientLabel.AutoSize = true;
            this.NomClientLabel.Location = new System.Drawing.Point(57, 56);
            this.NomClientLabel.Name = "NomClientLabel";
            this.NomClientLabel.Size = new System.Drawing.Size(124, 13);
            this.NomClientLabel.TabIndex = 3;
            this.NomClientLabel.Text = "(Insérer nom du client ici)";
            // 
            // VoirGroupeButton
            // 
            this.VoirGroupeButton.Location = new System.Drawing.Point(148, 340);
            this.VoirGroupeButton.Name = "VoirGroupeButton";
            this.VoirGroupeButton.Size = new System.Drawing.Size(75, 23);
            this.VoirGroupeButton.TabIndex = 4;
            this.VoirGroupeButton.Text = "Voir";
            this.VoirGroupeButton.UseVisualStyleBackColor = true;
            this.VoirGroupeButton.Click += new System.EventHandler(this.VoirGroupeButton_Click);
            // 
            // CreerButton
            // 
            this.CreerButton.Location = new System.Drawing.Point(229, 340);
            this.CreerButton.Name = "CreerButton";
            this.CreerButton.Size = new System.Drawing.Size(75, 23);
            this.CreerButton.TabIndex = 5;
            this.CreerButton.Text = "Créer";
            this.CreerButton.UseVisualStyleBackColor = true;
            this.CreerButton.Click += new System.EventHandler(this.CreerButton_ClickAsync);
            // 
            // ClientsListView
            // 
            this.ClientsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientName,
            this.Connecte});
            this.ClientsListView.Location = new System.Drawing.Point(342, 41);
            this.ClientsListView.MultiSelect = false;
            this.ClientsListView.Name = "ClientsListView";
            this.ClientsListView.Size = new System.Drawing.Size(155, 322);
            this.ClientsListView.TabIndex = 6;
            this.ClientsListView.UseCompatibleStateImageBehavior = false;
            this.ClientsListView.View = System.Windows.Forms.View.Details;
            this.ClientsListView.SelectedIndexChanged += new System.EventHandler(this.ClientsListView_SelectedIndexChanged);
            // 
            // ClientName
            // 
            this.ClientName.Text = "Nom";
            this.ClientName.Width = 80;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupeToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupeToolStripMenuItem
            // 
            this.groupeToolStripMenuItem.Name = "groupeToolStripMenuItem";
            this.groupeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.groupeToolStripMenuItem.Text = "Groupe";
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // Connecte
            // 
            this.Connecte.Text = "Connecté?";
            this.Connecte.Width = 70;
            // 
            // HomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClientsListView);
            this.Controls.Add(this.CreerButton);
            this.Controls.Add(this.VoirGroupeButton);
            this.Controls.Add(this.NomClientLabel);
            this.Controls.Add(this.GroupesListView);
            this.Controls.Add(this.GroupesLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "HomePanel";
            this.Size = new System.Drawing.Size(514, 388);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GroupesLabel;
        private System.Windows.Forms.ListView GroupesListView;
        private System.Windows.Forms.Label NomClientLabel;
        private System.Windows.Forms.Button VoirGroupeButton;
        private System.Windows.Forms.Button CreerButton;
        private System.Windows.Forms.ListView ClientsListView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem groupeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ColumnHeader ClientName;
        private System.Windows.Forms.ColumnHeader Connecte;
    }
}
