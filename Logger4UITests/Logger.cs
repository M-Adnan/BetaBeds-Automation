using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaBedsUITestLogger
{
    public class Logger
    {
        public  static readonly log4net.ILog log; 

        static Logger()
        { 
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void AddTypeAction(string value, string description)
        {
            log.Info("Type \"" + value + "\" in " + description);
        }

        public static void AddClickAction(string description)
        {
            log.Info("Click " + description);
        }

        public static void AddSelectAction(string value, string description)
        {
            log.Info("Select " + value + " " + description);
        }

        public static void AddSelectAction(string description1, int value, string description2)
        {
            log.Info("Select " + description1+ value + description2);
        }

        public static void AddSelectAction(int value1, string description, int value2)
        {
            log.Info("Select " + value1 + " " + description + " " + value2);
        }

        public static void AddCustomMsg(string description1, string value, string description2)
        {
            log.Info(description1 + " " + value + " " + description2);
        }

        public static void AddCustomMsg(string description1, string value)
        {
            log.Info(description1 + " " + value);
        }

        public static void AddCustomMsg(string description1)
        {
            log.Info(description1);
        }
    }
}
