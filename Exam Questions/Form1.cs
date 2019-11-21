using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Exam_Questions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnglish_Click(object sender, EventArgs e)
        {

             string conString = "server=server1.logicalview.co.uk;user=c462CollabRyan;database=c462Ws226208Collab;password=Weaver@90;charset=utf8";

            MySqlConnection mySQLCon = new MySqlConnection(conString);
            string sqlComString = "SELECT `tbl_Questions`.`question`"+
               "FROM `tbl_Questions` "+
               "INNER JOIN `tbl_Exam` ON `tbl_Questions`.`exam_id`=`tbl_Exam`.`exam_id`"+
               " WHERE `tbl_Exam`.`exam_id`= '2'";

            MySqlCommand mySQLCom = new MySqlCommand(sqlComString, mySQLCon);
            DataTable dtQuestions = new DataTable();

            MySqlDataAdapter mySQLData = new MySqlDataAdapter(mySQLCom);

            try
            {
                mySQLCon.Open();
                mySQLData.Fill(dtQuestions);
                mySQLCon.Close();
            }
            catch (Exception ex)
            {
                //Create Error Message
                MessageBox.Show("Error, Couldn't load questions");
            }
            lblQuestionOne.Text = dtQuestions.Rows[0][0].ToString();
            lblQuestionTwo.Text = dtQuestions.Rows[1][0].ToString();
            lblQuestionThree.Text = dtQuestions.Rows[2][0].ToString();

            lblQuestionOne.Visible = true;
            lblQuestionTwo.Visible = true;
            lblQuestionThree.Visible = true;
            txtAnswerOne.Visible = true;
            txtAnswerTwo.Visible = true;
            txtAnswerThree.Visible = true;
        }

        private void BtnAnswers_Click(object sender, EventArgs e)
        {

            string conString = "server=server1.logicalview.co.uk;user=c462CollabRyan;database=c462Ws226208Collab;password=Weaver@90;charset=utf8";

            MySqlConnection mySQLCon = new MySqlConnection(conString);
            string sqlComString = "SELECT `tbl_Questions`.`answer`" +
               "FROM `tbl_Questions` " +
               "INNER JOIN `tbl_Exam` ON `tbl_Questions`.`exam_id`=`tbl_Exam`.`exam_id`" +
               " WHERE `tbl_Exam`.`exam_id`= '2'";

            MySqlCommand mySQLCom = new MySqlCommand(sqlComString, mySQLCon);
            DataTable dtAnswers = new DataTable();

            MySqlDataAdapter mySQLData = new MySqlDataAdapter(mySQLCom);

            try
            {
                mySQLCon.Open();
                mySQLData.Fill(dtAnswers);
                mySQLCon.Close();
            }
            catch (Exception ex)
            {
                //Create Error Message
                MessageBox.Show("Error, Couldn't load Answers");
            }

            int iCorrect = 0;

            if(txtAnswerOne.Text.ToLower() == dtAnswers.Rows[0][0].ToString().ToLower())
            {
                iCorrect++;
            }
            if (txtAnswerTwo.Text.ToLower() == dtAnswers.Rows[1][0].ToString().ToLower())
            {
                iCorrect++;
            }
            if (txtAnswerThree.Text.ToLower() == dtAnswers.Rows[2][0].ToString().ToLower())
            {
                iCorrect++;
            }

            // Reveals the hidden labels for results
            label6.Visible = true;
            lblTotalQuestions.Visible = true;
            lblScore.Visible = true;
            label8.Visible = true;

            lblScore.Text = iCorrect.ToString(); // Changes the results label to match actual results

        }
    }
}
