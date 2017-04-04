<div class="wikidoc">

# Remote Open SQL Manager Quick Start Guide

## Introduction

Remote Open SQL Manager is a GUI for the library RemoteOpenSQLLib.

The ROS Manager lets you organize connections and run queries remotely on SAP R/3 Application Servers.

## Installation Instructions

To install the application run RemoteOpenSQLSetup.msi. Then run Remote Open SQL Manager.

Before using it you have to create a new function module named z_remote_open_sql.

To complete this task you have to connect to the target SAP R/3 application server using a SapGUI session.

To create the function module you may use SE80 or SE37 transactions. Remember to use a Developer user in a developer environment.

Type SE37 and fill the function module field with z_remote_open_sql.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275306 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275305)

Click on Create and choose a function group where creating the new function module.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275308 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275307)

If you want you may create the new function group and the new function module in $TMP (Locale) package. If you will transport the abap code to a production environment you will relocate code in another package.

Click save.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275310 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275309)

Now you have to go to Attributes tab to change the function module Processing Type. Check Remote-Enabled Module.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275312 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275311)

Go to Source Code tab. Select all text and delete it.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275314 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275313)

Now go to Remote Open SQL Manager and select all text contained into Abap Code To Install tab.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275316 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275315)

Copy it and past it into Source Code. Then activate it.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275318 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275317)

Now you have completed the ABAP code installation of Remote Open SQL solution.

## Creating a new destination

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275320 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275319)

Go to Logon parameters tab.

Create a new destination and fill logon parameters.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275322 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275321)

## Setting Options

Remote Open SQL Manager is able to export data into three type of files:

1\. Text files

2\. Excel Workbook

3\. Access Database

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275324 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275323)

You may let all fields empty but if you want to download and open huge text files containing millions records I suggest you to use Large Text File Viewer at [http://www.swiftgear.com/](http://www.swiftgear.com/).

## Creating a new query

Go to Remote Open SQL Queries tab.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275326 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275325)

Create a new query, for example a query to select all fields and all records of MARA (General Material Data) table.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275328 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275327)

Actually the Remote Open SQL Grammar is under construction but you may see current syntax at Remote Open SQL Grammar tab.

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275330 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275329)

From version 1.0.3.0 you may create queries with joins, column aliases and table aliases .

## Start Query

Starting the query you will see subsequent screens:

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275332 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275331)

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275334 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275333)

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275336 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275335)

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275338 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275337)

[![image](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275340 "image")](http://download.codeplex.com/Download?ProjectName=remoteopensql&DownloadId=275339)

When query is executed you may open resulting file clicking Open Query Result button.

</div>