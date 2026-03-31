using System;
using System.IO;
using System.Windows.Forms;

namespace Quiz_med_api
{
    public partial class Form1 : Form
    {
        ApiClient api = new ApiClient();
        QuizQuestion q;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            LoadQ();
        }

        async void LoadQ()
        {
            q = await api.GetQuestion();

            tblquestion.Text = q.Question;

            if (q.Answers.Count < 4)
            {
                MessageBox.Show("Fel vid fråga");
                return;
            }

            button1.Text = q.Answers[0];
            button2.Text = q.Answers[1];
            button3.Text = q.Answers[2];
            button4.Text = q.Answers[3];
        }

        void Check(string answer)
        {
            if (answer == q.CorrectAnswer)
            {
                score++;
                MessageBox.Show("Rätt!");
            }
            else
            {
                MessageBox.Show("Fel! Rätt svar: " + q.CorrectAnswer);
            }

            tblScore.Text = "Poäng: " + score;
        }

        void ClickBtn(string text)
        {
            Check(text);
            LoadQ();
        }

        private void button1_Click(object sender, EventArgs e) => ClickBtn(button1.Text);
        private void button2_Click(object sender, EventArgs e) => ClickBtn(button2.Text);
        private void button3_Click(object sender, EventArgs e) => ClickBtn(button3.Text);
        private void button4_Click(object sender, EventArgs e) => ClickBtn(button4.Text);

        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadQ();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("result.txt", "Poäng: " + score);
        }
    }
}