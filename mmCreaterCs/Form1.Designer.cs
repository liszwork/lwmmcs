﻿namespace mmCreaterCs
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textOutput = new System.Windows.Forms.TextBox();
            this.textInput = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonSetCurrent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCurrentName = new System.Windows.Forms.Label();
            this.buttonPrevCurrent = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.textEditNodeName = new System.Windows.Forms.TextBox();
            this.labelModify = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textOutput
            // 
            this.textOutput.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textOutput.Location = new System.Drawing.Point(348, 12);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(337, 426);
            this.textOutput.TabIndex = 9;
            // 
            // textInput
            // 
            this.textInput.Location = new System.Drawing.Point(94, 106);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(233, 19);
            this.textInput.TabIndex = 3;
            this.textInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textInput_KeyUp);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(252, 131);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 23);
            this.buttonEnter.TabIndex = 4;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Visible = false;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(252, 352);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 6;
            this.buttonShow.Text = "show nodes";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonSetCurrent
            // 
            this.buttonSetCurrent.Location = new System.Drawing.Point(252, 33);
            this.buttonSetCurrent.Name = "buttonSetCurrent";
            this.buttonSetCurrent.Size = new System.Drawing.Size(75, 23);
            this.buttonSetCurrent.TabIndex = 1;
            this.buttonSetCurrent.Text = "set current";
            this.buttonSetCurrent.UseVisualStyleBackColor = true;
            this.buttonSetCurrent.Visible = false;
            this.buttonSetCurrent.Click += new System.EventHandler(this.buttonSetCurrent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "current node ->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "add node";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "select current";
            // 
            // labelCurrentName
            // 
            this.labelCurrentName.AutoSize = true;
            this.labelCurrentName.Location = new System.Drawing.Point(103, 9);
            this.labelCurrentName.Name = "labelCurrentName";
            this.labelCurrentName.Size = new System.Drawing.Size(11, 12);
            this.labelCurrentName.TabIndex = 11;
            this.labelCurrentName.Text = "-";
            // 
            // buttonPrevCurrent
            // 
            this.buttonPrevCurrent.Location = new System.Drawing.Point(252, 51);
            this.buttonPrevCurrent.Name = "buttonPrevCurrent";
            this.buttonPrevCurrent.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevCurrent.TabIndex = 2;
            this.buttonPrevCurrent.Text = "prev current";
            this.buttonPrevCurrent.UseVisualStyleBackColor = true;
            this.buttonPrevCurrent.Click += new System.EventHandler(this.buttonPrevCurrent_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(252, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(136, 415);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Text = "load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // textEditNodeName
            // 
            this.textEditNodeName.Location = new System.Drawing.Point(94, 160);
            this.textEditNodeName.Name = "textEditNodeName";
            this.textEditNodeName.Size = new System.Drawing.Size(233, 19);
            this.textEditNodeName.TabIndex = 5;
            this.textEditNodeName.Text = "edit node name";
            this.textEditNodeName.Enter += new System.EventHandler(this.textEditNodeName_Enter);
            this.textEditNodeName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textEditNodeName_KeyUp);
            this.textEditNodeName.Leave += new System.EventHandler(this.textEditNodeName_Leave);
            // 
            // labelModify
            // 
            this.labelModify.AutoSize = true;
            this.labelModify.Location = new System.Drawing.Point(12, 163);
            this.labelModify.Name = "labelModify";
            this.labelModify.Size = new System.Drawing.Size(39, 12);
            this.labelModify.TabIndex = 13;
            this.labelModify.Text = "modify";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(252, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelModify);
            this.Controls.Add(this.textEditNodeName);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPrevCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCurrentName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSetCurrent);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textInput);
            this.Controls.Add(this.textOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSetCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCurrentName;
        private System.Windows.Forms.Button buttonPrevCurrent;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textEditNodeName;
        private System.Windows.Forms.Label labelModify;
        private System.Windows.Forms.Button buttonDelete;
    }
}

