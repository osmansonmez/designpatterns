using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SmsSenderAdapter1
    {
        public void SendSMS(SendSMSRequest request)
        {
            SmsSender sender = new SmsSender();
            sender.SendSms(request.telno, request.msg);
        }
    }

    public class SmsSenderAdapter2 : SmsSender
    {
        public void SendSMS(SendSMSRequest request)
        {
            base.SendSms(request.telno, request.msg);
            GetCampaign();
        }

        public void GetCampaign()
        {

        }
    }

    public class SendSMSRequest
    {
        public string telno;
        public string msg;
    }

    public class SmsSender
    {
        public void SendSms(string telno, string msg)
        {
            
        }

    }
}
