# CKiosk

## Description
A kiosk app for Windows PC's

## Overview
CKiosk consists of the launcher, which does the update on each launch, and the portal.  The portal is configured by an XML file that can be either setup locally, or copied from a UNC share.  The config file copy and caching is built into the app.  After a successful copy (or file placement), the app will be able to run without having share connectivity.  If the app is set to download updates, and is unable to do so, it will use the cached copy.  Error messages regarding file copy failures can be supressed with the app config.

## Installation
You can set either CKiosk Launcher or CKisosk Portal to be the Windows shell.  With the launcher, you also get app updates.

To set the shell, change this key:
`HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon` from `explorer.exe` to `CKioskLauncher.exe` or `CKioskPortal.exe`

## Logic

### Launcher
The launcher can be set in the app.config to attempt to download updates based on the paths set in the app.config.  The launcher will force an 'update' if the portal exe doesn't exist to be able to launch.

After the update, the launcher will attempt to start the portal.  If this fails, or the laucnher cannot locate the portal exe, an error message will be displayed to the user and then the PC will be shut down.

### Portal
The portal works similar to the launcher.  It can be set in the app.config to download the device/group configs from a remote path, also set in the app.config.  The app will cache the downloaded files for future use should it not be able to connect to the remote path in the future.  It can also be set to not attempt file downloads.  It will attempt a download, even if it is set to disabled in the event the local files cannot be located.  If they also cannot be downloaded, the app will throw an exception and quit.

The app will load the settings by precedence from the DeviceConfig.xml first, followed by the GroupConfig.xml.  Both configs can contain all settings.  The only additional entry in the DeviceConfig.xml is the path to the GroupConfig.xml file.  

## Use
You can set any app as an app entry.  The portal will display these apps in their respective groups.  There is no group setup, just name the groups the same and the items will be grouped together.

There are also some predefined 'admin' functions on the bottom right menu that can be enabled/disabled from the XML config.  They will be disabled by default.

The app will also prevent closing and will supress task manager.  

You can set the refresh interval in seconds and the app will attempt to redownload the config files and reload the app listing each interval.  This is in case the kiosk doesn't get restarted often, it will get config changes.