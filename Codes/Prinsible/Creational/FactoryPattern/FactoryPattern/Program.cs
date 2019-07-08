using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MobilBranchTransactionFactory mobilebranch = new MobilBranchTransactionFactory();
            TransactionManager manager = new TransactionManager();
            EFTRequest request = new EFTRequest()
            {
                Tutar = 5000
            };

            manager.Run(mobilebranch, request);
    }
    }

    public interface ITransaction
    {
        BaseResponse Execute(BaseRequest request);
    }

    public class BaseRequest
    {
        public string TransactionName { get; set; }
    }

    public class BaseResponse
    {
        public string Data { get; set; }
    }

    public class EFTRequest : BaseRequest
    {
        public EFTRequest()
        {
            TransactionName = "EFT";
        }
        public decimal Tutar { get; set; }
    }
    public class EFT : ITransaction
    {
        public BaseResponse Execute(BaseRequest request)
        {
            return new BaseResponse() { Data = "EFT" };
        }
    }

    public class Havale : ITransaction
    {
        public BaseResponse Execute(BaseRequest request)
        {
            return new BaseResponse() { Data = "Havale" };
        }
    }

    public class CreditApplication : ITransaction
    {
        public BaseResponse Execute(BaseRequest request)
        {
            return new BaseResponse() { Data = "Kredi Başvurusu" };
        }
    }

    public class AccountList : ITransaction
    {
        public BaseResponse Execute(BaseRequest request)
        {
            return new BaseResponse() { Data = "Hesap Listesi" };
        }
    }

    public abstract class AbstractChannelTransactionFactory
    {
        public abstract ITransaction GetTransaction(string TransactionName);

        public abstract BaseResponse Run(ITransaction transaction, BaseRequest req);
    }

    public class MobilBranchTransactionFactory : AbstractChannelTransactionFactory
    {
        public override ITransaction GetTransaction(string TransactionName)
        {
            switch (TransactionName)
            {
                case "EFT":
                    return new EFT();
                case "Havale":
                    return new Havale();
                default:
                    throw new Exception("not implemented transaction for this channel");
            }
        }

        public override BaseResponse Run(ITransaction transaction,BaseRequest req)
        {
            return transaction.Execute(req);
        }
    }

    public class BranchTransactionFactory : AbstractChannelTransactionFactory
    {
        public override ITransaction GetTransaction(string TransactionName)
        {
            switch (TransactionName)
            {
                case "EFT":
                    return new EFT();
                case "Havale":
                    return new Havale();
                case "KrediBasvurusu":
                    return new CreditApplication();
                default:
                    throw new Exception("not implemented transaction for this channel");
            }
        }

        public override BaseResponse Run(ITransaction transaction, BaseRequest req)
        {
            return transaction.Execute(req);
        }
    }

    public class CreditCardBranchTransactionFactory : AbstractChannelTransactionFactory
    {
        public override ITransaction GetTransaction(string TransactionName)
        {
            switch (TransactionName)
            {
                case "HesapListesi":
                    return new AccountList();
                default:
                    throw new Exception("not implemented transaction for this channel");
            }
        }

        public override BaseResponse Run(ITransaction transaction, BaseRequest req)
        {
            return transaction.Execute(req);
        }
    }

    public class TransactionManager
    {
        public BaseResponse Run(AbstractChannelTransactionFactory channelFactory, BaseRequest request)
        {
            ITransaction transaction = channelFactory.GetTransaction(request.TransactionName);
            return channelFactory.Run(transaction, request);
        }
    }
}
