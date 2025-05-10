# Todo Manager

A simple task management web app built with **ASP.NET Core 8** (Web API) and a **Bootstrap/HTML frontend**.

## Features

- Add, Update, View and Delete tasks
- Mark tasks as completed
- Filter tasks by status and priority
- Responsive design using Bootstrap
- Backend powered by Entity Framework Core

## Technologies Used

- ASP.NET Core 8
- Entity Framework Core
- Bootstrap 5
- JavaScript / HTML


## Setup Instructions

1. Clone the repository

git clone https://github.com/M-Shoura/Task-Manager.git
cd Task-Manager

2. Run the Backend (ASP.NET Core)

Open the solution in Visual Studio
Update your database connection string in appsettings.json
Press F5 or run the app to start the API

3. Run the Frontend

Navigate to the /frontend folder
Open index.html in your browser
Make sure the API endpoint URLs match your backend base URL

📦 API Endpoints

GET     /api/todo                 -> Get all tasks
GET     /api/todo/{id}            -> Get task by ID
POST    /api/todo                 -> Add a task
PUT     /api/todo/{id}            -> Update a task
PUT     /api/todo/complete/{id}   -> Mark task as complete
Delete  /api/todo/{id}            -> Delete task by Id
