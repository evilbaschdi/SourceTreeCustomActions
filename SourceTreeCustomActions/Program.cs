var module = args[0];
var path = args[1];

var pathStringWrapper = new PathStringWrapper(path);
var git = new GitProcess(pathStringWrapper);
var startProcessAndWriteOutput = new StartProcessAndWriteOutputToConsole();
var gitCommands = new GitCommands(git, startProcessAndWriteOutput);

if (!Directory.Exists(path))
{
    return;
}

switch (module)
{
    case "sync":
    {
        var remote1Name = args[2];
        var remote2Name = args[3];
        var gitRemoteVProcess = git.ValueFor("remote -v");

        gitRemoteVProcess.Start();
        var gitRemoteVResult = gitRemoteVProcess.StandardOutput.ReadToEnd();

        if (gitRemoteVResult.Contains(remote1Name) && gitRemoteVResult.Contains(remote2Name))
        {
            gitCommands.RunFor(
                $"fetch {remote1Name} --tags",
                $"fetch {remote2Name} --tags",
                $"push {remote1Name} --all",
                $"push {remote1Name} --tags",
                $"push {remote2Name} --all",
                $"push {remote2Name} --tags"
            );
        }
        else
        {
            Console.WriteLine("Nothing to do.");
        }

        break;
    }
    case "pushToAllRemotes":
    case "pullAllRemotes":
    {
        var gitCurrentBranch = args[2];
        var gitRemotesProcess = git.ValueFor("remote");
        gitRemotesProcess.Start();

        var command = module == "pushToAllRemotes" ? "push" : "pull";

        while (gitRemotesProcess.StandardOutput.ReadLine() is { } remote)
        {
            gitCommands.RunFor(($"{command} {remote} {gitCurrentBranch}"));
        }

        break;
    }
}