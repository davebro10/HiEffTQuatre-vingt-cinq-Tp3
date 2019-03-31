namespace serveur
{
    partial class FrmClient
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
            this.txbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUsager = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbMotDePasse = new System.Windows.Forms.TextBox();
            this.txbOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(98, 12);
            this.txbId.Name = "txbId";
            this.txbId.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(100, 20);
            this.txbId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom :";
            // 
            // txbNom
            // 
            this.txbNom.Location = new System.Drawing.Point(98, 38);
            this.txbNom.Name = "txbNom";
            this.txbNom.Size = new System.Drawing.Size(100, 20);
            this.txbNom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usager :";
            // 
            // txbUsager
            // 
            this.txbUsager.Location = new System.Drawing.Point(98, 64);
            this.txbUsager.Name = "txbUsager";
            this.txbUsager.Size = new System.Drawing.Size(100, 20);
            this.txbUsager.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mot de passe :";
            // 
            // txbMotDePasse
            // 
            this.txbMotDePasse.Location = new System.Drawing.Point(98, 90);
            this.txbMotDePasse.Name = "txbMotDePasse";
            this.txbMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txbMotDePasse.TabIndex = 6;
            // 
            // txbOk
            // 
            this.txbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txbOk.Location = new System.Drawing.Point(12, 134);
            this.txbOk.Name = "txbOk";
            this.txbOk.Size = new System.Drawing.Size(238, 46);
            this.txbOk.TabIndex = 8;
            this.txbOk.Text = "Ok";
            this.txbOk.UseVisualStyleBackColor = true;
            this.txbOk.Click += new System.EventHandler(this.txbOk_Click);
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 192);
            this.Controls.Add(this.txbOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbMotDePasse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbUsager);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbId);
            this.Name = "FrmClient";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbUsager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbMotDePasse;
        private System.Windows.Forms.Button txbOk;
    }
}