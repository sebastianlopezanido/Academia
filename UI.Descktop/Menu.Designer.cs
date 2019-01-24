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
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btnAdmEsp = new System.Windows.Forms.Button();
            this.btnAdmPla = new System.Windows.Forms.Button();
            this.btnAdmMat = new System.Windows.Forms.Button();
            this.btnAdmCom = new System.Windows.Forms.Button();
            this.btnAdmCur = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSesion = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // salir
            // 
            this.salir.Location = new System.Drawing.Point(336, 232);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(88, 23);
            this.salir.TabIndex = 0;
            this.salir.Text = "Cerrar Sesion";
            this.salir.UseVisualStyleBackColor = true;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(12, 27);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(87, 23);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "Usuarios";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(12, 56);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(87, 23);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "Personas";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btnAdmEsp
            // 
            this.btnAdmEsp.Location = new System.Drawing.Point(12, 85);
            this.btnAdmEsp.Name = "btnAdmEsp";
            this.btnAdmEsp.Size = new System.Drawing.Size(87, 23);
            this.btnAdmEsp.TabIndex = 4;
            this.btnAdmEsp.Text = "Especialidades";
            this.btnAdmEsp.UseVisualStyleBackColor = true;
            this.btnAdmEsp.Click += new System.EventHandler(this.btnAdmEsp_Click);
            // 
            // btnAdmPla
            // 
            this.btnAdmPla.Location = new System.Drawing.Point(12, 115);
            this.btnAdmPla.Name = "btnAdmPla";
            this.btnAdmPla.Size = new System.Drawing.Size(87, 23);
            this.btnAdmPla.TabIndex = 5;
            this.btnAdmPla.Text = "Planes";
            this.btnAdmPla.UseVisualStyleBackColor = true;
            this.btnAdmPla.Click += new System.EventHandler(this.btnAdmPla_Click);
            // 
            // btnAdmMat
            // 
            this.btnAdmMat.Location = new System.Drawing.Point(12, 145);
            this.btnAdmMat.Name = "btnAdmMat";
            this.btnAdmMat.Size = new System.Drawing.Size(87, 23);
            this.btnAdmMat.TabIndex = 6;
            this.btnAdmMat.Text = "Materias";
            this.btnAdmMat.UseVisualStyleBackColor = true;
            this.btnAdmMat.Click += new System.EventHandler(this.btnAdmMat_Click);
            // 
            // btnAdmCom
            // 
            this.btnAdmCom.Location = new System.Drawing.Point(12, 175);
            this.btnAdmCom.Name = "btnAdmCom";
            this.btnAdmCom.Size = new System.Drawing.Size(87, 23);
            this.btnAdmCom.TabIndex = 7;
            this.btnAdmCom.Text = "Comisiones";
            this.btnAdmCom.UseVisualStyleBackColor = true;
            this.btnAdmCom.Click += new System.EventHandler(this.btnAdmCom_Click);
            // 
            // btnAdmCur
            // 
            this.btnAdmCur.Location = new System.Drawing.Point(12, 205);
            this.btnAdmCur.Name = "btnAdmCur";
            this.btnAdmCur.Size = new System.Drawing.Size(87, 23);
            this.btnAdmCur.TabIndex = 8;
            this.btnAdmCur.Text = "Cursos";
            this.btnAdmCur.UseVisualStyleBackColor = true;
            this.btnAdmCur.Click += new System.EventHandler(this.btnAdmCur_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sesión:";
            // 
            // lblSesion
            // 
            this.lblSesion.AutoSize = true;
            this.lblSesion.Location = new System.Drawing.Point(389, 4);
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(35, 13);
            this.lblSesion.TabIndex = 10;
            this.lblSesion.Text = "label2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(433, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.personasToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.comisionesToolStripMenuItem,
            this.cursosToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.btn1_Click);
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.btn2_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.btnAdmEsp_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.btnAdmPla_Click);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materiasToolStripMenuItem.Text = "Materias";
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.btnAdmMat_Click);
            // 
            // comisionesToolStripMenuItem
            // 
            this.comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            this.comisionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comisionesToolStripMenuItem.Text = "Comisiones";
            this.comisionesToolStripMenuItem.Click += new System.EventHandler(this.btnAdmCom_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cursosToolStripMenuItem.Text = "Cursos";
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.btnAdmCur_Click);
            // 
            // Menu
            // 
            this.AcceptButton = this.btn1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 262);
            this.Controls.Add(this.lblSesion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdmCur);
            this.Controls.Add(this.btnAdmCom);
            this.Controls.Add(this.btnAdmMat);
            this.Controls.Add(this.btnAdmPla);
            this.Controls.Add(this.btnAdmEsp);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btnAdmEsp;
        private System.Windows.Forms.Button btnAdmPla;
        private System.Windows.Forms.Button btnAdmMat;
        private System.Windows.Forms.Button btnAdmCom;
        private System.Windows.Forms.Button btnAdmCur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSesion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
    }
}