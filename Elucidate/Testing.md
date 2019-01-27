# Start up
- NO CRASHING !
- Check Start is recorded on [Exceptionless website](https://be.exceptionless.io/project/5baf46b571a3042bb85bf097/dashboard)

## Fresh Install
- Switch to the Settings page automatically
- If Settings is closed with no save, then Main Form will be disabled

## Upgrade
- Unless Config items have become disabled, display should be on the Main Tab and enabled

## Moved Files
- If Config is now invalid then Main Form is Disabled
- If SnapRAID location (version check TBD) is missing then switch to Settings

## Normal
- Display should be on the Main Tab and enabled

## Settings

### Fresh Install

### Upgrade

### Moved Files

### Normal

### Save
- Allow save even items are still invalid (To allow extra editing later)

## MainForm

### Default Tab

### Logs Tab

### Coverage Tab
- This should be populated from a valid config file
- It needs to display **All** the _Paths of interest_
- As the Paths are added to the display, separate threads are kicked off to _Fill_ in the usage details
  - Make sure complicated Paths are dealt with
  - Make Sure before Usage displays are complete application can be closed immediately
  - Make sure display shows a _Wait Cursor_ whilst processing
  - Values display should round to nearest storage (i.e. *GB*ytes, *MB*ytes)


