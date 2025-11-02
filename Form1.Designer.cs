namespace AnotisApp
{
    partial class Anotis
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
            this.tituloTexto = new System.Windows.Forms.TextBox();
            this.notaTexto = new System.Windows.Forms.TextBox();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.notaLabel = new System.Windows.Forms.Label();
            this.historialDeNotas = new System.Windows.Forms.DataGridView();
            this.btnNuevaNota = new System.Windows.Forms.Button();
            this.btnCargarNota = new System.Windows.Forms.Button();
            this.btnGuardarNota = new System.Windows.Forms.Button();
            this.btnBorrarNota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.historialDeNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloTexto
            // 
            this.tituloTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloTexto.Location = new System.Drawing.Point(12, 33);
            this.tituloTexto.Name = "tituloTexto";
            this.tituloTexto.Size = new System.Drawing.Size(410, 20);
            this.tituloTexto.TabIndex = 0;
            // 
            // notaTexto
            // 
            this.notaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notaTexto.Location = new System.Drawing.Point(12, 72);
            this.notaTexto.Multiline = true;
            this.notaTexto.Name = "notaTexto";
            this.notaTexto.Size = new System.Drawing.Size(410, 366);
            this.notaTexto.TabIndex = 1;
            // 
            // tituloLabel
            // 
            this.tituloLabel.Location = new System.Drawing.Point(9, 17);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(413, 13);
            this.tituloLabel.TabIndex = 2;
            this.tituloLabel.Text = "Titulo:";
            this.tituloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notaLabel
            // 
            this.notaLabel.Location = new System.Drawing.Point(9, 56);
            this.notaLabel.Name = "notaLabel";
            this.notaLabel.Size = new System.Drawing.Size(413, 13);
            this.notaLabel.TabIndex = 3;
            this.notaLabel.Text = "Nota:";
            this.notaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // historialDeNotas
            // 
            this.historialDeNotas.AllowUserToAddRows = false;
            this.historialDeNotas.AllowUserToDeleteRows = false;
            this.historialDeNotas.AllowUserToResizeColumns = false;
            this.historialDeNotas.AllowUserToResizeRows = false;
            this.historialDeNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historialDeNotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historialDeNotas.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.historialDeNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historialDeNotas.Location = new System.Drawing.Point(428, 33);
            this.historialDeNotas.Name = "historialDeNotas";
            this.historialDeNotas.RowHeadersVisible = false;
            this.historialDeNotas.Size = new System.Drawing.Size(360, 376);
            this.historialDeNotas.TabIndex = 4;
            this.historialDeNotas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.historialDeNotas_CellDoubleClick);
            // 
            // btnNuevaNota
            // 
            this.btnNuevaNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaNota.Location = new System.Drawing.Point(428, 415);
            this.btnNuevaNota.Name = "btnNuevaNota";
            this.btnNuevaNota.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaNota.TabIndex = 5;
            this.btnNuevaNota.Text = "Nueva Nota";
            this.btnNuevaNota.UseVisualStyleBackColor = true;
            this.btnNuevaNota.Click += new System.EventHandler(this.btnNuevaNota_Click);
            // 
            // btnCargarNota
            // 
            this.btnCargarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarNota.Location = new System.Drawing.Point(596, 415);
            this.btnCargarNota.Name = "btnCargarNota";
            this.btnCargarNota.Size = new System.Drawing.Size(75, 23);
            this.btnCargarNota.TabIndex = 6;
            this.btnCargarNota.Text = "Cargar Nota";
            this.btnCargarNota.UseVisualStyleBackColor = true;
            this.btnCargarNota.Click += new System.EventHandler(this.btnCargarNota_Click);
            // 
            // btnGuardarNota
            // 
            this.btnGuardarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarNota.Location = new System.Drawing.Point(509, 415);
            this.btnGuardarNota.Name = "btnGuardarNota";
            this.btnGuardarNota.Size = new System.Drawing.Size(81, 23);
            this.btnGuardarNota.TabIndex = 7;
            this.btnGuardarNota.Text = "Guardar Nota";
            this.btnGuardarNota.UseVisualStyleBackColor = true;
            this.btnGuardarNota.Click += new System.EventHandler(this.btnGuardarNota_Click);
            // 
            // btnBorrarNota
            // 
            this.btnBorrarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarNota.Location = new System.Drawing.Point(713, 415);
            this.btnBorrarNota.Name = "btnBorrarNota";
            this.btnBorrarNota.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarNota.TabIndex = 8;
            this.btnBorrarNota.Text = "Borrar Nota";
            this.btnBorrarNota.UseVisualStyleBackColor = true;
            this.btnBorrarNota.Click += new System.EventHandler(this.btnBorrarNota_Click);
            // 
            // Anotis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBorrarNota);
            this.Controls.Add(this.btnGuardarNota);
            this.Controls.Add(this.btnCargarNota);
            this.Controls.Add(this.btnNuevaNota);
            this.Controls.Add(this.historialDeNotas);
            this.Controls.Add(this.notaLabel);
            this.Controls.Add(this.tituloLabel);
            this.Controls.Add(this.notaTexto);
            this.Controls.Add(this.tituloTexto);
            this.Name = "Anotis";
            this.ShowIcon = false;
            this.Text = "Anotis";
            this.Load += new System.EventHandler(this.Anotis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.historialDeNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tituloTexto;
        private System.Windows.Forms.TextBox notaTexto;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.Label notaLabel;
        private System.Windows.Forms.DataGridView historialDeNotas;
        private System.Windows.Forms.Button btnNuevaNota;
        private System.Windows.Forms.Button btnCargarNota;
        private System.Windows.Forms.Button btnGuardarNota;
        private System.Windows.Forms.Button btnBorrarNota;
    }
}

