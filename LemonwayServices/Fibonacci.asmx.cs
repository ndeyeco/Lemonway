using System;
using System.ComponentModel;
using System.Web.Services;
using System.Numerics;

namespace ndeyeServices
{
    /// <summary>
    ///     Summary description for Fibonacci
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Fibonacci : WebService
    {
        private static readonly log4net.ILog fiboLog =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [WebMethod]
        public BigInteger FibonacciItterative(int n)
        {
            fiboLog.Info(String.Format("fibonacci caclculus started for {0}", n));
            if (n > 100 || n < 1)
            {
                fiboLog.Error($"cannot calculate fibonacci for {n}");
                return -1;
            }
            System.Threading.Thread.Sleep(2000);
            BigInteger a = 0;
            BigInteger b = 1;
            for (var i = 0; i < n; i++)
            {
                fiboLog.Debug($"calculating fibonacci for {n}: iteration {i}. ");
                var temp = a;
                a = b;
                b = temp + b;
            }
            fiboLog.Info(String.Format("fibonacci caclculus ended for {0}", n));

            return a;
        }

        [WebMethod]
        public BigInteger FibonacciRecursive(int n)
        {
            if (n > 100 || n < 1)
                return -1;
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return FibonacciRecursive(n - 2) + FibonacciRecursive(n - 1);
            }
        }
    }
}