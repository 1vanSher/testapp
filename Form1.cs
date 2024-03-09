using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Npgsql;
using testapp;
using System.Security.Cryptography.X509Certificates;

namespace testapp
{
    public partial class Form1 : Form
    {
        public List<Product> allproducts = Connect.getlistproducts("SELECT * FROM product ORDER BY id ASC");
        public Form1()
        {
            InitializeComponent();
            productToUser();
        }

        public void productToUser()
        {
            int currentpage = 0;
            for (int i = 20 * currentpage; i < 20 * (currentpage + 1); i++)
            {
                UserControl1 uc = new UserControl1();
                uc.Size = new Size(447, 127);
                uc.product = allproducts[i];
                uc.label1.Text = allproducts[i].producttypeid.ToString();
                uc.label2.Text = allproducts[i].title;
                uc.label3.Text = allproducts[i].articlenumber.ToString();
                uc.label4.Text = allproducts[i].mincostforagent.ToString();
                flowLayoutPanel1.Controls.Add(uc);
            }
        }

        public int checkendpage()
        {
            int endpage;

            if (allproducts.Count % 20 != 0)
            {
                endpage = allproducts.Count / 20 + 1;
            }
            else
            {
                endpage = allproducts.Count / 20;
            }
            return endpage;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
