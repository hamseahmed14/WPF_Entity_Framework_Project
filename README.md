# Project Description

The application is a Covid-19 friendly library system. The purpose of this application is so that a library can limit the amount of visitors to the facility while still offering the basic library features. The members of the library that have an account registered will be able to loan books from the library. The members will be able to browse through the catalogue of books available and are able to put in loan requests. 

The admin can accept loan requests from members and can either allow or deny the requests.  

# Class Diagram

![Class_Diagram](/images/Class_Diagram.PNG)

# ERD

![ERD](/images/ERD.jpg)

# Screenshots of application

<img src="/Screenshots/LogInPage.PNG" alt="Log-In Page" style="zoom:50%;" />

<img src="/Screenshots/RegistrationPage.PNG" alt="Registration Page" style="zoom:50%;" />

<img src="/Screenshots/BooksPage.PNG" alt="Books Page" style="zoom:50%;" />

<img src="/Screenshots/BookDetailsPage.PNG" alt="Book Details Page" style="zoom: 50%;" />

<img src="/Screenshots/AdminPage.PNG" alt="Admin Page" style="zoom:50%;" />

# Sprints

### Sprint 1

###### Kanban board at start of sprint

![images](/images/sprint_1_image_backlog.PNG)



###### Sprint goals

- [x] Create Database
- [x] Create ERD

- [x] Complete User Story 1.1
- [x] Complete User Story 1.2
- [x] Complete User Story 2.1
- [x] Complete User Story 2.2
- [x] Update ReadMe
- [x] Commit changes to GitHub

###### Kanban Board at end of sprint

![sprint_1_KanbanEnd](/images/sprint_1_image_backlog_done.PNG)

###### Sprint review

In this sprint all the user stories have been completed .

###### Sprint Retrospective

The sprint had a big workload, but I have managed to complete all the user stories and side tasks. This sprint has given me enough info on how big the workload should be for the sprints to come. 

Next time I will give myself enough time so that I don't need to under pressure when it is not needed.



### Sprint 2

###### Kanban Board at start of sprint

![kanban board at start](/images/sprint_2_backlog.PNG)



###### Sprint Goals

- [x] User Story 2.1

- [x] User Story 2.1.1

- [x] User Story 2.1.3

- [x] Create Card View for ListBox

- [x] Edit ReadMe to contain sprint 2

- [x] Commit changes to GitHub

  

###### Kanban Board at end of sprint

![Kanban board after sprint](/images/sprint_2_backlog_done.PNG)

###### Sprint Review

Not all user stories have been competed in sprint 2. The user stories that are still being worked on is User Story 2.1 and to be specific task 2.1.1 which is populating the book table in the database.

###### Sprint Retrospective

At the start of the sprint everything went well with no major blocks, but during the testing of a query I soon realised that the database was incorrectly designed. This led to a lot of time being wasted trying to fix it and not completing the sprint on time. 

Next time I would like to plan the sprints properly so that their are no unexpected blocks.



### Sprint 3

###### Kanban Board at start of sprint

![Kanban board sprint 3](/images/sprint_3_backlog.PNG)

###### Sprint Goals

- [x] User Story 2.2
- [x] User Story 2.3



###### Kanban Board at end of sprint

![Kanban board at end](/images/sprint_3_backlog_done.PNG)

###### Sprint Review

All the user stories have been completed for sprint 3. Search and Filter functions have been added to the Book page. The users can use this to search through the catalogue of books. 

###### Sprint Retrospective

In terms of time management sprint 3 went better than sprint 2. This is because the most difficult parts of the project has been completed in sprint 1 and 2. Although I've managed to complete all the user stories, some refactoring is needed when the time is available. 

Next time I would like to spend more time on making the quality of code good and DRY.



### Sprint 4

###### Kanban Board start of sprint

![Kanboard start sprint 4](/images/sprint_4_backlog.PNG)

###### Sprint Goals

- [x] User Story 3.1
- [x] User Story 3.2
- [x] User Story 3.3
- [x] User Story 3.4
- [x] User story 3.5

