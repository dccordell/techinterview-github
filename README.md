# Technical Interview Homework: GitHub Dashboard

## App install and review notes from Daniel
To meet the below requirements for this assignment, I chose to build a basic web application using the ASP.NET MVC framework in Visual Studio 2017. While this is, admittedly, my first time using any of these technologies and tools, I wanted to use this project to gain some experience and knowledge using a MVC structure, as well as familiarize myself with Visual Studio. Even though this is a simplistic application, I believe starting with ASP.NET MVC would ease any future enhancements of the app. Being a web app, any platform with a modern browser should be able to use and interact with it, and responsive design tools (ie. Bootstrap) would make it easy to render perfectly on most screen sizes.

### Retrieving and installing the app
The application files have been pushed to this forked repo, and can be cloned into a local copy of Visual Studio. Having done that, taking the usual steps of building (Ctrl-Shift-B) and then running the app (F5) will open the app home page on the default browser.

### Accessing the app on Microsoft Azure
The application has been deployed to the Microsoft Azure cloud and is accessible at the following URL: 
<p align="center">http://danielsgithubdashboard.azurewebsites.net/</p>

### Other notes
By using the dashboard app as an unauthenticated Github user, Github may start denying API requests if the Events list is refreshed too often (about 60 times in a short amount of time). If this limit is reached, any further action within the app requiring a call to Github will result in an error message. To help keep track of the number of hits remaining, I've added a counter in the top left of every page.

## Purpose
The purpose of this exercise is to assess the candidate’s ability to build cross platform software clients that satisfy stated requirements. The completed assignment should not only satisfy the requirements outlined below, but also give the candidate an opportunity to show-off their skills.

## Prerequisites
- Candidates must have a GitHub account

## Instructions
1. Fork this repository - [https://github.com/Praeses/techinterview-github](https://github.com/Praeses/techinterview-github)
2. Create a client that satisfies the requirements below
3. Include, at the top of this README, instructions required for the reviewer to run the submission
4. Include, at the top of this README, any other information that will be useful to the reviewer
5. Create a pull request prior to the due date to have your submission reviewed

Once the submission is reviewed the candidate will be notified and possibly invited to participate in a follow-up interview where interviewers will collaboratively work with the candidate to review the submission, discuss possible enhancements, and possibly implement a new feature. 

##### Additional Notes...

- Feel free to ask your point of contact any clarifying questions you might have. 
- Submissions must be relatively trivial to run as outlined in the candidate's instructions. We suggest that you test the run instructions on a clean clone of your repository. **Submissions we can't run per the instructions will be rejected.**
- Client technology for the submission is at the discretion of the candidate, Preferred platforms include the following...
	- **Xamarin** - Xamarin Studio or Visual Studio
	- **HTML/CSS/JS (touch friendly, tablet/phone targeted)**
	- **Native iOS** - Xcode 
	- **Native Android** - Android Studio
	- **Windows/Phone** - Visual Studio
- Third party libraries or packages are acceptable but must be managed via a package manager i.e. Nuget, CocoaPods, npm, bower, etc. Third party components will NOT be manually installed by the reviewer.

## Assessment

Cross platform client development requires a familiarity and aptitude to work with...

- Client platforms: iOS, Android, Windows, Web Browsers, etc.
- Presentation layer frameworks: Native iOS & Android, Cordova, HTML/CSS/JS, etc.
- HTTP based APIs

##### Assessment will focus on the candidate's ability to...

- Review and understand API documentation.
- Consume an API, and present API content in a client. 
- Write clear, understandable, and maintainable code. Please use the predominant coding style for whatever language the submission is written in.
- Create a simple and understandable user interface and user experience. Note that clear and understandable does NOT mean graphically interesting.
- The user experience should be targeted at a mobile screen size, preferably tablet optimized yet functional on a phone sized screen.

##### Exceptional Candidates will...

- Submit a solution that will run on both iOS and Android
- Have a simple architecture that is easy to enhance and extend

## Requirements - GitHub Dashboard 
GitHub has a public API that will be used for this assignment. We will be displaying content from the GitHub API in a user "dashboard."

##### Resources
- [GitHub API](https://developer.github.com/v3/ "GitHub API")

##### Minimum Requirements
- The client will have a title clearly indicating the purpose and content of the client.
- The client will be touch friendly.
- The client will display a feed of GitHub public events available at the following endpoint
	- Public Events url: [https://api.github.com/events](https://api.github.com/events)
	- Events Documentation: [https://developer.github.com/v3/activity/events/](https://developer.github.com/v3/activity/events/)
- Each public event displayed in the feed will display user friendly values for...
	- Username
	- Event Type
	- Repository to which the event applies
- The client will have a button to refresh the feed of public events.
- The client will allow a user to tap the public event and display event details.

##### Optional (stretch) Enhancements
- Implement a "pull down" to refresh the feed of public events.
- On the public event details screen...
	- Display a user's avatar next to their name.
	- Provide a link/button to display in the app or a separate browser window the GitHub repository's main web page.
- Authenticate a GitHub user
- Display the authenticated user's username and avatar in client-platform typical location
- Display a feed of the Events performed by the authenticated user
	- [https://developer.github.com/v3/activity/events/#list-events-performed-by-a-user](https://developer.github.com/v3/activity/events/#list-events-performed-by-a-user)
- Support screen rotation
