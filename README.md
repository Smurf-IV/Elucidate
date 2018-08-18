# Elucidate
  - [Project Description](#project-description)
  - [System Requirements:](#os-requirements)
  - [FAQs](#faqs)
  - [roadmap](#roadmap)
  - [Screenshots](#screenshots)

## Project Description
Elucidate is a GUI front-end for the command-line SnapRAID application.

*This project is a fork of the great work done by Smurf-IV and other contributors. 


## System Requirements:
- Windows Operating System
- SnapRaid Version 11.2 or lower
- 10MB Free Space on target drive
- .Net Runtime 4.7.2 or higher
 
## FAQs

**Q**: What is SnapRAID?<br/>
**A**: SnapRAID is a software-defined snapshot-parity engine for Windows and Linux operating systems.  On the most basic level, it offers protection to the contents of a filesystem under its umbrella by computing the hashes of its component filesand storing the results on a parity file.  In the event of a complete hard drive failure, this parity file can be used to reconstruct the lost data.  For full detail, visit SnapRAID's [official comparison of file protection engines.](http://snapraid.sourceforge.net/compare.html)

**Q**: Why a GUI, the Command Line works!<br/>
**A**: Sometimes, ‘point and clicks’ are easier for a novice to get going with.  SnapRAID's somewhat vague documentation and deep configurability can make adopting it offputting to those looking to try it out!  Our larger goal is to create a feature-complete GUI with additional management features designed to aid a user in maintaining a functioning SnapRAID environment.

**Q**: I’m still uncertain, is there more ?<br/>
**A**: Yes, Have a look at the following documentation for pictures etc.

**Q**: So what are these "Larger Goals" ?<br/>
**A**: See the roadmap below for a complete breakdown of what I mean by this.


## Roadmap
* [8] Keep up with the minimum support of the latest SnapRAID. – **On-going.**
* [x] Ease of use(Phase I) **[All Done]**
  * SnapRAID has three commands, so lets make them simple to access for a novice
  * Progress indicator(s)
  * Logging – Interactive and straight to log.
  * Auto start-up on user login
  * Tool-tips to guide
* [x] Phase II Phase II Feature requests (Upto V.15-0x)
  * [x] Pause, Change priority, Abort.– **Done**
  * [x] Command Extension – Allow extra parameters to the defaults used.– **Done**
  * [x] Scheduling. – **Done**
  * [x] Graphical view(s) of the protected data.– **Done**
* [ ] Phase III – (Restart for V.18-xx onwards)
  * [x] New Compiler – **Done**
  * [x] New SnapRaid 11.x – **Done**
  * [x] Fix file coverage display. – **Done**
  * [ ] Translations.
  * [ ] New Commands.
  * [ ] Log view(s) diagnostics.
  * [ ] Mailer with status reports.
* [ ] Phase IV (Recovery and new SnapRAID Commands ?)
  * [ ] Extended Help with recovery – interactive guides etc..
  * [ ] Show what could be recovered (This will require looking into the SnapRaid codebase to interpret the status file(s)). 

## Screenshots

![Layout With Scheduling](Images/Layout_With_Scheduling_12.1.26.png)


![Coverage Tab](Images/CoverageTab_2.png)
