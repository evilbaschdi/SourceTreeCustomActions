# SourceTreeCustomActions

Provides `Custom Actions` for [SourceTree](https://www.sourcetreeapp.com) or [SourceGit](https://sourcegit-scm.github.io/), or any other Git GUI client supporting `Custom Actions`.

NuGet Package MyGet Feed: <https://www.myget.org/F/evilbaschdi/api/v3/index.json> (already included in `NuGet.config`)

## SourceTree

To manage `Custom Actions` in `SourceTree`, go to `Options` (Ctrl+,) > `Custom Actions`

- **Sync Git Remotes**
  - [ ] Open in a separate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: `"sync" $REPO "origin" "*Name of another Remote to sync*"`
- **Pull all Remotes**
  - [ ] Open in a separate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: `"pullAllRemotes" $REPO $BRANCH`
- **Push to all Remotes**
  - [ ] Open in a separate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: `"pushToAllRemotes" $REPO $BRANCH`

## SourceGit

To manage `Custom Actions` in `SourceGit`, go to `Preferences` (Ctrl+,) > `Custom Actions`

- **Sync Git Remotes**
  - Scope: `Repository`
  - Executable File: *path to compiled .exe*
  - Arguments: `"sync" ${REPO} "origin" "*Name of another Remote to sync*"`
- **Pull all Remotes**
  - Scope: `Branch`
  - Executable File: *path to compiled .exe*
  - Arguments: `"pullAllRemotes" ${REPO} ${BRANCH}`
- **Push to all Remotes**
  - Scope: `Branch`
  - Executable File: *path to compiled .exe*
  - Arguments: `"pushToAllRemotes" ${REPO} ${BRANCH}`

[![CodeFactor](https://www.codefactor.io/repository/github/evilbaschdi/SourceTreeCustomActions/badge/main)](https://www.codefactor.io/repository/github/evilbaschdi/SourceTreeCustomActions/overview/main)
