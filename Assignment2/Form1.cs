using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        private int activeQuestion;
        private int maxQuestion;
        private string[] questions;
        private char[] selectedAns;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(350, 662);
            groupBox2.SetBounds(50, 100, 275, 475);
            groupBox3.SetBounds(50, 100, 275, 475);
            activeQuestion = 0;
            Main frmMain = new Main();
            labCanID.Text = frmMain.getCanID();
            flag.Image = Image.FromFile("Georgia.png"); 
            loadQuestionFile();
        }

        private void loadQuestionFile()
        {
            StreamReader datafile;
            string aLine;
            try
            {
                datafile = new StreamReader("questions.txt");
                aLine = datafile.ReadLine();
                maxQuestion = Convert.ToInt32(aLine);
                questions = new string[maxQuestion];
                selectedAns = new char[maxQuestion];
                int k = 0;
                while (datafile.Peek() != -1)
                {
                    questions[k] = datafile.ReadLine();
                    k++;
                }
                datafile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRORRRR : " + ex.Message);
            }
        }


        private void displayQuestion()
        {
            string aLine;

            aLine = questions[activeQuestion];
            string[] wordList = Regex.Split(aLine, @":");
            int quesType = Convert.ToInt32(wordList[0]);
            if (quesType == 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                radType1A.Checked = false;
                radType1B.Checked = false;
                radType1C.Checked = false;
                radType1D.Checked = false;
                if (selectedAns[activeQuestion] == 'A')
                    radType1A.Checked = true;
                else if (selectedAns[activeQuestion] == 'B')
                    radType1B.Checked = true;
                else if (selectedAns[activeQuestion] == 'C')
                    radType1C.Checked = true;
                else if (selectedAns[activeQuestion] == 'D')
                    radType1D.Checked = true;


                labQType1.Text = wordList[2];
                radType1A.Text = wordList[3];
                radType1B.Text = wordList[4];
                radType1C.Text = wordList[5];
                radType1D.Text = wordList[6];
            }
            else if (quesType == 2)
            {
                radType2A.Checked = false;
                radType2B.Checked = false;
                radType2C.Checked = false;
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                if (selectedAns[activeQuestion] == 'A')
                    radType2A.Checked = true;
                else if (selectedAns[activeQuestion] == 'B')
                    radType2B.Checked = true;
                else if (selectedAns[activeQuestion] == 'C')
                    radType2C.Checked = true;
                else if (selectedAns[activeQuestion] == 'D')
                    radType2D.Checked = true;

                labQType2.Text = wordList[2];
                string picFile = wordList[3];
                picQuestion.Image = Image.FromFile(picFile);
                radType2A.Text = wordList[4];
                radType2B.Text = wordList[5];
                radType2C.Text = wordList[6];
                radType2D.Text = wordList[7];
            }
            else if (quesType == 3)
            {
                radType3A.Checked = false;
                radType3B.Checked = false;
                radType3C.Checked = false;
                radType3D.Checked = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                if (selectedAns[activeQuestion] == 'A')
                    radType3A.Checked = true;
                else if (selectedAns[activeQuestion] == 'B')
                    radType3B.Checked = true;
                else if (selectedAns[activeQuestion] == 'C')
                    radType3C.Checked = true;
                else if (selectedAns[activeQuestion] == 'D')
                    radType3D.Checked = true;

                labQType3.Text = wordList[2];
                string picFile = wordList[3];
                string picFile2 = wordList[4];
                string picFile3 = wordList[5];
                string picFile4 = wordList[6];



                picAnswer1.Image = Image.FromFile(picFile);
                picAnswer2.Image = Image.FromFile(picFile2);
                picAnswer3.Image = Image.FromFile(picFile3);
                picAnswer4.Image = Image.FromFile(picFile4);

                radType3A.Text = "";
                radType3B.Text = "";
                radType3C.Text = "";
                radType3D.Text = "";
            }


            labActiveQuestion.Text = (activeQuestion + 1) + " of " + maxQuestion;
            labDebug.Text = "";

            if (activeQuestion == 0)
            {
                btnPrev.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (maxQuestion == (activeQuestion + 1))
            {
                btnPrev.Enabled = true;
                btnNext.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            activeQuestion++;
            displayQuestion();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            activeQuestion--;
            displayQuestion();
        }

        private void radType1A_Click(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'A';
        }

        private void radType1B_Click(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'B';
        }

        private void radType1C_Click(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'C';
        }

        private void radType2A_Click(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'A';
        }

        private void radType2B_Click(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'B';
        }

        private void radType2C_Click(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'C';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnCancel.Visible)
            {
                string filename = "result.txt";
                StreamWriter file = new StreamWriter(filename, true);
                string aLine = "\r\n";
                aLine = aLine + labCanID.Text + ":";
                aLine = aLine + labCanName.Text + ":";
                for (int k = 0; k < maxQuestion; k++)
                    aLine = aLine + selectedAns[k] + ":";
                file.Write(aLine);
                file.Close();
                Application.Exit();
            }
            else
            {
                btnCancel.Visible = true;
                btnSubmit.Text = "Submit?";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSubmit.Text = "Submit";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            displayQuestion();
        }

        private void RadType3A_CheckedChanged(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'A';
        }

        private void RadType3B_CheckedChanged(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'B';
        }

        private void RadType3C_CheckedChanged(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'C';
        }

        private void RadType1D_CheckedChanged(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'D';
        }

        private void RadType2D_CheckedChanged(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'D';
        }

        private void RadType3D_CheckedChanged(object sender, EventArgs e)
        {
            selectedAns[activeQuestion] = 'D';
        }
    }
}
