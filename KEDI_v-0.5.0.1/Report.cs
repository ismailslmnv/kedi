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
using MetroFramework.Controls;

namespace KEDI_v_0._5._0._1
{
    public partial class Report : MetroForm
    {
        public static int PersonalID = 3;
        private bool detailedSelected = false;
        public Report()
        {
            InitializeComponent();
            dataPanel.Visible = false;
            spanPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            startTimeSpan.MaxDate = DateTime.Now;
            endTimeSpan.MaxDate = DateTime.Now;
            startTimeSpan.Value = DateTime.Now;
            endTimeSpan.Value = DateTime.Now;
        }

        private void Report_Click(object sender, EventArgs e)
        {
            cash.Text = "0";
            card.Text = "0";
            all.Text = "0";
            cancelledAccount.Text = "0";
            prodCount.Text = "0";
            adisyonCount.Text = "0";
            MetroTile _sender = (MetroTile)sender;
            if (!_sender.Name.Equals("confirmSpan"))
            {
                spanPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
                timespanPanel.Visible = false;
                ReportMbox answ = new ReportMbox();
                DialogResult result = answ.ShowDialog();
                if (result == DialogResult.No)
                {
                    detailedSelected = true;
                }
                else
                {
                    detailedSelected = false;
                }
            }
            getReport(_sender.Name);
        } 
        private void getReport(string reportType)
        {            
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            DateTime now = DateTime.Now;
            switch (reportType)
            {
                case "dailyReport":
                    {                        
                        if(now.Hour<6)
                            start = getTime(now.Year, now.Month, now.Day-1, 5, 0, 0, 0);
                        else
                            start = getTime(now.Year, now.Month, now.Day, 5, 0, 0, 0);
                        end = DateTime.Now;
                        dataPanel.Visible = true;
                        getReportDB(start, end);
                        break;
                    }
                case "weeklyReport":
                    {
                        start = getTime(now.Year, now.Month, now.Day - 7, now.Hour, now.Minute, now.Second, now.Millisecond);
                        end = now;
                        dataPanel.Visible = true;
                        getReportDB(start, end);
                        break;
                    }
                case "monthlyReport":
                    {
                        start = getTime(now.Year, now.Month-1, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
                        end = now;
                        dataPanel.Visible = true;
                        getReportDB(start, end);
                        break;
                    }
                case "timespanSelection":
                    {
                        spanPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        timespanPanel.Visible = true;                                            
                        break;          
                    }
                case "confirmSpan":
                    {
                        start = startTimeSpan.Value;
                        end = endTimeSpan.Value;
                        dataPanel.Visible = true;
                        getReportDB(start, end);
                        break;
                    }
                default:
                    break;
            }
        }
         private void getReportDB(DateTime start, DateTime end)
        {
            try
            {
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    if (detailedSelected)
                    {
                        var result = (from rapor in kEDIDB.Odemes
                                      where rapor.Siparisler.Tarih >= start
                                      where rapor.Siparisler.Tarih <= end
                                      where rapor.Siparisler.Urunler.AltOzellik == false
                                      select new
                                      {
                                          rapor.Siparisler.SiparisAdi,
                                          rapor.Siparisler.Urunler.UrunAdi,
                                          rapor.Siparisler.UrunSayi,
                                          rapor.Siparisler.Urunler.Fiyat,
                                          rapor.Siparisler.Masalar.Salonlar.SalonAdi,
                                          rapor.Siparisler.Masalar.MasaAdi,
                                          rapor.OdemeYontemi1.YontemAdi,
                                          rapor.Tarih
                                      }).DefaultIfEmpty();
                        var countAdisyon = (from adisyon in kEDIDB.Odemes
                                            where adisyon.Siparisler.Tarih >= start
                                            where adisyon.Siparisler.Tarih <= end
                                            where adisyon.Siparisler.Urunler.AltOzellik == false
                                            where !adisyon.OdemeYontemi1.YontemAdi.Equals("İptal")
                                            select adisyon.Siparisler.SiparisAdi).Distinct().Count();
                        adisyonCount.Text = countAdisyon.ToString();
                        list.DataSource = result.ToList();
                        list.Columns[0].HeaderText = "Adisyon Numarası";
                        list.Columns[1].HeaderText = "Ürün Adı";
                        list.Columns[2].HeaderText = "Ürün Sayısı";
                        list.Columns[3].HeaderText = "Ürün Birim Fiyatı";
                        list.Columns[4].HeaderText = "Salon Adı";
                        list.Columns[5].HeaderText = "Masa Adı";
                        list.Columns[6].HeaderText = "Ödeme Yöntemi";
                        list.Columns[7].HeaderText = "Sipariş Tarihi";
                        updateTexts();
                    }
                    else
                    {

                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private DateTime getTime(int year,int month,int day, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                seconds,
                milliseconds);
        }
        private void exportToExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    for (int j = 0; j < list.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = list.Columns[j].HeaderText;
                            worksheet.Cells[cellRowIndex+1, cellColumnIndex] = (list.Rows[i].Cells[j].Value).ToString();
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex+1, cellColumnIndex] = (list.Rows[i].Cells[j].Value).ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        private void excelPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            exportToExcel();
            Cursor.Current = Cursors.Default;
        }
        private void list_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow item in list.Rows)
            {
                if (item.Cells[6].Value.Equals("İptal"))
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }                
            }
        }
        private void updateTexts()
        {
            foreach (DataGridViewRow row in list.Rows)
            {
                row.Cells[3].Value = row.Cells[3].Value.ToString();
                if (row.Cells[6].Value.Equals("Nakit"))
                {
                    cash.Text = (Convert.ToDouble(cash.Text) + 
                        (Convert.ToDouble(Convert.ToDecimal(row.Cells[2].Value)) * Convert.ToDouble(Convert.ToDecimal(row.Cells[3].Value)))).ToString();
                }
                else if (row.Cells[6].Value.Equals("Kart"))
                {
                    card.Text = (Convert.ToDouble(card.Text) +
                        (Convert.ToDouble(Convert.ToDecimal(row.Cells[2].Value)) * Convert.ToDouble(Convert.ToDecimal(row.Cells[3].Value)))).ToString();
                }
                else if (row.Cells[6].Value.Equals("İptal"))
                {
                    cancelledAccount.Text = (Convert.ToDouble(cancelledAccount.Text) +
                        (Convert.ToDouble(Convert.ToDecimal(row.Cells[2].Value)) * Convert.ToDouble(Convert.ToDecimal(row.Cells[3].Value)))).ToString();
                }
                all.Text = (Convert.ToDouble(cash.Text) + Convert.ToDouble(card.Text)).ToString();
                prodCount.Text = (Convert.ToDouble(prodCount.Text) + (Convert.ToDouble(row.Cells[2].Value))).ToString();
            }
        }
    }
}
