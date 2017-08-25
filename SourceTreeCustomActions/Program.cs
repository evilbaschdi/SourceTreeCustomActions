using System;
using System.Diagnostics;
using System.IO;

namespace SourceTreeCustomActions
{
    class Program
    {
        private static string _path;
        static void Main(string[] args)
        {
            var module = args[0];
            _path = args[1];
            var remote1Name = args[2];
            var remote2Name = args[3];

            if (Directory.Exists(_path))
            {
                if (module == "sync")
                {
                    var gitRemoteV = Git("remote -v");

                    gitRemoteV.Start();
                    var gitRemoteVResult = gitRemoteV.StandardOutput.ReadToEnd();

                    if (gitRemoteVResult.Contains(remote1Name) && gitRemoteVResult.Contains(remote2Name))
                    {
                        var gitFetchRemote1Tags = Git("fetch " + remote1Name + " --tags");
                        StartAndWriteProcessOutput(gitFetchRemote1Tags);
                        var gitFetchRemote2Tags = Git("fetch " + remote2Name + " --tags");
                        StartAndWriteProcessOutput(gitFetchRemote2Tags);
                        var gitPuthRemote1All = Git("push " + remote1Name + " --all");
                        StartAndWriteProcessOutput(gitPuthRemote1All);
                        var gitPuthRemote1Tags = Git("push " + remote1Name + " --tags");
                        StartAndWriteProcessOutput(gitPuthRemote1Tags);
                        var gitPuthRemote2All = Git("push " + remote2Name + " --all");
                        StartAndWriteProcessOutput(gitPuthRemote2All);
                        var gitPuthRemote2Tags = Git("push " + remote2Name + " --tags");
                        StartAndWriteProcessOutput(gitPuthRemote2Tags);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to do.");
                    }
                }
            }
        }
        private static Process Git(string argument)        
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = argument,
                    WorkingDirectory = _path,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
        }

        private static void StartAndWriteProcessOutput(Process process)
        {
            process.Start();
            Console.WriteLine(process.StartInfo.Arguments + "...");
            Console.WriteLine(process.StandardOutput.ReadToEnd().Trim());
        }
    }
}
