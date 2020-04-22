using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.OracleClient;

namespace PIEBox
{
    public partial class LoginForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try {
                SQLHelper db = new SQLHelper();
                String sql = "select * from Emp where ename='" + textUser.Text + "' AND PWD='" + textPwd.Text + "'";
                DataTable dt = SQLHelper.select(sql);
                if (dt.Rows.Count == 1)
                 {
                     //MessageBox.Show("登陆成功");
                     //Form1 fr1 = new Form1();
                     MainForm fr1 = new MainForm();
                     fr1.Show();
                     LoginForm lf = new LoginForm();
                     lf.Close();
                 }else if (dt.Rows.Count == 0)
                 {
                     MessageBox.Show("登陆失败!你输入的用户名不存在!");
                 }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            //取消
        }
    }
}
