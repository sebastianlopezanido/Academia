using BusinessEntities;

namespace UI.Desktop
{
    partial class Menu
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
            this.salir = new System.Windows.Forms.Button();
            this.btnAdmUsr = new System.Windows.Forms.Button();
            this.btnAdmPrs = new System.Windows.Forms.Button();
            this.btnAdmEsp = new System.Windows.Forms.Button();
            this.btnAdmPla = new System.Windows.Forms.Button();
            this.btnAdmMat = new System.Windows.Forms.Button();
            this.btnAdmCom = new System.Windows.Forms.Button();
            this.btnAdmCur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // salir
            // 
            this.salir.Location = new System.Drawing.Point(336, 218);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(88, 23);
            this.salir.TabIndex = 0;
            this.salir.Text = "Cerrar Sesion";
            this.salir.UseVisualStyleBackColor = true;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // btnAdmUsr
            // 
            this.btnAdmUsr.Location = new System.Drawing.Point(24, 13);
            this.btnAdmUsr.Name = "btnAdmUsr";
            this.btnAdmUsr.Size = new System.Drawing.Size(87, 23);
            this.btnAdmUsr.TabIndex = 2;
            this.btnAdmUsr.Text = "Usuarios";
            this.btnAdmUsr.UseVisualStyleBackColor = true;
            this.btnAdmUsr.Click += new System.EventHandler(this.btnAdmUsr_Click);
            // 
            // btnAdmPrs
            // 
            this.btnAdmPrs.Location = new System.Drawing.Point(24, 42);
            this.btnAdmPrs.Name = "btnAdmPrs";
            this.btnAdmPrs.Size = new System.Drawing.Size(87, 23);
            this.btnAdmPrs.TabIndex = 3;
            this.btnAdmPrs.Text = "Personas";
            this.btnAdmPrs.UseVisualStyleBackColor = true;
            this.btnAdmPrs.Click += new System.EventHandler(this.btnAdmPrs_Click);
            // 
            // btnAdmEsp
            // 
            this.btnAdmEsp.Location = new System.Drawing.Point(24, 71);
            this.btnAdmEsp.Name = "btnAdmEsp";
            this.btnAdmEsp.Size = new System.Drawing.Size(87, 23);
            this.btnAdmEsp.TabIndex = 4;
            this.btnAdmEsp.Text = "Especialidades";
            this.btnAdmEsp.UseVisualStyleBackColor = true;
            this.btnAdmEsp.Click += new System.EventHandler(this.btnAdmEsp_Click);
            // 
            // btnAdmPla
            // 
            this.btnAdmPla.Location = new System.Drawing.Point(24, 101);
            this.btnAdmPla.Name = "btnAdmPla";
            this.btnAdmPla.Size = new System.Drawing.Size(87, 23);
            this.btnAdmPla.TabIndex = 5;
            this.btnAdmPla.Text = "Planes";
            this.btnAdmPla.UseVisualStyleBackColor = true;
            this.btnAdmPla.Click += new System.EventHandler(this.btnAdmPla_Click);
            // 
            // btnAdmMat
            // 
            this.btnAdmMat.Location = new System.Drawing.Point(24, 131);
            this.btnAdmMat.Name = "btnAdmMat";
            this.btnAdmMat.Size = new System.Drawing.Size(87, 23);
            this.btnAdmMat.TabIndex = 6;
            this.btnAdmMat.Text = "Materias";
            this.btnAdmMat.UseVisualStyleBackColor = true;
            this.btnAdmMat.Click += new System.EventHandler(this.btnAdmMat_Click);
            // 
            // btnAdmCom
            // 
            this.btnAdmCom.Location = new System.Drawing.Point(24, 161);
            this.btnAdmCom.Name = "btnAdmCom";
            this.btnAdmCom.Size = new System.Drawing.Size(87, 23);
            this.btnAdmCom.TabIndex = 7;
            this.btnAdmCom.Text = "Comisiones";
            this.btnAdmCom.UseVisualStyleBackColor = true;
            this.btnAdmCom.Click += new System.EventHandler(this.btnAdmCom_Click);
            // 
            // btnAdmCur
            // 
            this.btnAdmCur.Location = new System.Drawing.Point(24, 191);
            this.btnAdmCur.Name = "btnAdmCur";
            this.btnAdmCur.Size = new System.Drawing.Size(87, 23);
            this.btnAdmCur.TabIndex = 8;
            this.btnAdmCur.Text = "Cursos";
            this.btnAdmCur.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 253);
            this.Controls.Add(this.btnAdmCur);
            this.Controls.Add(this.btnAdmCom);
            this.Controls.Add(this.btnAdmMat);
            this.Controls.Add(this.btnAdmPla);
            this.Controls.Add(this.btnAdmEsp);
            this.Controls.Add(this.btnAdmPrs);
            this.Controls.Add(this.btnAdmUsr);
            this.Controls.Add(this.salir);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button btnAdmUsr;
        private System.Windows.Forms.Button btnAdmPrs;
        private System.Windows.Forms.Button btnAdmEsp;
        private System.Windows.Forms.Button btnAdmPla;
        private System.Windows.Forms.Button btnAdmMat;
        private System.Windows.Forms.Button btnAdmCom;
        private System.Windows.Forms.Button btnAdmCur;
    }
}