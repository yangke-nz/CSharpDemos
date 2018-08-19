using System;
using System.Threading;

namespace EventDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportMaker = new ReportMaker();
            var logSer = new LoggingService();
            var msgSer = new MsgService();

            reportMaker.ReportGenerated += logSer.OnReportGenerated;
            reportMaker.ReportGenerated += msgSer.OnReportGenerated; 

            reportMaker.GenerateReport();

            Console.WriteLine();
        }
    }
    
    public class ReportEventArgs : EventArgs
    {
        public string ReportSummary { get; set; }
    }

    public class ReportMaker
    {
        public event EventHandler<ReportEventArgs> ReportGenerated;
        
        public void GenerateReport()
        {
            Console.WriteLine("Start Generate Report...");
            Thread.Sleep(2000);
            Console.WriteLine("Report Generated");

            var eventArgs = new ReportEventArgs { ReportSummary = "New Report Summary" };
            ReportGenerated?.Invoke(this, eventArgs);
        }
    }

    public class MsgService
    {
        public void OnReportGenerated(object sender, ReportEventArgs args)
        {
            Console.WriteLine($"MsgService sending msg for [{args.ReportSummary}]");
            Thread.Sleep(2000);
            Console.WriteLine("MsgService msg sent.");
        }
    }

    public class LoggingService
    {
        public void OnReportGenerated(object sender, ReportEventArgs args)
        {
            Console.WriteLine($"LoggingService add log for [{args.ReportSummary}]");
            Thread.Sleep(1000);
            Console.WriteLine("LoggingService log added.");
        }
    }


}
