# Schedutalk

##About
This project is part of a school assignment at KTH (Royal Swedish Institution of Technology). The main goal of this project is to learn how to use github in projects and therefore we hope to maintain a good repo at github.

To do practice these qualities at github we first needed a project. So we decided to try something out of our previous experiences, thats why we wanted to create an app working for the biggest mobile OSes in Sweden. Android, iOS and Windows.
We chosen to work with the Xamarin framework for .NET

Due to the short time this project will be held the goal is to make the app function on a Android Nexus 7 but also a Windows Lumia 635 using windows 10. Hopefully other models and version will function as well, this is however out of scope in this project.

Moreover the project will be developed using Test Driven Developement and with the MVVM design pattern.

##Setting up the environment

**APIs used for compiling the projects code was:**

Xamarin 4.0.3.214

Microsoft .NET Framework version 4.6.01055

//We may have to clarify version of Android SDKs etc.

**Setup guide:**

Begin with installing Visual Studio Community.

https://www.visualstudio.com/post-download-vs?sku=community&clcid=0x409#

After that simply download Xamarin, make sure you have checked in that you are using visual studio

https://www.xamarin.com/download

Now launch visual studio and import the project. (Navigate to the .sln file)
Once done, note in the error list that you can choose which errors to display (default is Build + Intellisense) change this to build.
Then choose suitable deploy device. On windows it is recommend to deploy and test the UI on windows 8.1. (Goes faster compared to laucnhing the android emulator)