###### Kanban Board end of sprint

![Kanban board end sprint 4](/images/sprint_4_backlog_done.PNG)

###### Sprint Review

All the user stories in sprint 4 have been completed. A book details page and request functions have been added to the project.

###### Sprint Retrospective

Sprint 4 went very smoothly. All the sprint goals have been completed, which leaves only a few user stories left.

Next time I would like to spend more time on unit testing.



### Sprint 5

###### Kanban Board start of sprint

![Kanban Board sprint 5 start](/images/sprint_5_backlog.PNG)

###### Sprint Goals

- [x] Task 2.1.2
- [x] User Story 4.1
- [x] User Story 4.2

###### Kanban Board end of sprint

![Kanban Board end of sprint 5](/images/sprint_5_backlog_done.PNG)

###### Sprint Review

All the User Stories of sprint 5 have been completed. The sprint consisted of task 2.1.2, which is populating the database with more books. User Story 4.1, which required the creation of an admin account and admin portal where the loan details are displayed. The last user Story was 4.2, which required adding accept and deny functionality so that the admin can deny or accept a loan request.

###### Sprint Retrospective

Sprint 5 was a very light sprint. This sprint completed the functional features of the application. There were no blocks that hindered the development of sprint 5. 

Since the application is mostly complete the next sprint will mostly focus heavily on documentation. 



### Sprint 6

###### Kanban Board start of sprint

![Kanban board at start](/images/sprint_6_backlog.PNG)

###### Sprint Goals

- [x] Task 4 
- [x] Task 5
- [x] Task 6
- [x] Task 7

###### Kanban Board end of sprint

![Kanban Board end of sprint](/images/sprint_6_backlog_done.PNG)

###### Sprint Review

All the tasks of sprint 6 have been completed. The sprint consisted of task 4, which consisted on doing a final GUI test. Task 5, which required the creation of a class diagram for the model layer. Task 6, which was finishing of the last unit tests and make sure all the tests pass. Finally there is sprint 7 where the ReadMe is completed.

###### Sprint Retrospective

There was not a lot of tasks for user sprint 6, but it required some time to finish testing the application. With this sprint I have finished off the final functional requirement. This sprint was rather short, but there was a lot of outside deadlines that interfered with the sprint. Overall, the sprint was a success.



# Overall Retrospective

This project was a big learning experience for me. The library system application was my second three tier application that I have produced. I have learned a lot of in all three aspects of the application. For the G.U.I I have learned how to design the front-end of the application with XAML,  how to bind values to front-end elements and how to handle user events. For the back-end I have used a SQL database, where I have learned how to correctly design the database with Entity Framework using the model first approach. Using the model first approach I have also learned how to update the database schema. For the business layer of the project I have learned how to preform create, read, update and delete queries on the database using C# code. 

During the creation of the application there were a few setbacks. The main cause of this was poor planning at the start. In the first sprint I quickly realised that the database was not correctly  structured. This led to a lot of time being wasted and at the end decided that it was best to delete the database and create it again. Another setback was that at times I have forgotten to create unit tests for methods that I have created. The reason this happened is that I spend most time making sure that the method works and at the end not realise that I didn't create a unit test for it.

What I would do different next time is spending more time planning the project and making sure that unit tests are created before the methods. 

Continuing on from this I would like to add several other features that couldn't be included previously due to not having enough time. What I would like to include are:

- An Admin feature where they can read books from a csv file.
- A better G.U.I
- An Email feature that will be used to inform members if a request had been accepted or denied.



# Further Notes

###### Database Set-up

The application already contains the model of the database. What you need to do is go to the Package Management Console, which you can open via the search bar in Visual Studio. After that you type the following command. 

```
Add-Migration NameOfMigration
```

Followed by:

```
Update-Database
```

###### Database Data

In the LibraryBusiness folder you can find a program.cs file. This file contains the code to create the admin account and 4 book entries. You can use this to add more books if needed.  

