using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericExercise
{
    public partial class Form1 : Form
    {
        private struct Grade
        {
            public int maxPoints;
            public string gradeLetter;
        }
        private List<Grade> gradeList = new List<Grade>();

        Grade f = new Grade();
        Grade d = new Grade();
        Grade c = new Grade();
        Grade b = new Grade();
        Grade a = new Grade();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f.maxPoints = 299;
            f.gradeLetter = "F";

            
            d.maxPoints = 349;
            d.gradeLetter = "D";

            
            c.maxPoints = 399;
            c.gradeLetter = "C";

            
            b.maxPoints = 449;
            b.gradeLetter = "B";

            
            a.maxPoints = 500;
            a.gradeLetter = "A";

            gradeList.Add(f);
            gradeList.Add(d);
            gradeList.Add(c);
            gradeList.Add(b);
            gradeList.Add(a);

        }

        private void btnFindScore_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(txtScore.Text);
            string message = string.Empty;

            if(score > 500 || score < 0)
            {
                message = $"{score} is not a valid score.";
            }
            else
            {
                foreach (Grade grade in gradeList)
                {
                    if(score <= grade.maxPoints)
                    {
                        message = grade.gradeLetter;
                    }
                }

            }

            //if(score > a.maxPoints)
            //{
            //    message = $"{score} is not a valid score.";
            //}
            //else if(score > b.maxPoints)
            //{
            //    message = a.gradeLetter;
            //}
            //else if (score > c.maxPoints)
            //{
            //    message = b.gradeLetter;
            //}
            //else if (score > d.maxPoints)
            //{
            //    message = c.gradeLetter;
            //}
            //else if (score > f.maxPoints)
            //{
            //    message = d.gradeLetter;
            //}
            //else
            //{
            //    message = f.gradeLetter;
            //}


            MessageBox.Show(message);
        }


    }
}
