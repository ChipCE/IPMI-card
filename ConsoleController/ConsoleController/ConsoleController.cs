using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using System.Management.Automation.Runspaces;

namespace ConsoleController
{
    class ConsoleController
    {

        //
        public PowerShell PowerShellInstance;

        public ConsoleController()
        {
            //PowerShellInstance = PowerShell.Create();
        }

        public void init()
        {
            PowerShellInstance = PowerShell.Create();
        }

        public void destroy()
        {
            PowerShellInstance.Dispose();
        }

        public StringCollection excuteCommand(string command)
        {
            //clear old data
            PowerShellInstance.Commands.Clear();
            PowerShellInstance.Streams.Error.Clear();

            //append new command
            PowerShellInstance.AddScript(command);
     
            // prepare a new collection to store output stream objects
            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            // use this overload to specify an output stream buffer
            IAsyncResult result = PowerShellInstance.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            // do something else until execution has completed.
            // this could be sleep/wait, or perhaps some other work
            while (result.IsCompleted == false)
            {
                    Console.WriteLine("Waiting for pipeline to finish...");
                    Thread.Sleep(1000);
            }
            Console.WriteLine("Execution has stopped. The pipeline state: " + PowerShellInstance.InvocationStateInfo.State);

            StringCollection resultCollection = new StringCollection();
            if(outputCollection.Count >0 )
            {
                foreach (PSObject outputItem in outputCollection)
                {
                    //TODO: handle/process the output items if required
                    Console.WriteLine(outputItem.BaseObject.ToString());
                    resultCollection.Add(outputItem.BaseObject.ToString());
                }
            }
                
            if (PowerShellInstance.Streams.Error.Count > 0)
            {
                resultCollection.Add("Error");
                foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
                {
                    Console.WriteLine(error.ToString());
                    resultCollection.Add(error.ToString());
                }
            }
            return resultCollection;
        }   
    }
}
