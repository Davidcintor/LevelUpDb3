namespace LevelUpDb3.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnImportarJson = new Button();
            btnImportarTxt = new Button();
            btnImportarXml = new Button();
            SuspendLayout();
            // 
            // btnImportarJson
            // 
            btnImportarJson.Location = new Point(83, 45);
            btnImportarJson.Name = "btnImportarJson";
            btnImportarJson.Size = new Size(133, 23);
            btnImportarJson.TabIndex = 1;
            btnImportarJson.Text = "Importar JSON";
            btnImportarJson.UseVisualStyleBackColor = true;
            btnImportarJson.Click += btnImportarJson_Click;
            // 
            // btnImportarTxt
            // 
            btnImportarTxt.Location = new Point(141, 91);
            btnImportarTxt.Name = "btnImportarTxt";
            btnImportarTxt.Size = new Size(109, 23);
            btnImportarTxt.TabIndex = 2;
            btnImportarTxt.Text = "Importar TXT";
            btnImportarTxt.UseVisualStyleBackColor = true;
            btnImportarTxt.Click += btnImportarTxt_Click;
            // 
            // btnImportarXml
            // 
            btnImportarXml.Location = new Point(175, 152);
            btnImportarXml.Name = "btnImportarXml";
            btnImportarXml.Size = new Size(99, 23);
            btnImportarXml.TabIndex = 3;
            btnImportarXml.Text = "Importar XML";
            btnImportarXml.UseVisualStyleBackColor = true;
            btnImportarXml.Click += btnImportarXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnImportarXml);
            Controls.Add(btnImportarTxt);
            Controls.Add(btnImportarJson);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnImportarJson;
        private Button btnImportarTxt;
        private Button btnImportarXml;
    }
}
