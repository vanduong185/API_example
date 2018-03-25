using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        string username = "";
        string password = "";
        HttpClient client;
        bool check = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*GetRequest(username, password).Wait();
            if (check)
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }*/
            client = new HttpClient();
            using (client)
            {
                client.BaseAddress = new Uri("http://localhost:54281/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/Account/?username=" + username).Result;
                if (res.IsSuccessStatusCode)
                {
                    AccountClient account = res.Content.ReadAsAsync<AccountClient>().Result;
                    if (account.password == password)
                    {
                        this.Hide();
                        Main ss = new Main();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password");
                    }
                    

                }
            }
            

        }

        public async Task GetRequest(string un, string pw)
        {
            client = new HttpClient();
            using (client)
            {
                client.BaseAddress = new Uri("http://localhost:54281/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Account/?username=" + un);
                if (res.IsSuccessStatusCode)
                {
                    AccountClient account = await res.Content.ReadAsAsync<AccountClient>();
                    if (account.password == pw)
                    {
                        check = true;
                    }
             
                }
            }
            
        }

        
    }
}
