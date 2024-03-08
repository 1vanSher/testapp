using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Npgsql;
using testapp;

namespace testapp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            productToUser();
        }
        
        public void productToUser()
        {
            List<Product> allproducts = Connect.getlistproducts("SELECT * FROM product ORDER BY id ASC");
            for(int i = 0; i < 5; i++)
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
    }
}
