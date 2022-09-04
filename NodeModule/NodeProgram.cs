using System;
using System.Diagnostics;

namespace Console_Node
{
    public class NodeProgram
    {

        /// <summary>
        /// Исполнение команды
        /// </summary>                
        private static string Execute(string command)
        {
            ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + command);

            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);

            string response = process.StandardOutput.ReadToEnd();
            return response;
        }


        public static string Run(string javascript)
        {
            System.IO.File.WriteAllText("index.js", javascript);
            return Execute("node index.js");
        }


        static void Main(string[] args)
        {
            Console.WriteLine(
                Run(@"
                    var s='';
                    for(let i=0; i<1024; i++){
                        s+=String.fromCharCode(i);
                    }
                    console.info(s);
                ")
            );
        }
    }
}
