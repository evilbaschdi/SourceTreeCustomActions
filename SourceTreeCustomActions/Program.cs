using System;
using System.IO;
using SourceTreeCustomActions.Internal;

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

            IStringWrapper path = new PathStringWrapper(args[1]);
            IProcess git = new GitProcess(path);
            IStartProcessAndWriteOutput startProcessAndWriteOutput = new StartProcessAndWriteOutputToConsole();

            if (Directory.Exists(_path))
            {
                if (module == "sync")
                {
                    var gitRemoteV = git.ValueFor("remote -v");

                    gitRemoteV.Start();
                    var gitRemoteVResult = gitRemoteV.StandardOutput.ReadToEnd();

                    if (gitRemoteVResult.Contains(remote1Name) && gitRemoteVResult.Contains(remote2Name))
                    {
                        var gitFetchRemote1Tags = git.ValueFor("fetch " + remote1Name + " --tags");
                        startProcessAndWriteOutput.RunFor(gitFetchRemote1Tags);
                        var gitFetchRemote2Tags = git.ValueFor("fetch " + remote2Name + " --tags");
                        startProcessAndWriteOutput.RunFor(gitFetchRemote2Tags);
                        var gitPuthRemote1All = git.ValueFor("push " + remote1Name + " --all");
                        startProcessAndWriteOutput.RunFor(gitPuthRemote1All);
                        var gitPuthRemote1Tags = git.ValueFor("push " + remote1Name + " --tags");
                        startProcessAndWriteOutput.RunFor(gitPuthRemote1Tags);
                        var gitPuthRemote2All = git.ValueFor("push " + remote2Name + " --all");
                        startProcessAndWriteOutput.RunFor(gitPuthRemote2All);
                        var gitPuthRemote2Tags = git.ValueFor("push " + remote2Name + " --tags");
                        startProcessAndWriteOutput.RunFor(gitPuthRemote2Tags);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to do.");
                    }
                }
            }
        }
    }
}