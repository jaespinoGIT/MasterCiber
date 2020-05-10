namespace GoogleAuthenticator
{
    partial class Formulario
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdGenerarQR = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmdGenerarPin = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(273, 228);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 228);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cmdGenerarQR
            // 
            this.cmdGenerarQR.Location = new System.Drawing.Point(303, 41);
            this.cmdGenerarQR.Name = "cmdGenerarQR";
            this.cmdGenerarQR.Size = new System.Drawing.Size(254, 23);
            this.cmdGenerarQR.TabIndex = 2;
            this.cmdGenerarQR.Text = "Generar QR";
            this.cmdGenerarQR.UseVisualStyleBackColor = true;
            this.cmdGenerarQR.Click += new System.EventHandler(this.cmdGenerarQR_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(303, 12);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(254, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "email@email.com";
            // 
            // cmdGenerarPin
            // 
            this.cmdGenerarPin.Location = new System.Drawing.Point(303, 70);
            this.cmdGenerarPin.Name = "cmdGenerarPin";
            this.cmdGenerarPin.Size = new System.Drawing.Size(254, 23);
            this.cmdGenerarPin.TabIndex = 4;
            this.cmdGenerarPin.Text = "Generar Pin";
            this.cmdGenerarPin.UseVisualStyleBackColor = true;
            this.cmdGenerarPin.Click += new System.EventHandler(this.cmdGenerarPin_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(303, 99);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(254, 20);
            this.txtPin.TabIndex = 5;
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 268);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.cmdGenerarPin);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmdGenerarQR);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Formulario";
            this.Text = "M8T2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdGenerarQR;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button cmdGenerarPin;
        private System.Windows.Forms.TextBox txtPin;
    }
}

