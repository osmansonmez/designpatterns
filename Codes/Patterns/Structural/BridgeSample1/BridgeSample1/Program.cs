using System;

namespace BridgeSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            //SalesReport sreport = new SalesReport(new DesktopReport());
            //SalesReport sreport2 = new SalesReport(new MobileReport());
            //SalesReport sreport3 = new SalesReport(new WebReport());

            AdvancedRemoter b1 = new AdvancedRemoter(new TV());
            AdvancedRemoter b2 = new AdvancedRemoter(new Radio());
            AdvancedRemoter b3 = new AdvancedRemoter(new InternetTV());

            b1.Browse();
            b2.Browse();
            b3.Browse();
        }
    }

    public interface IReportFormat
    {
        object Generate(object data);
    }

    public class WebReport : IReportFormat
    {
        public object Generate(object data)
        {
            return new object();
        }
    }

    public class MobileReport : IReportFormat
    {
        public object Generate(object data)
        {
            return new object();
        }
    }

    public class DesktopReport : IReportFormat
    {
        public object Generate(object data)
        {
            return new object();
        }
    }

    public abstract class IReport
    {
        protected IReportFormat reportFormat;
        public IReport(IReportFormat reportFormat)
        {
            this.reportFormat = reportFormat;
        }
        public object Data { get; set; }
        public abstract void Prepare();

        public abstract object Display();
    }

    public class SalesReport : IReport
    {
        public SalesReport(IReportFormat reportFormat)
            : base(reportFormat)
        {

        }

        public override object Display()
        {
            return reportFormat.Generate(Data);
        }

        public override void Prepare()
        {
            Data = new object();
        }
    }

    public class EmployeddPerfReport : IReport
    {
        public EmployeddPerfReport(IReportFormat reportFormat)
            : base(reportFormat)
        {

        }

        public override object Display()
        {
            return reportFormat.Generate(Data);
        }

        public override void Prepare()
        {
            Data = new object();
        }
    }

    public interface IDevice
    {
        void open();

        void close();

        void channelChange(int increment);

        void setChannel(int channel);

        void setVolume(int increment);
    }

    public interface InternetDevice:IDevice
    {
        void browse();
    }

    public class TV : IDevice
    {
        int channel = 1;
        int volume = 1;
        bool running = false;
        public void channelChange(int increment)
        {
            channel += increment;
        }

        public void close()
        {
            running = false;
        }

        public void open()
        {
            running = true;
        }

        public void setChannel(int channel)
        {
            this.channel = channel;
        }

        public void setVolume(int increment)
        {
            volume += increment;
        }
    }

    public class InternetTV : TV, InternetDevice
    {
        public void browse()
        {
           
        }
    }
    public class Radio : IDevice
    {
        int channel = 1;
        int volume = 1;
        bool running = false;
        public void channelChange(int increment)
        {
            channel += increment;
        }

        public void close()
        {
            running = false;
        }

        public void open()
        {
            running = true;
        }

        public void setChannel(int channel)
        {
            this.channel = channel;
        }

        public void setVolume(int increment)
        {
            volume += increment;
        }
    }

    public abstract class IRemote
        {
       protected bool running = false;

        protected IDevice device;
       public IRemote(IDevice device)
        {
            this.device = device;
        }
        public virtual  void ChannelDown()
        {
            device.channelChange(-1);
        }

        public virtual  void ChannelUp()
        {
            device.channelChange(1);
        }

        public virtual  void OpenClose()
        {

            if (running)
                device.close();
            else
                device.open();

            running = !running;

        }

        public virtual  void VolumeDown()
        {
            device.setVolume(-5);
        }

        public virtual  void VolumeUp()
        {
            device.setVolume(5);
        }

    }

    public abstract class IAdvancedRemote:IRemote
    {
        public IAdvancedRemote(IDevice device):base(device)
        {
         
        }
        public abstract void Browse();
    }
    public class BasicRemoter : IRemote
    {

        public BasicRemoter(IDevice device):base(device)
        {

        }

    }

    public class AdvancedRemoter : IAdvancedRemote
    {
        public AdvancedRemoter(IDevice device) : base(device)
        {
      
        }

        public override void Browse()
        {
           if(device is InternetDevice)
            {
                Console.WriteLine("Browsing...");
            }
           else
            {
                Console.WriteLine("Unsported Device for Internet Browsing");
            }
        }
    }
}
