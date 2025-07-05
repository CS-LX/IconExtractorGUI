namespace IconExtractorGUI {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            selectButton = new Button();
            listView = new ListView();
            exportButton = new Button();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // selectButton
            // 
            selectButton.Location = new Point(12, 12);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(316, 48);
            selectButton.TabIndex = 0;
            selectButton.Text = "选择 EXE/DLL";
            selectButton.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.CheckBoxes = true;
            listView.Location = new Point(12, 66);
            listView.Name = "listView";
            listView.Size = new Size(776, 328);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            // 
            // exportButton
            // 
            exportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            exportButton.Location = new Point(12, 400);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(776, 55);
            exportButton.TabIndex = 2;
            exportButton.Text = "导出选中图标";
            exportButton.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(334, 24);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(100, 24);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "请选择文件";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 467);
            Controls.Add(statusLabel);
            Controls.Add(exportButton);
            Controls.Add(listView);
            Controls.Add(selectButton);
            Name = "MainForm";
            Text = "exe图标提取器";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectButton;
        private ListView listView;
        private Button exportButton;
        private Label statusLabel;
    }
}
