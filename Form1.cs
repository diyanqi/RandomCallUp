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
            public static string[] waittext = new string[6] { "抽取ing", "Bing!", "Bong!", "好運來", "666", "阿巴阿巴" };
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
                            if(int.TryParse(this.result.Text,out none))//上次是数字
                            {
                                this.result.Font = new Font("Microsoft YaHei UI", (float)(this.result.Font.Size*0.6), FontStyle.Bold);
                            }
                            PublicValue.numorname = "name";
                            this.result.Text = namelist[rannumber - PublicValue.minnumber];
                        }
                        else
                        {
                            if (! int.TryParse(this.result.Text, out none))//上次是名字
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
                    this.ranget.Text = "随机抽取!";
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
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 0;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            if (this.TopMost == true)
            {
                toolTip1.SetToolTip(this.top, "已置顶");
            }
            else
            {
                toolTip1.SetToolTip(this.top, "置顶");//设置提示按钮和提示内容
            }
        }

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
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
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    int none;
                    Single currentSize;
                    if (!int.TryParse(this.result.Text, out none))
                    {
                        currentSize = (float)(System.Convert.ToSingle(mytag[4]) * newy*0.6);//字体大小
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