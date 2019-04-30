namespace LR_Canonico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.expandida = new System.Windows.Forms.RichTextBox();
            this.sig = new System.Windows.Forms.Label();
            this.prim = new System.Windows.Forms.Label();
            this.expand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.open = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.treeSiguiente = new System.Windows.Forms.TreeView();
            this.treePrimero = new System.Windows.Forms.TreeView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gram = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.treeConjuntos = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandida
            // 
            this.expandida.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandida.Location = new System.Drawing.Point(3, 231);
            this.expandida.Name = "expandida";
            this.expandida.ReadOnly = true;
            this.expandida.Size = new System.Drawing.Size(103, 137);
            this.expandida.TabIndex = 1;
            this.expandida.Text = "";
            // 
            // sig
            // 
            this.sig.AutoSize = true;
            this.sig.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sig.Location = new System.Drawing.Point(224, 53);
            this.sig.Name = "sig";
            this.sig.Size = new System.Drawing.Size(69, 16);
            this.sig.TabIndex = 11;
            this.sig.Text = "Siguiente";
            // 
            // prim
            // 
            this.prim.AutoSize = true;
            this.prim.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prim.Location = new System.Drawing.Point(112, 53);
            this.prim.Name = "prim";
            this.prim.Size = new System.Drawing.Size(59, 16);
            this.prim.TabIndex = 10;
            this.prim.Text = "Primero";
            // 
            // expand
            // 
            this.expand.AutoSize = true;
            this.expand.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expand.Location = new System.Drawing.Point(3, 212);
            this.expand.Name = "expand";
            this.expand.Size = new System.Drawing.Size(76, 16);
            this.expand.TabIndex = 9;
            this.expand.Text = "Expandida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gramatica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(330, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Conjuntos";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.open});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // save
            // 
            this.save.AccessibleName = "save";
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "toolStripButton2";
            // 
            // open
            // 
            this.open.AccessibleName = "open";
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open.Image = ((System.Drawing.Image)(resources.GetObject("open.Image")));
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(23, 22);
            this.open.Text = "toolStripButton1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(579, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrir,
            this.guardar});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ArchivoToolStripMenuItem_DropDownItemClicked);
            // 
            // abrir
            // 
            this.abrir.AccessibleName = "open";
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(116, 22);
            this.abrir.Text = "Abrir";
            // 
            // guardar
            // 
            this.guardar.AccessibleName = "save";
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(116, 22);
            this.guardar.Text = "Guardar";
            // 
            // treeSiguiente
            // 
            this.treeSiguiente.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeSiguiente.Location = new System.Drawing.Point(224, 72);
            this.treeSiguiente.Name = "treeSiguiente";
            this.treeSiguiente.Size = new System.Drawing.Size(103, 296);
            this.treeSiguiente.TabIndex = 16;
            // 
            // treePrimero
            // 
            this.treePrimero.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treePrimero.FullRowSelect = true;
            this.treePrimero.Location = new System.Drawing.Point(115, 72);
            this.treePrimero.Name = "treePrimero";
            this.treePrimero.Size = new System.Drawing.Size(103, 296);
            this.treePrimero.TabIndex = 17;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gram
            // 
            this.gram.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gram.Location = new System.Drawing.Point(3, 72);
            this.gram.Name = "gram";
            this.gram.Size = new System.Drawing.Size(103, 137);
            this.gram.TabIndex = 18;
            this.gram.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // treeConjuntos
            // 
            this.treeConjuntos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeConjuntos.Location = new System.Drawing.Point(333, 72);
            this.treeConjuntos.Name = "treeConjuntos";
            this.treeConjuntos.Size = new System.Drawing.Size(240, 296);
            this.treeConjuntos.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 417);
            this.Controls.Add(this.treeConjuntos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gram);
            this.Controls.Add(this.treePrimero);
            this.Controls.Add(this.treeSiguiente);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sig);
            this.Controls.Add(this.prim);
            this.Controls.Add(this.expand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expandida);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox expandida;
        private System.Windows.Forms.Label sig;
        private System.Windows.Forms.Label prim;
        private System.Windows.Forms.Label expand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrir;
        private System.Windows.Forms.ToolStripMenuItem guardar;
        private System.Windows.Forms.TreeView treeSiguiente;
        private System.Windows.Forms.TreeView treePrimero;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox gram;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeConjuntos;
    }
}

