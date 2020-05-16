# SourceTreeCustomActions

Provides custom actions to be called from SourceTree.\
MyGet Feed for NuGet Package: <https://www.myget.org/F/evilbaschdi/api/v3/index.json>

To add new Custom Action to SourceTree got to Options \ Custom Actions \ "Add"

- Sync Git Remotes
  - [ ] Open in a seperate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: "sync" $REPO "origin" "*Name of another Repo to sync*"
