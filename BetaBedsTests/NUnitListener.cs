using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core.Extensibility;
using NUnit.Core;
using BetaBedsAutomation.Data;

namespace BetaBedsTests
{
  [NUnitAddinAttribute(
  Name = "Test Logger",
  Description = "Writes test result to console",
  Type = ExtensionType.Core)]

    public class NUnitFileLoggerAddin : IAddin , EventListener
    {
      public bool Install(IExtensionHost host)
      {
          var listeners = host.GetExtensionPoint("EventListeners");
          if (listeners == null)
              return false;

          listeners.Install(this);
          return true;
      }

      public void RunFinished(Exception exception)
      {
  
      }

      public void RunFinished(TestResult result)
      {

      }

      public void RunStarted(string name, int testCount)
      {

      }

      public void SuiteFinished(TestResult result)
      {
  
      }

      public void SuiteStarted(TestName testName)
      {

      }

      public void TestFinished(TestResult result)
      {
          System.Console.WriteLine("Search id: " + Guids.SearchGuid + "\nPageUrl: " + Guids.pageUrl);
      }

      public void TestOutput(TestOutput testOutput)
      {

      }

      public void TestStarted(TestName testName)
      {

      }

      public void UnhandledException(Exception exception)
      {
         System.Console.WriteLine("Search id: " + Guids.SearchGuid + "\nPageUrl: " + Guids.pageUrl);
      }
    }
}
