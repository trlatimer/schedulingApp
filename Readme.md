# Readme File for Scheduling App

## PURPOSE:
This project was my final project for C969 Software II - Advanced C# through Western Governor's University. This course focused on advanced aspects of C# such as advanced exception control, lambda expressions, data implementatio, and globalization/localization. The project provides a user interface for users to create accounts, create, edit, delete customers and appointments, as well as view appointments they have created. I added a CalendarPicker on the appointments form so users can select a date and view appointments within the designated time frame. They have the option of choosing between Month, Week, and Day which will display appointments within the time frame of the day they have selected on the CalendarPicker.

The software converts all added appointments and times to UTC and converts it to the local time of the host machine when running to allow for standardized appointment times globally. The login page will translate to French if the computer locality is of French origin as well. 

## REQUIREMENTS FOR PROJECT:
A.    Create a log-in form that can determine the user’s location and translate log-in and error control messages (e.g., “The username and password did not match.”) into the user’s language and in one additional language.

B.    Provide the ability to add, update, and delete customer records in the database, including name, address, and phone number.

C.    Provide the ability to add, update, and delete appointments, capturing the type of appointment and a link to the specific customer record in the database.

D.    Provide the ability to view the calendar by month and by week.

E.    Provide the ability to automatically adjust appointment times based on user time zones and daylight saving time.

F.    Write exception controls to prevent each of the following. You may use the same mechanism of exception control more than once, but you must incorporate at least  two different customized mechanisms of exception control.

	•   scheduling an appointment outside business hours

	•   scheduling overlapping appointments

	•   entering nonexistent or invalid customer data

	•   entering an incorrect username and password

G.   Write two or more lambda expressions to make your program more efficient, justifying the use of each lambda expression with an in-line comment.

H.    Write code to provide reminders and alerts 15 minutes in advance of an appointment, based on the user’s log-in.

I.    Provide the ability to generate each  of the following reports using the collection classes:

	•   number of appointment types by month

	•   the schedule for each  consultant

	•   one additional report of your choice

J.    Provide the ability to track user activity by recording timestamps for user log-ins in a .txt file, using the collection classes. Each new record should be appended to the log file, if the file already exists.

K.    Demonstrate professional communication in the content and presentation of your submission.

## REQUIRED PROGRAMS/LIBRARIES:
Visual Studio

Mysql Connector

Mysql for Visual Studio

.NET Framework


## TO START PROGRAM:
1. Download and unzip files

2. Open SchedulingApp.sln in Visual Studio

3. Ensure that mysql is properly installed

4. Click "Run" to begin building and running the application

5. The login form should appear after a couple seconds. You can login with account: "Test" "Test" or create your own.

## BUG REPORTING
Please report any issues and bugs to me at trlatimer95@gmail.com. Please ensure to include a complete description of the issue you are experiencing and steps to recreate the issue. Thank you!
