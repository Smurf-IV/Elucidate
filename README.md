# Elucidate

- [Project Description](#project-description)
- [System Requirements:](#os-requirements)
- [FAQs](#faqs)
- [roadmap](#roadmap)
- [Screenshots](#screenshots)

## Project Description

Elucidate is a Windows GUI front-end for the command-line SnapRAID application.

*This project is a fork of the great work done by Smurf-IV and other contributors.

## System Requirements

- Windows Operating System
- SnapRaid Version 11.2 or lower
- 10MB Free Space on target drive
- .Net Runtime 4.7.2 or higher

## FAQs

**Q**: What is SnapRAID?<br/>
**A**: SnapRAID is a software-defined snapshot-parity engine for Windows and Linux operating systems. On the most basic level, it offers protection to the contents of a filesystem under its umbrella by computing the hashes of its component filesand storing the results on a parity file. In the event of a complete hard drive failure, this parity file can be used to reconstruct the lost data. For full detail, visit SnapRAID's [official comparison of file protection engines.](http://snapraid.sourceforge.net/compare.html)

**Q**: Why a GUI, the Command Line works!<br/>
**A**: The larger goal is to create a feature-complete GUI with additional management features designed to aid a user in maintaining a functioning SnapRAID environment. Sometimes, ‘point and clicks’ are easier for a novice to get going with. SnapRAID's somewhat vague documentation and deep configurability can make adopting it offputting to those looking to try it out!

**Q**: I’m still uncertain, is there more ?<br/>
**A**: Yes, Have a look at the following documentation for pictures etc.

**Q**: So what are the "Larger Goals" ?<br/>
**A**: See the roadmap below for a complete breakdown.

## Roadmap

- [ ] Phase I
  - [ ] Notify the user if their SnapRAID version is outdated
  - [ ] Interpret the SnapRAID logs (used by the changes below)
  - [ ] Provide the status of the array following a command run
  - [ ] Modify the sync command to include an initial diff
  - [ ] Modify the sync command to throw a warning if the diff has reported problems above a threshold
  - [ ] Add user configurable settings for sync threshold requirements
  - [ ] Log view(s) diagnostics

- [ ] Phase II
  - [ ] Mailer with status reports
  - [ ] New Commands
  - [ ] Translations
  - [ ] Extended Help with recovery – interactive guides etc..

## Screenshots

![Starting View](Images/starting_view.png)

![Schedule View](Images/schedule_view.png)
