# SourceTreeCustomActions


[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](LICENSE)
Provides `Custom Actions` for [SourceTree](https://www.sourcetreeapp.com) or [SourceGit](https://sourcegit-scm.github.io/), or any other Git GUI client supporting `Custom Actions`.


## SourceTree
To manage `Custom Actions` in `SourceTree`, go to `Options` (Ctrl+,) > `Custom Actions`

- **Sync Git Remotes**
  - [ ] Open in a separate window
  - [x] Show Full Output
  - [x] Run command silently
  - Script to run: *path to compiled .exe*
  - Parameters: `"sync" $REPO $BRANCH`
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
  - Scope: `Branch`
  - Executable File: *path to compiled .exe*
  - Arguments: `"sync" ${REPO} $BRANCH`
- **Pull all Remotes**
  - Scope: `Branch`
  - Executable File: *path to compiled .exe*
  - Arguments: `"pullAllRemotes" ${REPO} ${BRANCH}`
- **Push to all Remotes**
  - Scope: `Branch`
  - Executable File: *path to compiled .exe*
  - Arguments: `"pushToAllRemotes" ${REPO} ${BRANCH}`

[![CodeFactor](https://www.codefactor.io/repository/github/evilbaschdi/SourceTreeCustomActions/badge/main?style=for-the-badge)](https://www.codefactor.io/repository/github/evilbaschdi/SourceTreeCustomActions/overview/main)

## Package Feeds

Default by NuGet.config is myget.org

|                                | Feed Url                                                         |
| :----------------------------- | :--------------------------------------------------------------- |
| ![myget.org][myGetBadge]       | <https://www.myget.org/F/evilbaschdi/api/v3/index.json>          |
| ![codeberg.org][codebergBadge] | <https://codeberg.org/api/packages/evilbaschdi/nuget/index.json> |


[myGetBadge]: https://img.shields.io/badge/MyGet.org-gray?style=for-the-badge&logo=myget
[codebergBadge]: https://img.shields.io/badge/Codeberg-gray?style=for-the-badge&logo=codeberg