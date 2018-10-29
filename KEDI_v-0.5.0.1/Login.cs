using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace KEDI_v_0._5._0._1
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void enter_Click(object sender, EventArgs e)
        {
            logIn();
        }
        private void logIn()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (usernameLocalChecker())
                {
                    usernameDBChecker(username.Text.Trim());
                }
                else MessageBox.Show("local error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Cursor.Current = Cursors.Default;
        }
        private bool usernameLocalChecker()
        {
            try
            {
                string usname = username.Text.Trim();
                if (usname != null && password.Text != null)
                    foreach (char item in usname)
                    {
                      //  int outed = -1;
                        if(item != ' ' || item != '\t' || item != '\n')
                        {
                            switch (item)
                            {
                                case '0': break;
                                case '1': break;
                                case '2': break;
                                case '3': break;
                                case '4': break;
                                case '5': break;
                                case '6': break;
                                case '7': break; 
                                case '8': break;
                                case '9': break;
                                default: return false;
                            }
                        }
                            //if (!Int32.TryParse(usname.ToString(), out outed))
                            //{
                            //return false;
                            //}
                    }
                return true;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }            
        }        
        private void usernameDBChecker(string number)
        {
            string pass = password.Text.Trim();
            try
            {
                
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from user in context.Personels
                                  where user.TelefonNum.Equals(number)
                                  where user.Sifre.Equals(pass)
                                  where user.Enabled==true
                                  select user).FirstOrDefault();
                    if(result != null)
                    {
                        enteranceCaller(result.KullaniciID,result.YetkiID);                    
                    }
                    else MessageBox.Show("Bu kullanıcı Kayıtlı değil.");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }
        private void enteranceCaller(int userID, int yetkiID)
        {
            Cursor.Current = Cursors.Default;
            logger(userID);

            Enterance.yetkiID = yetkiID;
            Enterance.userID = userID;
            var formToShow = Application.OpenForms.Cast<Form>()
                .FirstOrDefault(c => c is Enterance);
            if (formToShow != null)
            {                
                formToShow.Show();
            }
            else
            {

                Enterance enterance = new Enterance();
                enterance.Show();
            }
            username.ResetText();
            password.ResetText();
            this.Hide();                   
        }
        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                logIn();
            }
        }

        private void username_Click(object sender, EventArgs e)
        {

        }
        private void logger(int userID)
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var inserter = context.Set<GirisLog>();
                    inserter.Add(new GirisLog { KullaniciID = userID, Tarih=DateTime.Now});
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public static Login login
        {
            get
            {
                if (_login== null)
                {
                    _login= new Login();
                }
                return _login;
            }
        }
        private static Login _login;
    }
}
