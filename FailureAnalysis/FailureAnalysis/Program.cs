using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FailureAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @" \\eqtrmseuappr53\jobs\log\running\PE2";
            var folders = Directory.GetDirectories(path);

            var outputDir = @"N:\HybridRisk\";
            var outputFile = outputDir + "Failed.txt";

            foreach (var f in folders)
            {
                int eod;
                if (!Int32.TryParse(Path.GetFileName(f), out eod))
                    continue;

                if (eod >= 20170601)
                {
                    var hybridPath = f + @"\4961_HybridsReports_Box";
                    if (Directory.Exists(hybridPath))
                    {
                        var jobFolders = Directory.GetDirectories(hybridPath)
                                        .Where(x => Regex.IsMatch(Path.GetFileName(x), @"^4961_hybridsReports[1-8]_(\w+)"));

                        foreach (var jf in jobFolders)
                        {
                            try
                            {
                                var reports = Directory.GetFiles(jf);
                                foreach (var r in reports)
                                {
                                    if (Regex.IsMatch(Path.GetFileName(r), pattern: @"^failedReportFiles\.(\w+)\.txt"))
                                        using (StreamWriter wrt = new StreamWriter(outputFile, true))
                                        {
                                            wrt.WriteLine(jf);
                                        }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }

                }
                

            }

            Console.ReadKey();

        }
    }
}
