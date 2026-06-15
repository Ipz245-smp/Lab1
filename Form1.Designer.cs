namespace WinFormsApp
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
            btnLogin = new Button();
            btnBalance = new Button();
            btnWithdraw = new Button();
            btnDeposit = new Button();
            btnTransfer = new Button();
            txtAmount = new TextBox();
            txtPin = new TextBox();
            txtCard = new TextBox();
            txtTargetCard = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(201, 157);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(113, 29);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Авторизація";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnBalance
            // 
            btnBalance.Location = new Point(355, 385);
            btnBalance.Name = "btnBalance";
            btnBalance.Size = new Size(151, 29);
            btnBalance.TabIndex = 1;
            btnBalance.Text = "Перевірити баланс";
            btnBalance.UseVisualStyleBackColor = true;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(200, 385);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(114, 29);
            btnWithdraw.TabIndex = 2;
            btnWithdraw.Text = "Зняти готівку";
            btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(34, 385);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(130, 29);
            btnDeposit.TabIndex = 3;
            btnDeposit.Text = "Внести кошти";
            btnDeposit.UseVisualStyleBackColor = true;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(551, 385);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(94, 29);
            btnTransfer.TabIndex = 4;
            btnTransfer.Text = "Переказ";
            btnTransfer.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(302, 213);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(125, 27);
            txtAmount.TabIndex = 5;
            // 
            // txtPin
            // 
            txtPin.Location = new Point(302, 96);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(125, 27);
            txtPin.TabIndex = 6;
            // 
            // txtCard
            // 
            txtCard.Location = new Point(302, 42);
            txtCard.Name = "txtCard";
            txtCard.Size = new Size(125, 27);
            txtCard.TabIndex = 7;
            // 
            // txtTargetCard
            // 
            txtTargetCard.Location = new Point(302, 270);
            txtTargetCard.Name = "txtTargetCard";
            txtTargetCard.Size = new Size(125, 27);
            txtTargetCard.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 49);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 9;
            label1.Text = "Номер картки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 103);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 10;
            label2.Text = "PIN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 273);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 11;
            label3.Text = "Картка отримувача";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 220);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 12;
            label4.Text = "Сума";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTargetCard);
            Controls.Add(txtCard);
            Controls.Add(txtPin);
            Controls.Add(txtAmount);
            Controls.Add(btnTransfer);
            Controls.Add(btnDeposit);
            Controls.Add(btnWithdraw);
            Controls.Add(btnBalance);
            Controls.Add(btnLogin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnBalance;
        private Button btnWithdraw;
        private Button btnDeposit;
        private Button btnTransfer;
        private TextBox txtAmount;
        private TextBox txtPin;
        private TextBox txtCard;
        private TextBox txtTargetCard;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
