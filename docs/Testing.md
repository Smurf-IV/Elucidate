<hr />

# Start up
- NO CRASHING !
- Check Start is recorded on [Exceptionless website](https://be.exceptionless.io/project/5baf46b571a3042bb85bf097/dashboard)

## Fresh Install
- Switch to the Settings page automatically
- If Settings is closed with no save, then Main Form will be disabled

## Upgrade
- Unless Config items have become disabled, display should be on the Main Tab and enabled
- Attempt to install when Elucidate is running

## Moved Files
- If Config is now invalid then Main Form is Disabled
- If SnapRAID location (version check TBD) is missing then switch to Settings

## Normal
- Display should be on the Main Tab and enabled

<hr />

## Settings

### Fresh Install

### Upgrade

### Moved Files

### Normal
- Edit the Name of Data / Disk entry
  - Ensure that a warning message box is displayed
    - answer yes, allow an edit operation
  - If the name is changed then Ensure that the notification for save is displayed
- Press the "Reset to last" button
- Try to add a directory which is already part of the protected list
  - Drag A directory that is already a root element
  - Drag a directory which is a child of an existing
  - Drag a direcotyr which is on the same drive but not currently protected
  - Should cope with directory redirects (i.e. mount points)

### Save
- Allow save even items are still invalid (To allow extra editing later)
- Ensure that the Saved items reflect the choices made by the user. 
  - Disk_Mount_Points names are stored correctly and in the order selected
  - Contents locations reflect the Disk_Mount_Point locations
  - Excluded items reflect user input (Remember CRUD)
- Re-open via the menu:
  - Ensure that the Settings are restored correctly [(Open the file in an editor and compare)](https://github.com/Smurf-IV/Elucidate/issues/39)
  - 

<hr />

## MainForm
- Should only be enabled if **both** Config and SnapRaid exe are configured.
- Select a region of the _Logging_ area
  - Use copy (Ctrl+C) and paste into another app (like WordPad)
  - Ensure that text colouring (And actual text) are displayed
- Compare the contents of the LiveLog area to an actual log file
  - Ensure that no missing lines are displayed (Take into account cut off number from the app.config)


### Default Tab

### Logs Tab
- Select Elucidate
  - Observe that the view populates with the logs
- Select "Only with Errors"
  - observe that the available files are reduced

- Select Scheduled
- ??


### Coverage Tab
- This should be populated from a valid config file
- It needs to display **All** the _Paths of interest_
- As the Paths are added to the display, separate threads are kicked off to _Fill_ in the usage details
  - Make sure complicated Paths are dealt with
  - Make Sure before Usage displays are complete application can be closed immediately
  - Make sure display shows a _Wait Cursor_ whilst processing
  - Values display should round to nearest storage (i.e. *GB*ytes, *MB*ytes)


