namespace Presentacion.Core.Cliente
{
    partial class _00111_Abm_Cliente
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
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.lblFoto = new System.Windows.Forms.Label();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.btnNuevaLocalidad = new System.Windows.Forms.Button();
            this.btnNuevaProvincia = new System.Windows.Forms.Button();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCUIL = new System.Windows.Forms.TextBox();
            this.lblCuil = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMontoMaximoCompra = new System.Windows.Forms.NumericUpDown();
            this.chkLimiteCompra = new System.Windows.Forms.CheckBox();
            this.chkActivarCtaCte = new System.Windows.Forms.CheckBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnNuevaCondicion = new System.Windows.Forms.Button();
            this.cmbCondicionIva = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoMaximoCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackColor = System.Drawing.Color.Silver;
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.lblFoto);
            this.pnlFoto.Controls.Add(this.btnAgregarImagen);
            this.pnlFoto.Controls.Add(this.imgFoto);
            this.pnlFoto.Location = new System.Drawing.Point(684, 93);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(268, 365);
            this.pnlFoto.TabIndex = 118;
            // 
            // lblFoto
            // 
            this.lblFoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.Location = new System.Drawing.Point(0, 0);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(266, 49);
            this.lblFoto.TabIndex = 84;
            this.lblFoto.Text = "Foto";
            this.lblFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarImagen.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAgregarImagen.Location = new System.Drawing.Point(45, 312);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(178, 43);
            this.btnAgregarImagen.TabIndex = 1;
            this.btnAgregarImagen.Text = "Agregar Imagen";
            this.btnAgregarImagen.UseVisualStyleBackColor = false;
            this.btnAgregarImagen.Click += new System.EventHandler(this.BtnAgregarImagen_Click);
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.White;
            this.imgFoto.Location = new System.Drawing.Point(18, 60);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(232, 246);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 0;
            this.imgFoto.TabStop = false;
            // 
            // btnNuevaLocalidad
            // 
            this.btnNuevaLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaLocalidad.Location = new System.Drawing.Point(598, 353);
            this.btnNuevaLocalidad.Name = "btnNuevaLocalidad";
            this.btnNuevaLocalidad.Size = new System.Drawing.Size(54, 32);
            this.btnNuevaLocalidad.TabIndex = 117;
            this.btnNuevaLocalidad.Text = ". . .";
            this.btnNuevaLocalidad.UseVisualStyleBackColor = true;
            this.btnNuevaLocalidad.Click += new System.EventHandler(this.BtnNuevaLocalidad_Click);
            // 
            // btnNuevaProvincia
            // 
            this.btnNuevaProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaProvincia.Location = new System.Drawing.Point(598, 315);
            this.btnNuevaProvincia.Name = "btnNuevaProvincia";
            this.btnNuevaProvincia.Size = new System.Drawing.Size(54, 32);
            this.btnNuevaProvincia.TabIndex = 116;
            this.btnNuevaProvincia.Text = ". . .";
            this.btnNuevaProvincia.UseVisualStyleBackColor = true;
            this.btnNuevaProvincia.Click += new System.EventHandler(this.BtnNuevaProvincia_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(168, 353);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(422, 28);
            this.cmbLocalidad.TabIndex = 109;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(82, 360);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(77, 20);
            this.lblLocalidad.TabIndex = 115;
            this.lblLocalidad.Text = "Localidad";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.Location = new System.Drawing.Point(168, 315);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(422, 28);
            this.cmbProvincia.TabIndex = 108;
            this.cmbProvincia.SelectionChangeCommitted += new System.EventHandler(this.CmbProvincia_SelectionChangeCommitted);
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(86, 324);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(72, 20);
            this.lblProvincia.TabIndex = 114;
            this.lblProvincia.Text = "Provincia";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(168, 241);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(184, 26);
            this.dtpFechaNacimiento.TabIndex = 101;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(58, 249);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(102, 20);
            this.lblFechaNacimiento.TabIndex = 113;
            this.lblFechaNacimiento.Text = "F.Nacimiento";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(168, 278);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(482, 26);
            this.txtDireccion.TabIndex = 103;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(82, 284);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 20);
            this.lblDireccion.TabIndex = 110;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(472, 204);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(178, 26);
            this.txtCelular.TabIndex = 99;
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(408, 209);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(58, 20);
            this.lblCelular.TabIndex = 107;
            this.lblCelular.Text = "Celular";
            // 
            // txtCUIL
            // 
            this.txtCUIL.Location = new System.Drawing.Point(472, 167);
            this.txtCUIL.Name = "txtCUIL";
            this.txtCUIL.Size = new System.Drawing.Size(178, 26);
            this.txtCUIL.TabIndex = 96;
            // 
            // lblCuil
            // 
            this.lblCuil.AutoSize = true;
            this.lblCuil.Location = new System.Drawing.Point(420, 172);
            this.lblCuil.Name = "lblCuil";
            this.lblCuil.Size = new System.Drawing.Size(46, 20);
            this.lblCuil.TabIndex = 106;
            this.lblCuil.Text = "CUIL";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(166, 392);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(482, 26);
            this.txtEmail.TabIndex = 102;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(21, 398);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(140, 20);
            this.lblEmail.TabIndex = 105;
            this.lblEmail.Text = "Correo Electrónico";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(168, 204);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(184, 26);
            this.txtTelefono.TabIndex = 97;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(88, 210);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(71, 20);
            this.lblTelefono.TabIndex = 104;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(168, 167);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(184, 26);
            this.txtDni.TabIndex = 95;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(123, 173);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(37, 20);
            this.lblDni.TabIndex = 100;
            this.lblDni.Text = "DNI";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(168, 130);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(482, 26);
            this.txtNombre.TabIndex = 93;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(96, 136);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 20);
            this.lblNombre.TabIndex = 98;
            this.lblNombre.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(168, 93);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(482, 26);
            this.txtApellido.TabIndex = 92;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(96, 100);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(65, 20);
            this.lblApellido.TabIndex = 94;
            this.lblApellido.Text = "Apellido";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudMontoMaximoCompra);
            this.groupBox1.Controls.Add(this.chkLimiteCompra);
            this.groupBox1.Controls.Add(this.chkActivarCtaCte);
            this.groupBox1.Location = new System.Drawing.Point(166, 469);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(484, 152);
            this.groupBox1.TabIndex = 119;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Cuenta Corriente ]";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(4, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(476, 69);
            this.label2.TabIndex = 146;
            this.label2.Text = "Al activar el Limite de Compra, el cliente no podra tener una deuda mayor a la qu" +
    "e se indique en el Monto Maximo de Compra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudMontoMaximoCompra
            // 
            this.nudMontoMaximoCompra.DecimalPlaces = 2;
            this.nudMontoMaximoCompra.Enabled = false;
            this.nudMontoMaximoCompra.Location = new System.Drawing.Point(306, 34);
            this.nudMontoMaximoCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMontoMaximoCompra.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoMaximoCompra.Name = "nudMontoMaximoCompra";
            this.nudMontoMaximoCompra.Size = new System.Drawing.Size(150, 26);
            this.nudMontoMaximoCompra.TabIndex = 2;
            this.nudMontoMaximoCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkLimiteCompra
            // 
            this.chkLimiteCompra.AutoSize = true;
            this.chkLimiteCompra.Location = new System.Drawing.Point(140, 37);
            this.chkLimiteCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLimiteCompra.Name = "chkLimiteCompra";
            this.chkLimiteCompra.Size = new System.Drawing.Size(159, 24);
            this.chkLimiteCompra.TabIndex = 1;
            this.chkLimiteCompra.Text = "Limite de Compra";
            this.chkLimiteCompra.UseVisualStyleBackColor = true;
            this.chkLimiteCompra.CheckedChanged += new System.EventHandler(this.ChkLimiteCompra_CheckedChanged);
            // 
            // chkActivarCtaCte
            // 
            this.chkActivarCtaCte.AutoSize = true;
            this.chkActivarCtaCte.Location = new System.Drawing.Point(21, 37);
            this.chkActivarCtaCte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkActivarCtaCte.Name = "chkActivarCtaCte";
            this.chkActivarCtaCte.Size = new System.Drawing.Size(83, 24);
            this.chkActivarCtaCte.TabIndex = 0;
            this.chkActivarCtaCte.Text = "Activar";
            this.chkActivarCtaCte.UseVisualStyleBackColor = true;
            // 
            // btnNuevaCondicion
            // 
            this.btnNuevaCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCondicion.Location = new System.Drawing.Point(597, 429);
            this.btnNuevaCondicion.Name = "btnNuevaCondicion";
            this.btnNuevaCondicion.Size = new System.Drawing.Size(54, 32);
            this.btnNuevaCondicion.TabIndex = 122;
            this.btnNuevaCondicion.Text = ". . .";
            this.btnNuevaCondicion.UseVisualStyleBackColor = true;
            this.btnNuevaCondicion.Click += new System.EventHandler(this.BtnNuevaCondicion_Click);
            // 
            // cmbCondicionIva
            // 
            this.cmbCondicionIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondicionIva.Location = new System.Drawing.Point(166, 429);
            this.cmbCondicionIva.Name = "cmbCondicionIva";
            this.cmbCondicionIva.Size = new System.Drawing.Size(422, 28);
            this.cmbCondicionIva.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 121;
            this.label1.Text = "Condición Iva";
            // 
            // _00111_Abm_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 674);
            this.Controls.Add(this.btnNuevaCondicion);
            this.Controls.Add(this.cmbCondicionIva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFoto);
            this.Controls.Add(this.btnNuevaLocalidad);
            this.Controls.Add(this.btnNuevaProvincia);
            this.Controls.Add(this.cmbLocalidad);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.lblCelular);
            this.Controls.Add(this.txtCUIL);
            this.Controls.Add(this.lblCuil);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.MaximumSize = new System.Drawing.Size(994, 730);
            this.MinimumSize = new System.Drawing.Size(994, 730);
            this.Name = "_00111_Abm_Cliente";
            this.Text = "Cliente (Alta, Baja y Modificación)";
            this.Controls.SetChildIndex(this.lblApellido, 0);
            this.Controls.SetChildIndex(this.txtApellido, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.lblDni, 0);
            this.Controls.SetChildIndex(this.txtDni, 0);
            this.Controls.SetChildIndex(this.lblTelefono, 0);
            this.Controls.SetChildIndex(this.txtTelefono, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.lblCuil, 0);
            this.Controls.SetChildIndex(this.txtCUIL, 0);
            this.Controls.SetChildIndex(this.lblCelular, 0);
            this.Controls.SetChildIndex(this.txtCelular, 0);
            this.Controls.SetChildIndex(this.lblDireccion, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.lblFechaNacimiento, 0);
            this.Controls.SetChildIndex(this.dtpFechaNacimiento, 0);
            this.Controls.SetChildIndex(this.lblProvincia, 0);
            this.Controls.SetChildIndex(this.cmbProvincia, 0);
            this.Controls.SetChildIndex(this.lblLocalidad, 0);
            this.Controls.SetChildIndex(this.cmbLocalidad, 0);
            this.Controls.SetChildIndex(this.btnNuevaProvincia, 0);
            this.Controls.SetChildIndex(this.btnNuevaLocalidad, 0);
            this.Controls.SetChildIndex(this.pnlFoto, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbCondicionIva, 0);
            this.Controls.SetChildIndex(this.btnNuevaCondicion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoMaximoCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.PictureBox imgFoto;
        private System.Windows.Forms.Button btnNuevaLocalidad;
        private System.Windows.Forms.Button btnNuevaProvincia;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtCUIL;
        private System.Windows.Forms.Label lblCuil;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudMontoMaximoCompra;
        private System.Windows.Forms.CheckBox chkLimiteCompra;
        private System.Windows.Forms.CheckBox chkActivarCtaCte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnNuevaCondicion;
        private System.Windows.Forms.ComboBox cmbCondicionIva;
        private System.Windows.Forms.Label label1;
    }
}