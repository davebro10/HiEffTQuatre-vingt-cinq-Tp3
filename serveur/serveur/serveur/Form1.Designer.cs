namespace serveur
{
    partial class frmMain
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsbLog = new System.Windows.Forms.ListBox();
            this.lblLogs = new System.Windows.Forms.Label();
            this.btnAjouterClient = new System.Windows.Forms.Button();
            this.btnSupprimerClient = new System.Windows.Forms.Button();
            this.btnCreerGroupe = new System.Windows.Forms.Button();
            this.btnAjoutClientGroupe = new System.Windows.Forms.Button();
            this.btnInviterClientGroupe = new System.Windows.Forms.Button();
            this.btnModifierClient = new System.Windows.Forms.Button();
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.lblDgvClient = new System.Windows.Forms.Label();
            this.lblDgvGroupe = new System.Windows.Forms.Label();
            this.dataGridViewGroupe = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccepterInvitation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEnleverGroupe = new System.Windows.Forms.Button();
            this.lblDgvInvitation = new System.Windows.Forms.Label();
            this.dataGridViewInvitation = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupe)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvitation)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbLog
            // 
            this.lsbLog.FormattingEnabled = true;
            this.lsbLog.Location = new System.Drawing.Point(12, 38);
            this.lsbLog.Name = "lsbLog";
            this.lsbLog.Size = new System.Drawing.Size(253, 472);
            this.lsbLog.TabIndex = 0;
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogs.Location = new System.Drawing.Point(12, 12);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(122, 20);
            this.lblLogs.TabIndex = 2;
            this.lblLogs.Text = "Logs du serveur";
            // 
            // btnAjouterClient
            // 
            this.btnAjouterClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterClient.Location = new System.Drawing.Point(297, 34);
            this.btnAjouterClient.Name = "btnAjouterClient";
            this.btnAjouterClient.Size = new System.Drawing.Size(152, 23);
            this.btnAjouterClient.TabIndex = 3;
            this.btnAjouterClient.Text = "Ajouter Client";
            this.btnAjouterClient.UseVisualStyleBackColor = true;
            this.btnAjouterClient.Click += new System.EventHandler(this.btnAjouterClient_Click);
            // 
            // btnSupprimerClient
            // 
            this.btnSupprimerClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerClient.Location = new System.Drawing.Point(297, 89);
            this.btnSupprimerClient.Name = "btnSupprimerClient";
            this.btnSupprimerClient.Size = new System.Drawing.Size(152, 23);
            this.btnSupprimerClient.TabIndex = 4;
            this.btnSupprimerClient.Text = "Supprimer Client";
            this.btnSupprimerClient.UseVisualStyleBackColor = true;
            // 
            // btnCreerGroupe
            // 
            this.btnCreerGroupe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreerGroupe.Location = new System.Drawing.Point(297, 228);
            this.btnCreerGroupe.Name = "btnCreerGroupe";
            this.btnCreerGroupe.Size = new System.Drawing.Size(152, 23);
            this.btnCreerGroupe.TabIndex = 5;
            this.btnCreerGroupe.Text = "Créer Groupe";
            this.btnCreerGroupe.UseVisualStyleBackColor = true;
            // 
            // btnAjoutClientGroupe
            // 
            this.btnAjoutClientGroupe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutClientGroupe.Location = new System.Drawing.Point(703, 34);
            this.btnAjoutClientGroupe.Name = "btnAjoutClientGroupe";
            this.btnAjoutClientGroupe.Size = new System.Drawing.Size(147, 23);
            this.btnAjoutClientGroupe.TabIndex = 6;
            this.btnAjoutClientGroupe.Text = "Ajouter Client dans Groupe";
            this.btnAjoutClientGroupe.UseVisualStyleBackColor = true;
            // 
            // btnInviterClientGroupe
            // 
            this.btnInviterClientGroupe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInviterClientGroupe.Location = new System.Drawing.Point(704, 228);
            this.btnInviterClientGroupe.Name = "btnInviterClientGroupe";
            this.btnInviterClientGroupe.Size = new System.Drawing.Size(146, 23);
            this.btnInviterClientGroupe.TabIndex = 7;
            this.btnInviterClientGroupe.Text = "Inviter Client dans Groupe";
            this.btnInviterClientGroupe.UseVisualStyleBackColor = true;
            // 
            // btnModifierClient
            // 
            this.btnModifierClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifierClient.Location = new System.Drawing.Point(297, 60);
            this.btnModifierClient.Name = "btnModifierClient";
            this.btnModifierClient.Size = new System.Drawing.Size(152, 23);
            this.btnModifierClient.TabIndex = 8;
            this.btnModifierClient.Text = "Modifier Client";
            this.btnModifierClient.UseVisualStyleBackColor = true;
            this.btnModifierClient.Click += new System.EventHandler(this.btnModifierClient_Click);
            // 
            // dataGridViewClient
            // 
            this.dataGridViewClient.AllowUserToAddRows = false;
            this.dataGridViewClient.AllowUserToDeleteRows = false;
            this.dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClient.Location = new System.Drawing.Point(7, 34);
            this.dataGridViewClient.MultiSelect = false;
            this.dataGridViewClient.Name = "dataGridViewClient";
            this.dataGridViewClient.ReadOnly = true;
            this.dataGridViewClient.Size = new System.Drawing.Size(284, 150);
            this.dataGridViewClient.TabIndex = 9;
            // 
            // lblDgvClient
            // 
            this.lblDgvClient.AutoSize = true;
            this.lblDgvClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDgvClient.Location = new System.Drawing.Point(3, 11);
            this.lblDgvClient.Name = "lblDgvClient";
            this.lblDgvClient.Size = new System.Drawing.Size(122, 20);
            this.lblDgvClient.TabIndex = 10;
            this.lblDgvClient.Text = "Liste des clients";
            // 
            // lblDgvGroupe
            // 
            this.lblDgvGroupe.AutoSize = true;
            this.lblDgvGroupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDgvGroupe.Location = new System.Drawing.Point(3, 205);
            this.lblDgvGroupe.Name = "lblDgvGroupe";
            this.lblDgvGroupe.Size = new System.Drawing.Size(135, 20);
            this.lblDgvGroupe.TabIndex = 12;
            this.lblDgvGroupe.Text = "Liste des groupes";
            // 
            // dataGridViewGroupe
            // 
            this.dataGridViewGroupe.AllowUserToAddRows = false;
            this.dataGridViewGroupe.AllowUserToDeleteRows = false;
            this.dataGridViewGroupe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupe.Location = new System.Drawing.Point(7, 228);
            this.dataGridViewGroupe.MultiSelect = false;
            this.dataGridViewGroupe.Name = "dataGridViewGroupe";
            this.dataGridViewGroupe.ReadOnly = true;
            this.dataGridViewGroupe.Size = new System.Drawing.Size(284, 150);
            this.dataGridViewGroupe.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAccepterInvitation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnEnleverGroupe);
            this.panel1.Controls.Add(this.lblDgvInvitation);
            this.panel1.Controls.Add(this.dataGridViewInvitation);
            this.panel1.Controls.Add(this.lblDgvClient);
            this.panel1.Controls.Add(this.btnInviterClientGroupe);
            this.panel1.Controls.Add(this.btnModifierClient);
            this.panel1.Controls.Add(this.btnAjoutClientGroupe);
            this.panel1.Controls.Add(this.lblDgvGroupe);
            this.panel1.Controls.Add(this.btnCreerGroupe);
            this.panel1.Controls.Add(this.dataGridViewClient);
            this.panel1.Controls.Add(this.btnSupprimerClient);
            this.panel1.Controls.Add(this.dataGridViewGroupe);
            this.panel1.Controls.Add(this.btnAjouterClient);
            this.panel1.Location = new System.Drawing.Point(271, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 472);
            this.panel1.TabIndex = 13;
            // 
            // btnAccepterInvitation
            // 
            this.btnAccepterInvitation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccepterInvitation.Location = new System.Drawing.Point(703, 257);
            this.btnAccepterInvitation.Name = "btnAccepterInvitation";
            this.btnAccepterInvitation.Size = new System.Drawing.Size(147, 23);
            this.btnAccepterInvitation.TabIndex = 18;
            this.btnAccepterInvitation.Text = "Accepter invitation";
            this.btnAccepterInvitation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Liste des clients dans des groupes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(455, 34);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(243, 150);
            this.dataGridView1.TabIndex = 16;
            // 
            // btnEnleverGroupe
            // 
            this.btnEnleverGroupe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnleverGroupe.Location = new System.Drawing.Point(703, 63);
            this.btnEnleverGroupe.Name = "btnEnleverGroupe";
            this.btnEnleverGroupe.Size = new System.Drawing.Size(146, 23);
            this.btnEnleverGroupe.TabIndex = 15;
            this.btnEnleverGroupe.Text = "Enlever du groupe";
            this.btnEnleverGroupe.UseVisualStyleBackColor = true;
            // 
            // lblDgvInvitation
            // 
            this.lblDgvInvitation.AutoSize = true;
            this.lblDgvInvitation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDgvInvitation.Location = new System.Drawing.Point(451, 205);
            this.lblDgvInvitation.Name = "lblDgvInvitation";
            this.lblDgvInvitation.Size = new System.Drawing.Size(147, 20);
            this.lblDgvInvitation.TabIndex = 14;
            this.lblDgvInvitation.Text = "Liste des invitations";
            // 
            // dataGridViewInvitation
            // 
            this.dataGridViewInvitation.AllowUserToAddRows = false;
            this.dataGridViewInvitation.AllowUserToDeleteRows = false;
            this.dataGridViewInvitation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvitation.Location = new System.Drawing.Point(455, 228);
            this.dataGridViewInvitation.MultiSelect = false;
            this.dataGridViewInvitation.Name = "dataGridViewInvitation";
            this.dataGridViewInvitation.ReadOnly = true;
            this.dataGridViewInvitation.Size = new System.Drawing.Size(243, 150);
            this.dataGridViewInvitation.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Prévisualisation des listes et tests de fonctions";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(611, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Rafraichir";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 519);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblLogs);
            this.Controls.Add(this.lsbLog);
            this.Name = "frmMain";
            this.Text = "Serveur de fichier";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvitation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbLog;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.Button btnAjouterClient;
        private System.Windows.Forms.Button btnSupprimerClient;
        private System.Windows.Forms.Button btnCreerGroupe;
        private System.Windows.Forms.Button btnAjoutClientGroupe;
        private System.Windows.Forms.Button btnInviterClientGroupe;
        private System.Windows.Forms.Button btnModifierClient;
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.Label lblDgvClient;
        private System.Windows.Forms.Label lblDgvGroupe;
        private System.Windows.Forms.DataGridView dataGridViewGroupe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDgvInvitation;
        private System.Windows.Forms.DataGridView dataGridViewInvitation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEnleverGroupe;
        private System.Windows.Forms.Button btnAccepterInvitation;
    }
}

