using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        public setText SetT;
        public setProgressValue SetP;
        private int fileNum = 100, lineNum = 100000;
        private static DBInserter dBins;
        private const string eng_chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string rus_chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        internal static DBInserter DBins { get => dBins; set => dBins = value; }

        public Form1()
        {
            InitializeComponent();
            SetT = new setText(SetText);
            SetP = new setProgressValue(SetProg);
            DBInserter.SetTextEvent += SetText;
            DBInserter.SetProgressValueEvent += SetProg;

        }
        /// <summary>
        /// Set Value for progress bar
        /// </summary>
        public void SetProg(int am)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(SetP, am);
                return;
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = am;
        }
        /// <summary>
        /// Set text to progress label
        /// </summary>
        public void SetText(string str)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(SetT, str);
                return;
            }
            countLabel.Text = str;
            progressBar1.Increment(1);
        }
        /// <summary>
        /// Generate files button click
        /// </summary>
        private void generateFiles_Click(object sender, EventArgs e)
        {
            if (lineTextBox.Text != "" && Int32.TryParse(lineTextBox.Text, out lineNum)) lineNum = Convert.ToInt32(lineTextBox.Text);
            if (fileTextBox.Text != "" && Int32.TryParse(fineTextBox.Text, out fileNum)) fileNum = Convert.ToInt32(fileTextBox.Text);
            for (int i = 0;i< fileNum; i++)
            {
                using (StreamWriter bw = new StreamWriter(new FileStream(i + ".txt", FileMode.Create))){
                    for (int j = 0; j < lineNum; j++)
                    {
                        DateTime start = new DateTime(2013, 1, 1);
                        int range = (DateTime.Today - start).Days;
                        DateTime randomDate = start.AddDays(random.Next(range));

                        string randomLatin = RandomString(10, eng_chars + eng_chars.ToLower());
                        string randomCyr = RandomString(10, rus_chars + rus_chars.ToLower());
                        int randomInt = random.Next(1, 100000001);
                        int r = random.Next(100000000, 2000000000);
                        double randomDouble = (double)r / 100000000.0;
                        //Console.WriteLine(randomDate.ToString("dd.MM.yyyy")+"||" + randomLatin+"||"+randomCyr+"||"+randomInt+"||"+randomDouble);

                        //writing into the file
                        try
                        {
                            bw.WriteLine(randomDate.ToString("dd.MM.yyyy") + "||" + randomLatin + "||" + randomCyr + "||" + randomInt + "||" + randomDouble);
                        }
                        catch (IOException er)
                        {
                            MessageBox.Show(er.Message);
                            return;
                        }
                    }
                    
                }
                
            }
            labelProc.Text = "Done";
            mergeFiles.Enabled = true;
           
        }
        public string RandomString(int length, string alpChars)
        {
            return new string(Enumerable.Repeat(alpChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Merge files button click
        /// </summary>
        private void mergeFiles_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string comb = combTextBox.Text;
            string[]  txtFiles = Directory.GetFiles(path, "*.txt");
            int counter = 0;
            using (StreamWriter writer = new StreamWriter("all.txt"))
            {
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    if (!txtFiles[i].Contains("all.txt"))
                    {
                        using (StreamReader reader = File.OpenText(txtFiles[i]))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (comb != "" && line.Contains(comb))
                                {
                                    counter++;
                                    continue;
                                }
                                writer.WriteLine(line);
                            }
                        }
                        System.IO.File.Delete(txtFiles[i]);
                    }
                       
                }
            }
            labelMerg.Text = "Merged, deleted strings:" + counter;

            importToDB.Enabled = true;
        }
        /// <summary>
        /// Insert lines to db button click
        /// </summary>
        private void importToDB_Click(object sender, EventArgs e)
        {
            dBins = new DBInserter();
            dBins.Run();
            getMedian.Enabled = true;
            getSum.Enabled = true;
        }
        /// <summary>
        /// Get inf from storedpProcedure button click
        /// </summary>
        private void getSum_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(dBins.connectionString))
            using (var command = new SqlCommand("CountSum", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                conn.Open();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                       textBoxSum.Text = String.Format(" {0} ", rdr["SumOfInt"]);
                    }
                }
                conn.Close();
            }
        }
        /// <summary>
        /// Get inf from storedpProcedure button click
        /// </summary>
        private void getMedian_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(dBins.connectionString))
            using (var command = new SqlCommand("CountMedian", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                conn.Open();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        textBoxMedian.Text = String.Format(" {0} ", rdr["DoubleMedian"]);
                    }
                }
                conn.Close();
            }
        }
    }
}
