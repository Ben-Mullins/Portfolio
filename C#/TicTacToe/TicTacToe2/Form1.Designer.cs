namespace TicTacToe2
{
    partial class Form1
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
            this.btnStartGame = new System.Windows.Forms.Button();
            this.StatsBox = new System.Windows.Forms.GroupBox();
            this.GameTies = new System.Windows.Forms.Label();
            this.Player2Wins = new System.Windows.Forms.Label();
            this.Player1Wins = new System.Windows.Forms.Label();
            this.StatusBox = new System.Windows.Forms.GroupBox();
            this.GameStatus = new System.Windows.Forms.Label();
            this.HorizontalGrid1 = new System.Windows.Forms.Label();
            this.HorizontalGrid2 = new System.Windows.Forms.Label();
            this.VerticalGrid1 = new System.Windows.Forms.Label();
            this.VerticalGrid2 = new System.Windows.Forms.Label();
            this.lbl22 = new System.Windows.Forms.Label();
            this.lbl21 = new System.Windows.Forms.Label();
            this.lbl20 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl02 = new System.Windows.Forms.Label();
            this.lbl01 = new System.Windows.Forms.Label();
            this.lbl00 = new System.Windows.Forms.Label();
            this.StatsBox.SuspendLayout();
            this.StatusBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(508, 349);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(196, 59);
            this.btnStartGame.TabIndex = 33;
            this.btnStartGame.Text = "Start New Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // StatsBox
            // 
            this.StatsBox.Controls.Add(this.GameTies);
            this.StatsBox.Controls.Add(this.Player2Wins);
            this.StatsBox.Controls.Add(this.Player1Wins);
            this.StatsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsBox.Location = new System.Drawing.Point(508, 80);
            this.StatsBox.Name = "StatsBox";
            this.StatsBox.Size = new System.Drawing.Size(196, 187);
            this.StatsBox.TabIndex = 32;
            this.StatsBox.TabStop = false;
            this.StatsBox.Text = "Overall Statistics";
            // 
            // GameTies
            // 
            this.GameTies.AutoSize = true;
            this.GameTies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTies.Location = new System.Drawing.Point(57, 102);
            this.GameTies.Name = "GameTies";
            this.GameTies.Size = new System.Drawing.Size(43, 15);
            this.GameTies.TabIndex = 3;
            this.GameTies.Text = "Ties: 0";
            // 
            // Player2Wins
            // 
            this.Player2Wins.AutoSize = true;
            this.Player2Wins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Wins.Location = new System.Drawing.Point(6, 73);
            this.Player2Wins.Name = "Player2Wins";
            this.Player2Wins.Size = new System.Drawing.Size(94, 15);
            this.Player2Wins.TabIndex = 2;
            this.Player2Wins.Text = "Player 2 Wins: 0";
            // 
            // Player1Wins
            // 
            this.Player1Wins.AutoSize = true;
            this.Player1Wins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Wins.Location = new System.Drawing.Point(6, 43);
            this.Player1Wins.Name = "Player1Wins";
            this.Player1Wins.Size = new System.Drawing.Size(94, 15);
            this.Player1Wins.TabIndex = 1;
            this.Player1Wins.Text = "Player 1 Wins: 0";
            // 
            // StatusBox
            // 
            this.StatusBox.Controls.Add(this.GameStatus);
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.Location = new System.Drawing.Point(91, 413);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(310, 77);
            this.StatusBox.TabIndex = 31;
            this.StatusBox.TabStop = false;
            this.StatusBox.Text = "Game Status";
            // 
            // GameStatus
            // 
            this.GameStatus.AutoSize = true;
            this.GameStatus.Location = new System.Drawing.Point(27, 33);
            this.GameStatus.Name = "GameStatus";
            this.GameStatus.Size = new System.Drawing.Size(218, 20);
            this.GameStatus.TabIndex = 0;
            this.GameStatus.Text = "Click Start New Game to play!";
            // 
            // HorizontalGrid1
            // 
            this.HorizontalGrid1.BackColor = System.Drawing.SystemColors.WindowText;
            this.HorizontalGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HorizontalGrid1.Location = new System.Drawing.Point(92, 133);
            this.HorizontalGrid1.Name = "HorizontalGrid1";
            this.HorizontalGrid1.Size = new System.Drawing.Size(309, 10);
            this.HorizontalGrid1.TabIndex = 30;
            // 
            // HorizontalGrid2
            // 
            this.HorizontalGrid2.BackColor = System.Drawing.SystemColors.WindowText;
            this.HorizontalGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HorizontalGrid2.Location = new System.Drawing.Point(91, 238);
            this.HorizontalGrid2.Name = "HorizontalGrid2";
            this.HorizontalGrid2.Size = new System.Drawing.Size(309, 10);
            this.HorizontalGrid2.TabIndex = 29;
            // 
            // VerticalGrid1
            // 
            this.VerticalGrid1.BackColor = System.Drawing.SystemColors.WindowText;
            this.VerticalGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerticalGrid1.Location = new System.Drawing.Point(296, 38);
            this.VerticalGrid1.Name = "VerticalGrid1";
            this.VerticalGrid1.Size = new System.Drawing.Size(10, 306);
            this.VerticalGrid1.TabIndex = 28;
            // 
            // VerticalGrid2
            // 
            this.VerticalGrid2.BackColor = System.Drawing.SystemColors.WindowText;
            this.VerticalGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerticalGrid2.Location = new System.Drawing.Point(186, 38);
            this.VerticalGrid2.Name = "VerticalGrid2";
            this.VerticalGrid2.Size = new System.Drawing.Size(10, 305);
            this.VerticalGrid2.TabIndex = 27;
            // 
            // lbl22
            // 
            this.lbl22.BackColor = System.Drawing.SystemColors.Control;
            this.lbl22.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl22.Location = new System.Drawing.Point(312, 248);
            this.lbl22.Name = "lbl22";
            this.lbl22.Size = new System.Drawing.Size(88, 95);
            this.lbl22.TabIndex = 26;
            this.lbl22.Text = "X";
            this.lbl22.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl21
            // 
            this.lbl21.BackColor = System.Drawing.SystemColors.Control;
            this.lbl21.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl21.Location = new System.Drawing.Point(202, 248);
            this.lbl21.Name = "lbl21";
            this.lbl21.Size = new System.Drawing.Size(88, 95);
            this.lbl21.TabIndex = 25;
            this.lbl21.Text = "O";
            this.lbl21.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl20
            // 
            this.lbl20.BackColor = System.Drawing.SystemColors.Control;
            this.lbl20.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl20.Location = new System.Drawing.Point(92, 248);
            this.lbl20.Name = "lbl20";
            this.lbl20.Size = new System.Drawing.Size(88, 95);
            this.lbl20.TabIndex = 24;
            this.lbl20.Text = "X";
            this.lbl20.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl12
            // 
            this.lbl12.BackColor = System.Drawing.SystemColors.Control;
            this.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl12.Location = new System.Drawing.Point(312, 143);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(88, 95);
            this.lbl12.TabIndex = 23;
            this.lbl12.Text = "X";
            this.lbl12.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl11
            // 
            this.lbl11.BackColor = System.Drawing.SystemColors.Control;
            this.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.Location = new System.Drawing.Point(202, 143);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(88, 95);
            this.lbl11.TabIndex = 22;
            this.lbl11.Text = "O";
            this.lbl11.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl10
            // 
            this.lbl10.BackColor = System.Drawing.SystemColors.Control;
            this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.Location = new System.Drawing.Point(92, 143);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(88, 95);
            this.lbl10.TabIndex = 21;
            this.lbl10.Text = "O";
            this.lbl10.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl02
            // 
            this.lbl02.BackColor = System.Drawing.SystemColors.Control;
            this.lbl02.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl02.Location = new System.Drawing.Point(311, 38);
            this.lbl02.Name = "lbl02";
            this.lbl02.Size = new System.Drawing.Size(88, 95);
            this.lbl02.TabIndex = 20;
            this.lbl02.Text = "O";
            this.lbl02.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl01
            // 
            this.lbl01.BackColor = System.Drawing.SystemColors.Control;
            this.lbl01.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl01.Location = new System.Drawing.Point(201, 38);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(88, 95);
            this.lbl01.TabIndex = 19;
            this.lbl01.Text = "X";
            this.lbl01.Click += new System.EventHandler(this.spaceClick);
            // 
            // lbl00
            // 
            this.lbl00.BackColor = System.Drawing.SystemColors.Control;
            this.lbl00.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F);
            this.lbl00.Location = new System.Drawing.Point(91, 38);
            this.lbl00.Name = "lbl00";
            this.lbl00.Size = new System.Drawing.Size(88, 95);
            this.lbl00.TabIndex = 18;
            this.lbl00.Text = "X";
            this.lbl00.Click += new System.EventHandler(this.spaceClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 514);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.StatsBox);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.HorizontalGrid1);
            this.Controls.Add(this.HorizontalGrid2);
            this.Controls.Add(this.VerticalGrid1);
            this.Controls.Add(this.VerticalGrid2);
            this.Controls.Add(this.lbl22);
            this.Controls.Add(this.lbl21);
            this.Controls.Add(this.lbl20);
            this.Controls.Add(this.lbl12);
            this.Controls.Add(this.lbl11);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.lbl00);
            this.Name = "Form1";
            this.Text = "Form1";
            this.StatsBox.ResumeLayout(false);
            this.StatsBox.PerformLayout();
            this.StatusBox.ResumeLayout(false);
            this.StatusBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.GroupBox StatsBox;
        private System.Windows.Forms.Label GameTies;
        private System.Windows.Forms.Label Player2Wins;
        private System.Windows.Forms.Label Player1Wins;
        private System.Windows.Forms.GroupBox StatusBox;
        private System.Windows.Forms.Label GameStatus;
        private System.Windows.Forms.Label HorizontalGrid1;
        private System.Windows.Forms.Label HorizontalGrid2;
        private System.Windows.Forms.Label VerticalGrid1;
        private System.Windows.Forms.Label VerticalGrid2;
        private System.Windows.Forms.Label lbl22;
        private System.Windows.Forms.Label lbl21;
        private System.Windows.Forms.Label lbl20;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label lbl00;
    }
}

