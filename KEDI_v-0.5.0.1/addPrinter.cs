using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Management;

namespace KEDI_v_0._5._0._1
{
    public partial class addPrinter : MetroForm
    {
        private int PrinterID = 0;
        public addPrinter()
        {
            InitializeComponent();
            loadPrinters();
        }
        private void loadPrinters()
        {
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                printers.Items.Add(name);
            }
        }
        private void addProd_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (addProd.Checked)
            {
                loadMenu();
            }
            else
            {
                MenuChecker.Items.Clear();
            }
            Cursor.Current = Cursors.Default;
        }
        private void loadMenu()
        {
            try
            {
                MenuChecker.Items.Clear();
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from menuler in kEDIDB.Urunlers
                                  where menuler.UstUrunID == 0
                                  where menuler.PrintID == 0
                                  select menuler.UrunAdi).DefaultIfEmpty();
                    if (result != null)
                    {
                        foreach (var item in result.ToList())
                        {
                            MenuChecker.Items.Add(item);
                        }
                    }
                    else MetroMessageBox.Show(this,"Lütfen Bu Yazıcıya Eklemek İstediğiniz Ürünleri Önce Başka Yazıcılardan Ayırınız!");
                }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.ToString());
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            addPrinter refresh = new addPrinter();
            refresh.Show();
            this.Close();
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (addPrinterDB())
            {
                if (addProd.Checked)
                {
                    int counter = 0;
                    foreach (var item in MenuChecker.Items)
                    {
                        CheckBox _item = (CheckBox)item;
                        if (_item.Checked)
                        {
                            addProducts(_item.Name);
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        MessageBox.Show("Lütfen En Az Bir Ürün Seçiniz!");
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else MessageBox.Show("Seçili Yazıcı Kaydedilirken Bir Hata Oluştu Lütfen Teknik Desteğe Başvurunuz!");
        }
        private void addProducts(string prodName)
        {
            try
            {
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from menuler in kEDIDB.Urunlers where menuler.UrunAdi.Equals(prodName) select menuler).FirstOrDefault();
                    if (result!=null)
                    {
                        result.PrintID = PrinterID;
                        kEDIDB.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool addPrinterDB()
        {
            string[] printerDetails = getPrinterDetails();
            if (printerDetails!=null)
            {
                try
                {
                    using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                    {
                        Printer newPrinter = new Printer()
                        {
                            PrinterName=printerDetails[0],
                            PrinterIP=printerDetails[1],
                            CreationDate=DateTime.Now,
                            AccountPrint=accountPrint.Checked,
                            Report=reportPrint.Checked,
                            CancelProd=cancelProd.Checked,
                            Product=addProd.Checked                            
                        };
                        kEDIDB.Printers.Add(newPrinter);
                        kEDIDB.SaveChanges();
                        PrinterID = newPrinter.PrinterID;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }
        private string[] getPrinterDetails()// [0] -printer name [1] - printer IP
        {
            if (printers.SelectedItem!=null)
            {
                string printerName = printers.SelectedItem.ToString();
                MessageBox.Show(printerName);
                string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                using (ManagementObjectCollection coll = searcher.Get())
                {
                    try
                    {
                        foreach (ManagementObject printer in coll)
                        {
                            foreach (PropertyData property in printer.Properties)
                            {
                                MessageBox.Show(string.Format("{0}: {1}", property.Name, property.Value));
                                break;
                            }
                        }
                    }
                    catch (ManagementException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Lütfen Listeden Bir Yazıcı Seçiniz!");
            return null;
        }
    }
}
