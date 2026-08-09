# GitClientCustomActions

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

## Package Feeds

Default by `NuGet.config` is myget.org

| Feed                           | Feed Url                                                         |
| :----------------------------- | :--------------------------------------------------------------- |
| ![myget.org][myGetBadge]       | <https://www.myget.org/F/evilbaschdi/api/v3/index.json>          |
| ![codeberg.org][codebergBadge] | <https://codeberg.org/api/packages/evilbaschdi/nuget/index.json> |

## Quality & Activity

| Branch                          | Status & Activity                                                                                                                                      |
| :------------------------------ | :----------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Main Branch][mainBranchBadge] | [![CodeFactor][codeFactorMainBadge]][codeFactorMainOverview] ![Commit Activity Main][commitActivityMainBadge] ![Last Commit Main][lastCommitMainBadge] |

[myGetBadge]: https://img.shields.io/badge/MyGet.org-gray?style=for-the-badge&logo=myget
[codebergBadge]: https://img.shields.io/badge/Codeberg-gray?style=for-the-badge&logo=codeberg

[mainBranchBadge]: https://img.shields.io/badge/branch-main-brightgreen?style=for-the-badge&logo=git&logoColor=white&color=c9ff00
[developBranchBadge]: https://img.shields.io/badge/branch-develop-blue?style=for-the-badge&logo=git&logoColor=white&color=0080ff

[codeFactorMainBadge]: https://www.codefactor.io/repository/github/evilbaschdi/GitClientCustomActions/badge/main?style=for-the-badge
[codeFactorMainOverview]: https://www.codefactor.io/repository/github/evilbaschdi/GitClientCustomActions/overview/main
[commitActivityMainBadge]: https://img.shields.io/github/commit-activity/m/evilbaschdi/GitClientCustomActions/main?style=for-the-badge
[lastCommitMainBadge]: https://img.shields.io/github/last-commit/evilbaschdi/GitClientCustomActions/main?style=for-the-badge

[codeFactorDevelopBadge]: https://www.codefactor.io/repository/github/evilbaschdi/GitClientCustomActions/badge/develop?style=for-the-badge
[codeFactorDevelopOverview]: https://www.codefactor.io/repository/github/evilbaschdi/GitClientCustomActions/overview/develop
[commitActivityDevelopBadge]: https://img.shields.io/github/commit-activity/m/evilbaschdi/GitClientCustomActions/develop?style=for-the-badge
[lastCommitDevelopBadge]: https://img.shields.io/github/last-commit/evilbaschdi/GitClientCustomActions/develop?style=for-the-badge