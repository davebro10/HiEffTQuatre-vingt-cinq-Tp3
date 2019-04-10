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
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.lblDgvClient = new System.Windows.Forms.Label();
            this.lblDgvGroupe = new System.Windows.Forms.Label();
            this.dataGridViewGroupe = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDgvInvitation = new System.Windows.Forms.Label();
            this.dataGridViewInvitation = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupe)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvitation)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewClient.Size = new System.Drawing.Size(369, 150);
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
            this.dataGridViewGroupe.Size = new System.Drawing.Size(369, 150);
            this.dataGridViewGroupe.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblDgvInvitation);
            this.panel1.Controls.Add(this.dataGridViewInvitation);
            this.panel1.Controls.Add(this.lblDgvClient);
            this.panel1.Controls.Add(this.lblDgvGroupe);
            this.panel1.Controls.Add(this.dataGridViewClient);
            this.panel1.Controls.Add(this.dataGridViewGroupe);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 418);
            this.panel1.TabIndex = 13;
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
            this.dataGridViewInvitation.Size = new System.Drawing.Size(383, 150);
            this.dataGridViewInvitation.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Prévisualisation des listes";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(210, 14);
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
            this.ClientSize = new System.Drawing.Size(897, 480);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Serveur de fichier";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvitation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.Label lblDgvClient;
        private System.Windows.Forms.Label lblDgvGroupe;
        private System.Windows.Forms.DataGridView dataGridViewGroupe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDgvInvitation;
        private System.Windows.Forms.DataGridView dataGridViewInvitation;
    }
}

