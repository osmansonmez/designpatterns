using System;
using System.Data;

namespace Bridge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SalesReport report = new SalesReport(new DesktopReportFormat());
            report.Display();

            report = new SalesReport(new WebReportFormat());
            report.Display();
        }
         


    }

    public interface IReportFormat
    {
        object Generate(string  rapordatasi);
    }

    public class DesktopReportFormat : IReportFormat
    {
        public object Generate(string rapordatasi)
        {
            return new DataTable();
        }
    }

    public class WebReportFormat : IReportFormat
    {
        public object Generate(string rapordatasi)
        {
            return new string("JsonData");
        }
    }

    public class MobileReportFormat : IReportFormat
    {
        public object Generate(string rapordatasi)
        {
            return new string("JsonData");
        }
    }

    public abstract class IReport
    {
        private IReportFormat reportFormat;
        public string raportDatasi;
        public IReport(IReportFormat reportFormat)
        {
            this.reportFormat = reportFormat;
        }

        public abstract void PrepareReport();

        public virtual object Display()
        {
            Console.WriteLine(this.GetType().Name + " için " +
                reportFormat.GetType().Name + " raporu hazırlandı");
          return  reportFormat.Generate(raportDatasi);
        }
    }

    public class SalesReport : IReport
    {
        public SalesReport(IReportFormat reportFormat) :base(reportFormat)
        {

        }

        public override void PrepareReport()
        {
            raportDatasi = "Satış Raporları var burda ";
        }
    }

    public class Televizyon : IDevice
    {
        public void channelDown()
        {
            Console.WriteLine(this.GetType() + " channelDown occured");
        }

        public void channelUp()
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void close()
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void open()
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void setChannel(int channelId)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void setVolume(int percent)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void volumedown(int percent = 1)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void volumeup(int percent = 1)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }
    }


    public class Radio : IDevice
    {
        public void channelDown()
        {
            Console.WriteLine(this.GetType() + " channelDown occured");
        }

        public void channelUp()
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void close()
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void open()
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void setChannel(int channelId)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void setVolume(int volume)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void volumedown(int percent = 1)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }

        public void volumeup(int percent = 1)
        {
            Console.WriteLine(this.GetType() + " channelUp occured");
        }
    }
    public interface IDevice
    {
        void open();
        void close();
        void volumeup(int percent = 1);
        void volumedown(int percent = 1);

        void setVolume(int volume);
        void channelUp();
        void channelDown();

        void setChannel(int channelId);
    }

    public abstract class IRemote
    {
        IDevice device;
        public IRemote(IDevice device)
        {
            this.device = device;
        }
    }
}
