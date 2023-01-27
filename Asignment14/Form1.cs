using System;
using System.IO;
using System.Windows.Forms;
namespace Asignment14
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            Clear();
            if (File.Exists(FileName))
            {
                StreamReader RestoreData = new StreamReader(FileName);
string Rows=                RestoreData.ReadToEnd();
                string Row1 = Rows.Split('\n')[0];
                TXT1_1.Text = Row1.Split(',')[0];
                TXT2_1.Text = Row1.Split(',')[1];
                TXT3_1.Text = Row1.Split(',')[2];
                string Row2 = Rows.Split('\n')[1];
                TXT1_2.Text = Row2.Split(',')[0];
                TXT2_2.Text = Row2.Split(',')[1];
                TXT3_2.Text = Row2.Split(',')[2];
                string Row3 = Rows.Split('\n')[2];
                TXT1_3.Text = Row3.Split(',')[0];
                TXT2_3.Text = Row3.Split(',')[1];
                TXT3_3.Text = Row3.Split(',')[2];
                RestoreData.Close();
            }
            FilSummery();
        }
        public void FilSummery()
        {
            Summery.ReadOnly = true;
            Summery.Text = "لقد سَبَّحْتَ الله :" + TXT3_1.Text + "\n" + "لقد حَمِدّْتَ الله :" + TXT3_2.Text + "\n" + "لقد كَبَّرْتَ الله :" + TXT3_3.Text + "\n" + "إجمالي عدد التسبيحات هو: " +(int.Parse(TXT3_1.Text)+int.Parse(TXT3_2.Text)+int.Parse(TXT3_3.Text))+ " تسبيحة";
        }
        public void Clear()
        {
            foreach (Control c in ControlsContainer.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                    c.Text = "0";
                }
            }
            FilSummery();
        }
        public void FilData(TextBox data1, TextBox data2, TextBox data3)
        {
            int count = Convert.ToInt32(data1.Text);
            if (count == 33)
            {
                count = 0;
                int loop = Convert.ToInt32(data2.Text);
                loop++;
                data2.Text = loop+"";
            }
            count++;
            data1.Text = count+"";
            int total = Convert.ToInt32(data3.Text);
            total++;
            data3.Text = total+"";
            FilSummery();
        }
        string FileName = "APPData.txt";
        public void Save()
        {
            StreamWriter BackupData= new StreamWriter(FileName);            
            BackupData.WriteLine(TXT1_1.Text+","+TXT2_1.Text+","+TXT3_1.Text+"\n"+ TXT1_2.Text + "," + TXT2_2.Text + "," + TXT3_2.Text + "\n"+ TXT1_3.Text + "," + TXT2_3.Text + "," + TXT3_3.Text);
            BackupData.Close();
        }
        private void BTNClear_Click(object sender, System.EventArgs e)
        {
            Clear();
        }
        private void BTN1_Click(object sender, System.EventArgs e)
        {
            FilData(TXT1_1,TXT2_1,TXT3_1);
}
        private void BTN2_Click(object sender, EventArgs e)
        {
            FilData(TXT1_2,TXT2_2,TXT3_2);
        }
        private void BTN3_Click(object sender, EventArgs e)
        {
            FilData(TXT1_3,TXT2_3,TXT3_3);
        }
        private void BTNSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void BTNExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("هل تريد حفظ التسبيحات الجديدة؟","خروج",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
            {
                Save();
            }
            Application.Exit();
        }
    }
}