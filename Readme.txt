
Prerequisite
Application is coded using Visual Studio 2012. Asp.net MVC4 is used.For database
Sql Server 2008 is used. Dot Net Framework 4 is used to create the application.


Database Deployment

First Create the database named NationalCrime in Sql Server. Then Run the database
script. Script has dummy records also.Windows authentication is used so no need to
create user and password. Integrated Security true will work. One of the username is tpriyesh and its password is abc12345


Run the source code
Source code can either be run directly in visual studio 2012 or it can be run
by deploying in IIS.Dot net framework 4 should be installed on server.
There are couple of changes one need to make before running the source code.

1)First go into project NationalCrime.Service. Open the web.config file which will be
present at the root of this project.Edit the appsetting element.Change the below
settings according to your mail server setting.
a) host
b) port
c) userName
d) Password
e) enableSSL

2) Then go to the project NationalCrime.Dal. Go into properties folder there, you will find
settings.setting file will be there. In this file connection string is present for the app
Edit it according to your server credential.


Assumption
Project is coded on windows 8.1 64 bit machine with .net framework 4. Itextsharp dll is already present in the source code.You just have to run the project
with above said changes. Hopefully it willl run without any issues.


Suggestion
Project is OK.No issue with that

