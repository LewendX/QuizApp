namespace Quiz_med_api
{
    partial class Form1
    {
        System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tblquestion = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            tblScore = new Label();
            btnNext = new Button();

            SuspendLayout();

            tblquestion.AutoSize = true;
            tblquestion.Location = new Point(20, 20);
            tblquestion.Text = "Question will appear here";

            button1.Location = new Point(20, 60);
            button1.Size = new Size(360, 40);
            button1.Text = "Answer 1";
            button1.Click += button1_Click;

            button2.Location = new Point(20, 110);
            button2.Size = new Size(360, 40);
            button2.Text = "Answer 2";
            button2.Click += button2_Click;

            button3.Location = new Point(20, 160);
            button3.Size = new Size(360, 40);
            button3.Text = "Answer 3";
            button3.Click += button3_Click;

            button4.Location = new Point(20, 210);
            button4.Size = new Size(360, 40);
            button4.Text = "Answer 4";
            button4.Click += button4_Click;

            tblScore.AutoSize = true;
            tblScore.Location = new Point(20, 260);
            tblScore.Text = "Poäng: 0";

            btnNext.Location = new Point(300, 260);
            btnNext.Size = new Size(80, 30);
            btnNext.Text = "Next";
            btnNext.Click += btnNext_Click;

            ClientSize = new Size(800, 450);
            Controls.AddRange(new Control[] {
                tblquestion, button1, button2, button3, button4, tblScore, btnNext
            });

            Text = "Form1";
            ResumeLayout(false);
        }

        Label tblquestion;
        Button button1;
        Button button2;
        Button button3;
        Button button4;
        Label tblScore;
        Button btnNext;
    }
}