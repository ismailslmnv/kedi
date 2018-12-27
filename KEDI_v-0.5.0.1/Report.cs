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
            startTimeSpan.MaxDate = DateTime.Now;
            endTimeSpan.MaxDate = DateTime.Now;
            startTimeSpan.Value = DateTime.Now;
            endTimeSpan.Value = DateTime.Now;
        }

        private void Report_Click(object sender, EventArgs e)
        {                      
            ReportMbox answ = new ReportMbox();
            answ.ShowDialog();
            if (DialogResult==DialogResult.Cancel)
            {
                detailedSelected = true;
            }
            else
            {
                detailedSelected = false;
            }
            MetroTile _sender = (MetroTile)sender;
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
                        start = getTime(now.Year,now.Month,now.Day, 5, 0, 0, 0);
                        end = DateTime.Now;
                        break;
                    }
                case "weeklyReport":
                    {
                        start = getTime(now.Year, now.Month, now.Day - 7, now.Hour, now.Minute, now.Second, now.Millisecond);
                        end = now;
                        break;
                    }
                case "monthlyReport":
                    {
                        start = getTime(now.Year, now.Month-1, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
                        end = now;
                        break;
                    }
                case "timespanSelection":
                    {
                        timespanPanel.Visible = true;
                        ///////////////burada kaldk
                        ///
                        break;
                    }
                default:
                    break;
            }
            getReportDB(start, end);
        }
         private void getReportDB(DateTime start, DateTime end)
        {

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
    }
}
