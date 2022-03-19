using Microsoft.Extensions.Configuration;

namespace RandomCallUp
{
    public partial class Form1 : Form
    {
        public class PublicValue
        {
            public static int maxnumber = 50;
            public static int minnumber = 1;
            public static double loadtime = 0.5;
            public static double loaddelta = 0.1;
            public static string[] waittext = new string[6] { "��ȡing", "Bing!", "Bong!", "���\��", "666", "���Ͱ���" };
            public static string numorname = "num";
        }

        public Form1()
        {
            InitializeComponent();
            x = this.Width;
            y = this.Height;
            setTag(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {

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

        private void ranget_Click(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(async () =>
            {
                
                this.Invoke(new EventHandler(delegate
                {
                    if (this.result.ForeColor == Color.Red)
                    {
                        this.result.ForeColor = Color.Black;
                    }
                }));
                double.TryParse(GetConnectionString("loadtime"), out PublicValue.loadtime);
                double.TryParse(GetConnectionString("loaddelta"), out PublicValue.loaddelta);
                int.TryParse(GetConnectionString("minnumber"), out PublicValue.minnumber);
                int.TryParse(GetConnectionString("maxnumber"), out PublicValue.maxnumber);
                string namestr = GetConnectionString("namelist");
                string[] namelist = namestr.Split('\n');
                int namelistlen = namelist.Length;
                if (namestr.Length == 0)
                {
                    namelistlen = 0;
                }
                this.Invoke(new EventHandler(delegate
                {
                    Random rdx = new Random();
                    this.ranget.Text = PublicValue.waittext[rdx.Next(0, PublicValue.waittext.Length)];
                    this.ranget.Enabled = false;
                }));
                Random rd = new Random();
                for (double i = 0; i < PublicValue.loadtime; i += PublicValue.loaddelta)
                {
                    await Task.Delay(100);
                    this.Invoke(new EventHandler(delegate
                    {
                        int rannumber = rd.Next(PublicValue.minnumber, PublicValue.maxnumber + 1);
                        int none;
                        if(rannumber <= namelistlen)
                        {
                            if(int.TryParse(this.result.Text,out none))//�ϴ�������
                            {
                                this.result.Font = new Font("Microsoft YaHei UI", (float)(this.result.Font.Size*0.6), FontStyle.Bold);
                            }
                            PublicValue.numorname = "name";
                            this.result.Text = namelist[rannumber - PublicValue.minnumber];
                        }
                        else
                        {
                            if (! int.TryParse(this.result.Text, out none))//�ϴ�������
                            {
                                this.result.Font = new Font("Microsoft YaHei UI", (float)(this.result.Font.Size / 0.6), FontStyle.Bold);
                            }
                            PublicValue.numorname = "num";
                            this.result.Text = rannumber.ToString();
                        }
                    }));
                }
                this.Invoke(new EventHandler(delegate
                {
                    this.ranget.Text = "�����ȡ!";
                    this.ranget.Enabled = true;
                    this.result.ForeColor = Color.Red;
                }));
                await Task.Delay(1000);
                this.Invoke(new EventHandler(delegate
                {
                    this.result.ForeColor = Color.Black;
                }));
            });
        }

        private void top_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
                top.ForeColor = Color.Black;
            }
            else
            {
                this.TopMost= true;
                top.ForeColor = Color.Red;
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void top_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 0;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            if (this.TopMost == true)
            {
                toolTip1.SetToolTip(this.top, "���ö�");
            }
            else
            {
                toolTip1.SetToolTip(this.top, "�ö�");//������ʾ��ť����ʾ����
            }
        }

        #region �ؼ���С�洰���С�ȱ�������
        private float x;//���嵱ǰ����Ŀ��
        private float y;//���嵱ǰ����ĸ߶�
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //���������еĿؼ����������ÿؼ���ֵ
            foreach (Control con in cons.Controls)
            {
                //��ȡ�ؼ���Tag����ֵ�����ָ��洢�ַ�������
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //���ݴ������ŵı���ȷ���ؼ���ֵ
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//���
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//�߶�
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//��߾�
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//���߾�
                    int none;
                    Single currentSize;
                    if (!int.TryParse(this.result.Text, out none))
                    {
                        currentSize = (float)(System.Convert.ToSingle(mytag[4]) * newy*0.6);//�����С
                    }
                    else
                    {
                        currentSize = (float)(System.Convert.ToSingle(mytag[4]) * newy);
                    }
                    //currentSize = ((float)((float) System.Convert.ToSingle(mytag[4]) * newy * 0.6));
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }

        #endregion

        private void settings_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}