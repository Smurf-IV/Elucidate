Beginners Guide -
=================



How does it work ?
==================

The intention of Elucidate, is to make it easier and clearer on how to use the
[SnapRAID](http://snapraid.sourceforge.net/manual.html) Command-line
application.  
Lets take a look at the layout:

![Starting View](../Images/starting_view.png)

*Menu*
======

### [Settings](Settings.md)

This will hold the preferences that have been setup for this application.  
It will need to know the location of the SnapRAID executable.  
On the first run this form will show and ask the user to fill in this location
before enabling any of the buttons.  
It also needs to generate or locate the config file for SnapRAID to use. Without
this, SnapRAID will not work as expected. *More on this later.*

### View Log

This will start up a viewer to look at the log files that Elucidate generates
during it's processing. On Windows this will be WordPad.

### Help

A brief intro, probably this page :-)

*Buttons*
=========

### *D*ifferences

This will switch to the Real-Time View and then run the "diff" command. It will
list all the file changes that have occurred since the last *S*ync command.

### *S*ync

This will generate or refresh (synchronize) the snapshot parity data sets.

### *C*heck

If will read all your data, to check if it's correct.  
If an error is found, you can use the "fix" command to fix it.

### Real-time View

This is a tail of the current data being written to the log view.  
It is marked up with colors to show the type of logging; So if you see red in
the middle of a run, then that's probably bad!

### Status Bar

The left side shows the locale time stamp Followed by the current status.

This can also be used to **Use Idle / Pause / Abort / Reset** back to Running,
the current SnapRaid process.

The right show the progress percentages that come from SnapRAID.
