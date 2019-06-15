ConferenceMate
===============

[![Build Status](https://msctek.visualstudio.com/ConferenceMate/_apis/build/status/ConferenceMate?branchName=master)](https://msctek.visualstudio.com/ConferenceMate/_build/latest?definitionId=1&branchName=master)

ConferenceMate is an open-source, cross-platform Xamarin application that demonstrates a mix of new technologies combined with programming patterns commonly used in enterprise line-of-business (LOB) applications:

- Xamarin.Forms Shell
- Dependency Injection
- MVVMLight for property setter/getter
- Replication of server-side data to mobile client
- Use of a RESTful Web API (hosted in Azure)
- Entity Framework accessing server-side SQL Server database
- SQLite for client-side persistent storage
- Repository pattern
- Factory pattern
- Interfaces
- Mappers
- Logging (App Insights client-side / log4net server-side)
- Developer User Secrets for DB connection strings (not yet)
- App configuration

Most of the projects in this solution are meant to work on many .NET platforms, such as .NET Core, .NET Framework, Xamarin, and ASP.NET Core applications.

## Get Started

1. To examine client-side Xamarin code, open the `MSC.CM.XaSh.sln` found in the \src\MSC.CM.XaSh folder. 
2. To explore the server-side Web API and data access code, open the `MSC.ConferenceMate.Web.sln` found in the \src folder.
3. Use the `100_ConferenceMate_InitializeSchema_v1.0.sql` file to create your own database.  
Alternatively, use the database project that is included as part of the Web solution.
 

> ## DISCLAIMER: This is SAMPLE APP and a WORK IN PROGRESS

This code is a fork of an application being built to experiment with updating some patterns we use 
when building LOB Xamarin applications.  As such, it is definitely a work in progress and 
suggestions for improvement are welcome.

