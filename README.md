# SozoApp
This is an application that serves as a one stop for all your medication and doctors appointment needs.

## Code Louisville Requirements
- **Feature 1:** 
Read data from an external file, such as text, JSON, CSV, etc and use that data in your application <br />
This is accomplished through utilizing SQLite.

- **Feature 2:**
Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event) <br />
This calculation and display is demonstrated in my DoctorsAppointment View page. Here I have a conditional statement that calculates how many days are till the closes appointment entity. If it is under 15 days, a sentence is added to the notification div that contains information on how many days till the appointment, the doctors name, and the location.

- **Feature 3:** 
Create an additional class which inherits one or more properties from its parent <br />
This is demonstrated in the multiple controller classes that inherit from the model classes.

- **Feature 4:** 
Use a LINQ query to retrieve information from a data structure (such as a list or array) or file <br/>
Application controllers use LINQ to request data. They likewise store data in a list by calling ToListAsync().

- **Feature Changed From Initial Proposal:** 
Make at least one unit test.<br/>
I believed that adding a day notification was more practical than a unit test. I will revisit this over the break.

## Technologies
- **Backend** - C# 10 
- **ORM** - EF 6
- **Database** - SQL
- **Frontend** - Razor/HTML/JS/CSS

## Patterns
- MVC (Model, View, Controller)
- Code First Database Creation

## Getting Started
1. Clone git@github.com:Baho717/SozoApp.git
2. Navagate to the source folder
3. Run 'dotnet run'

## Features:

- [ ] Ability to view, add, edit, and delete current medication information.
- [ ] Ability to view, add, edit, and delete medication history.
- [ ] Ability to schedule doctors visits.
- [ ] Ability to take notes at doctors visits for future reference.

##Todo
- [ ] Build new c# .NET mvc app
- [ ] Create Models for the Database
- [ ] Integrate EF 6 into project
- [ ] Scaffold DB and Controllers/ View Based on Models
- [ ] Customize the solution to show off my skills

* <a href="mailto:Benjamin.aho27@gmail.com" title="FreelanceFreedom">Benjamin Aho</a> Maintains this repository
