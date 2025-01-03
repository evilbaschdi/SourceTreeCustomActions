using SourceTreeCustomActions.Internal;

var module = args[0];
var path = args[1];

var pathStringWrapper = new PathStringWrapper(path);
var git = new GitProcess(pathStringWrapper);
var startProcessAndWriteOutput = new StartProcessAndWriteOutputToConsole();

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
            var gitFetchRemote1Tags = git.ValueFor("fetch " + remote1Name + " --tags");
            startProcessAndWriteOutput.RunFor(gitFetchRemote1Tags);
            var gitFetchRemote2Tags = git.ValueFor("fetch " + remote2Name + " --tags");
            startProcessAndWriteOutput.RunFor(gitFetchRemote2Tags);
            var gitPushRemote1All = git.ValueFor("push " + remote1Name + " --all");
            startProcessAndWriteOutput.RunFor(gitPushRemote1All);
            var gitPushRemote1Tags = git.ValueFor("push " + remote1Name + " --tags");
            startProcessAndWriteOutput.RunFor(gitPushRemote1Tags);
            var gitPushRemote2All = git.ValueFor("push " + remote2Name + " --all");
            startProcessAndWriteOutput.RunFor(gitPushRemote2All);
            var gitPushRemote2Tags = git.ValueFor("push " + remote2Name + " --tags");
            startProcessAndWriteOutput.RunFor(gitPushRemote2Tags);
        }
        else
        {
            Console.WriteLine("Nothing to do.");
        }

        break;
    }
    case "pushToAllRemotes":
    {
        var gitCurrentBranch = args[2];

        var gitRemotesProcess = git.ValueFor("remote");
        gitRemotesProcess.Start();

        while (gitRemotesProcess.StandardOutput.ReadLine() is { } remote)
        {
            startProcessAndWriteOutput.RunFor(git.ValueFor($"push {remote} {gitCurrentBranch}"));
        }

        break;
    }
    case "pullAllRemotes":
    {
        var gitCurrentBranch = args[2];

        var gitRemotesProcess = git.ValueFor("remote");
        gitRemotesProcess.Start();

        while (gitRemotesProcess.StandardOutput.ReadLine() is { } remote)
        {
            startProcessAndWriteOutput.RunFor(git.ValueFor($"pull {remote} {gitCurrentBranch}"));
        }

        break;
    }
}