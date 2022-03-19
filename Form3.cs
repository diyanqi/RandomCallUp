using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RandomCallUp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        public static string GetConnectionString(string value)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            //var configurationBuilder = new ConfigurationBuilder()
            //    .Add(new JsonConfigurationSource { Path = "config.json", ReloadOnChange = true });

            IConfiguration config = configurationBuilder.Build();
            string connectionString = config[value];
            return connectionString;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = GetConnectionString("minnumber");
            textBox2.Text = GetConnectionString("maxnumber");
            textBox3.Text = GetConnectionString("loadtime");
            textBox4.Text = GetConnectionString("loaddelta");
            textBox5.Text = GetConnectionString("namelist").Replace("\n", "\r\n");
            if (GetConnectionString("colormode") == "light")
            {
                light.Checked = true;
                dark.Checked = false;
            }else if (GetConnectionString("colormode") == "dark")
            {
                light.Checked = false;
                dark.Checked = true;
            }
        }

        public static void set_config(int minnumber, int maxnumber, double loadtime, double loaddelta, string namelist, string colormode)
        {
            try
            {
                StreamReader reader = File.OpenText("config.json");
                JsonTextReader jsonTextReader = new JsonTextReader(reader);
                JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
                jsonObject["minnumber"] = minnumber;
                jsonObject["maxnumber"] = maxnumber;
                jsonObject["loadtime"] = loadtime;
                jsonObject["loaddelta"] = loaddelta;
                jsonObject["namelist"] = namelist;
                jsonObject["colormode"] = colormode;
                reader.Close();
                string output = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText("config.json", output);
            }
            catch
            {
                //自己加点
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int minn, maxn;
            double loadt, loadd;
            if(int.TryParse(textBox1.Text, out minn) && int.TryParse(textBox2.Text, out maxn) && double.TryParse(textBox3.Text, out loadt) && double.TryParse(textBox4.Text, out loadd))
            {
                string colormode="light";
                if (light.Checked)
                {
                    colormode = "light";
                }else if (dark.Checked)
                {
                    colormode = "dark";
                }
                set_config(minn, maxn, loadt, loadd, textBox5.Text.Replace("\r\n","\n"),colormode);
                this.Close();
            }
            else
            {
                MessageBox.Show("请检查输入的是否为合法的数字！前两个只能是整数，后两个可以是小数！", "Oops!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameliststr = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "文本文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                String line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(fName);
                    textBox5.Text = "";
                    //Read the first line of text
                    line = sr.ReadLine();
                    nameliststr += line + "\n";
                    textBox5.Text += line + "\r\n";
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        Console.WriteLine(line);
                        //Read the next line
                        line = sr.ReadLine();
                        nameliststr += line + "\n";
                        textBox5.Text+=line+"\r\n";
                    }
                    //set_config(int.Parse(GetConnectionString("minnumber")), int.Parse(GetConnectionString("maxnumber")), double.Parse(GetConnectionString("loadtime")), double.Parse(GetConnectionString("loaddelta")), nameliststr);
                    //close the file
                    sr.Close();
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Exception");
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ;
        }
    }
}
