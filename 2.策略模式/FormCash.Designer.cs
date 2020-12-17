
namespace 策略模式
{
    partial class CashWin
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
            this.pricesText = new System.Windows.Forms.Label();
            this.numText = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.totalText = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.ListBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pricesText
            // 
            this.pricesText.AutoSize = true;
            this.pricesText.Location = new System.Drawing.Point(50, 36);
            this.pricesText.Name = "pricesText";
            this.pricesText.Size = new System.Drawing.Size(35, 17);
            this.pricesText.TabIndex = 0;
            this.pricesText.Text = "单价:";
            // 
            // numText
            // 
            this.numText.AutoSize = true;
            this.numText.Location = new System.Drawing.Point(50, 80);
            this.numText.Name = "numText";
            this.numText.Size = new System.Drawing.Size(35, 17);
            this.numText.TabIndex = 1;
            this.numText.Text = "数量:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(106, 36);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "0.00";
            this.txtPrice.Size = new System.Drawing.Size(169, 23);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(106, 80);
            this.txtNum.Name = "txtNum";
            this.txtNum.PlaceholderText = "0.00";
            this.txtNum.Size = new System.Drawing.Size(169, 23);
            this.txtNum.TabIndex = 3;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(313, 36);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(313, 80);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // totalText
            // 
            this.totalText.AutoSize = true;
            this.totalText.Location = new System.Drawing.Point(50, 310);
            this.totalText.Name = "totalText";
            this.totalText.Size = new System.Drawing.Size(35, 17);
            this.totalText.TabIndex = 7;
            this.totalText.Text = "总计:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResult.Location = new System.Drawing.Point(176, 344);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(70, 35);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "0.00";
            // 
            // lblList
            // 
            this.lblList.FormattingEnabled = true;
            this.lblList.ItemHeight = 17;
            this.lblList.Location = new System.Drawing.Point(50, 149);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(338, 140);
            this.lblList.TabIndex = 9;
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "正常收费",
            "满300减100",
            "打8折"});
            this.cbxType.Location = new System.Drawing.Point(125, 109);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(121, 25);
            this.cbxType.TabIndex = 10;
            this.cbxType.Text = "正常收费";
            // 
            // FormWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 409);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.totalText);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.numText);
            this.Controls.Add(this.pricesText);
            this.Name = "FormWin";
            this.Text = "收银软件-策略模式";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pricesText;
        private System.Windows.Forms.Label numText;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label totalText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox lblList;
        private System.Windows.Forms.ComboBox cbxType;
    }
}

