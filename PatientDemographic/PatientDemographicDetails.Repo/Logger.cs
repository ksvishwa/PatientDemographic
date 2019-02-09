using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace PatientDemographicDetails.Repo.Helper
{
    public class Logger
    {
        public static void WriteLog(Exception ex)
        {
            StringBuilder sbFile = new StringBuilder();
            sbFile.Append(ConfigurationManager.AppSettings["ErrorLog"]);
            sbFile.Append(DateTime.Now.ToString("dd_mm_yyyy")+".txt");
            using (StreamWriter sw = File.AppendText(sbFile.ToString()))
            {
                sw.WriteLine(DateTime.Now.ToString() +" : "+ ex.Message);
                sw.WriteLine(DateTime.Now.ToString() + " : " + ex.StackTrace);
            }
        }
    }
}