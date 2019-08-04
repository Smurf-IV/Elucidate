param (
    [Parameter(Mandatory=$true)][string]$exe,
    [Parameter(Mandatory=$true)][string]$args
 )

$args = $args -replace "<DATETIME>", (Get-Date).tostring("yyyyMMdd_HHmmss")

$loopStart = get-date

do {
    if((get-process "snapraid" -ea SilentlyContinue) -eq $Null) {
		Write-Host "To have this window hidden:"
		Write-Host "Edit the Scheduled Task and in Security Options "
		Write-Host "select 'Run whether the user is logged on or not'"
		Write-Host "and also make sure the 'Hidden' checkbox is checked."
		Write-Host ""
		Write-Host "Running SnapRAID process..."
        Start-Process -FilePath $exe -ArgumentList $args -Wait -WindowStyle Hidden
		Write-Host "Done"
        Exit
    } else {
        Write-Host "Another SnapRAID process is already running."
        Start-Sleep 10
    }
}
while((Get-Date) -le $loopStart.AddMinutes(5))

Write-Host "This run attempt failed to run for 5 minutes. Another SnapRAID process was already running."
