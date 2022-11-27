# SourceTreeCustomActions

Provides custom actions to be called from [SourceTree](https://www.sourcetreeapp.com).\
MyGet Feed for NuGet Package: <https://www.myget.org/F/evilbaschdi/api/v3/index.json> (already included in NuGet.config)

To add new Custom Action to SourceTree got to Options \ Custom Actions \ "Add"

- Sync Git Remotes
  - [ ] Open in a separate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: "sync" $REPO "origin" "*Name of another Remote to sync*"
- Push to all Remotes
  - [ ] Open in a separate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: "pushToAllRemotes" $REPO $BRANCH

[![CodeFactor](https://www.codefactor.io/repository/github/evilbaschdi/SourceTreeCustomActions/badge/main)](https://www.codefactor.io/repository/github/evilbaschdi/SourceTreeCustomActions/overview/main)
