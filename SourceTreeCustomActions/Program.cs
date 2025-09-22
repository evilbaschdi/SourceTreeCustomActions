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

var gitCurrentBranch = args[2];
var gitRemotesProcess = git.ValueFor("remote");
gitRemotesProcess.Start();
var remotes = new List<string>();
while (gitRemotesProcess.StandardOutput.ReadLine() is { } remote)
{
    remotes.Add(remote);
}

switch (module)
{
    case "sync":
    {
        //pull from all remotes
        foreach (var remote in remotes)
        {
            gitCommands.RunFor(($"pull {remote} {gitCurrentBranch}"));
        }

        //push to all remotes
        foreach (var remote in remotes)
        {
            gitCommands.RunFor(($"push {remote} {gitCurrentBranch}"));
        }

        break;
    }
    case "pushToAllRemotes":
    case "pullAllRemotes":
    {
        var command = module == "pushToAllRemotes" ? "push" : "pull";

        foreach (var remote in remotes)
        {
            gitCommands.RunFor(($"{command} {remote} {gitCurrentBranch}"));
        }

        break;
    }
}