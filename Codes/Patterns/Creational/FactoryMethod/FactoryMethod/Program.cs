using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            LoginAbstract login = (new LoginFactory()).GetLoginInstance(LoginType.Mbb);
            LoginAbstract login2 = (new LoginFactory()).GetLoginInstance(LoginType.Tckn);
        }
    }

    interface ILogin
    {
        BaseResponse Execute(BaseRequest request);
    }

    public abstract class LoginAbstract : ILogin
    {
       public BaseResponse DoLoginForMbb(BaseRequest request)
        {
            return new BaseResponse();
        }
        public abstract BaseResponse Execute(BaseRequest request);
    }

    public class MbbLogin : LoginAbstract
    {
        public override BaseResponse Execute(BaseRequest request)
        {
          return DoLoginForMbb(request);
        }
    }

    public class TCKNLogin : LoginAbstract
    {
        public override BaseResponse Execute(BaseRequest request)
        {
            var mbb =  FindMbb("234234234234");
            DoLoginForMbb(request);
        }

        private string FindMbb(string tckn)
        {
            return "";
        }
    }
    public class BaseResponse
    {
    }

    public class BaseRequest
    {
    }

    public class LoginFactory
    {
        public LoginAbstract GetLoginInstance(LoginType loginType)
        {
            switch(loginType)
            {
                case LoginType.Mbb:
                    return new MbbLogin();
                case LoginType.Tckn:
                    return new TCKNLogin();
                default:
                    return new MbbLogin();
            }
        }
    }

    public enum LoginType
    {
        Mbb,
        Tckn
    }
}
