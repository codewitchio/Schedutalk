# Schedutalk

##About
This project is part of a school assignment at KTH (Royal Swedish Institution of Technology). The main goal of this project is to learn how to use github in projects and therefore we hope to maintain a good repo at github.

To do practice these qualities at github we first needed a project. So we decided to try something out of our previous experiences, thats why we wanted to create an app working for the biggest mobile OSes in Sweden. Android, iOS and Windows.
We chosen to work with the Xamarin framework for .NET

This project will have as a goal to create a custom calendar using the Xamarin framework. In terms of time more features may be added to the calendar.

Due to the short time this project will be held the goal is to make the app function on a  Nexus 6 running Android 6.0.1 but also a Windows Lumia 435 using windows 10.0.14295.1005. Hopefully other models and version will function as well, this is however out of scope in this project.

Moreover the project will be developed with the MVVM design pattern.

##Some pictures of the app

![](http://i.imgur.com/fYHGHjV.png)

This picture illustrates the schedule view and also the start view of the app. Not that this view is created with two customTimeLineLayouts (a custom layout control made from scratch). Due to this controls ability to contain a generic child element, it was possible to create both the time column but also the event column. Note that you can select which date and also the the events are tapable, once tapped the view provided in the following picture appears. 

![](http://i.imgur.com/7cAKfkO.png)

This view is nothing but really a place to modify certain data connected to that event. Due to the time limit of this course editing time of an event was not implemented.
What makes this view interesting is the "has power outlet" feature. This basically does say wheter the provided place has a power outlet or not. This was done by doing a http request to the [KTH places api](https://www.kth.se/api/places/swagger/?url=/api/places/swagger.json).
This process is done asyncrounously making the UI still responsive during the httprequest.


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
