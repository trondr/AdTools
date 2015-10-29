function Install
{
    $exitCode = 0

    $exitCode = StartProcess "%InstallCommand%" "%InstallCommandArguments%"

    Write-Host "Installling..."
    $exitCode = 1

    return $exitCode
}


function UnInstall
{
    $exitCode = 0

    $exitCode = StartProcess "%UnInstallCommand%" "%UnInstallCommandArguments%"

    Write-Host "UnInstalling..."
    $exitCode = 1

    return $exitCode
}

###############################################################################
#
#   Logging preference
#
###############################################################################
$global:VerbosePreference = "SilentlyContinue"
$global:DebugPreference = "SilentlyContinue"
$global:WarningPreference = "Continue"
$global:ErrorActionPreference = "Continue"
$global:ProgressPreference = "Continue"
###############################################################################
#
#   Start: Main Script - Do not change
#
###############################################################################
$script = $MyInvocation.MyCommand.Definition
Write-Verbose "Script=$script"
$scriptFolder = split-path -parent $script
Write-Verbose "ScriptFolder=$scriptFolder"
$libraryScript = [System.IO.Path]::Combine($scriptFolder ,"Library.ps1")
Write-Verbose "LibraryScript=$libraryScript"
Write-Verbose "Loading install library script '$libraryScript'..."
. $libraryScript
$scriptInstallLibraryScript = [System.IO.Path]::Combine($scriptFolder , "Tools","Script.Install.Library.ps1")
Write-Verbose "ScriptInstallLibraryScript=$scriptInstallLibraryScript"
Write-Verbose "Loading install library script '$scriptInstallLibraryScript'..."
. $scriptInstallLibraryScript
Write-Verbose "Loading script install tools C# library..."
$assembly = LoadLibrary(CombinePaths($scriptFolder , "Tools", "Script.Install.Tools.Library", "Common.Logging.dll"))
$assembly = LoadLibrary(CombinePaths($scriptFolder , "Tools", "Script.Install.Tools.Library", "Script.Install.Tools.Library.dll"))


$action = GetAction($args)
Write-Verbose "Action=$action"

Write-Host "Executing Install.ps1..."

Write-Host "Executing install action '$installAction'..."
Write-Host "TODO: Implement execution of install action and set exit code"
switch($action)
{
    "Install"
    {
        $exitCode = ExecuteAction([scriptblock]$function:Install)
    }

    "UnInstall"
    {
        $exitCode = ExecuteAction([scriptblock]$function:UnInstall)
    }
}
Write-Host "Finished executing Install.ps1. Exit code: $exitCode"
EXIT $exitCode
###############################################################################
#
#   End: Main Script - Do not change
#
###############################################################################
