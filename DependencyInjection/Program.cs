using System;
using Unity;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<ReportMaker>();
            unityContainer.RegisterType<IMsgServer, FastMsgServer>();
            ReportMaker reportMaker = unityContainer.Resolve<ReportMaker>();

            reportMaker.GenerateReport();

            Console.ReadLine();
        }
    }

    internal class FastMsgServer : IMsgServer
    {
        public void SendMsg()
        {
            Console.WriteLine("Report msg sent by FastMsgServer");
        }
    }

    internal interface IMsgServer
    {
        void SendMsg();
    }

    internal class ReportMaker
    {
        private IMsgServer msgServer;

        public ReportMaker(IMsgServer msgServer)
        {
            this.msgServer = msgServer;
        }

        public void GenerateReport()
        {
            Console.WriteLine("Report Generated");
            msgServer.SendMsg();
        }
    }
}
