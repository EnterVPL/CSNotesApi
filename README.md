# Notes API

## Description

In this project, I created a **Notes API** using **ASP.NET Core** and **Entity Framework Core** with a **SQLite**
database. The application allows you to create, update, retrieve, and delete notes.

The process of building the application was assisted by **ChatGPT**, which helped me in the following stages:

1. **Generating the application code**:
   ChatGPT helped me generate the basic structure of the ASP.NET Core application, including controllers, data models,
   and database configuration.

2. **Database configuration**:
   ChatGPT guided me in setting up SQLite in the ASP.NET Core application and generating and applying migrations.

3. **Adding Swagger UI**:
   To make testing the API easier, ChatGPT helped me configure **Swagger UI**, which provides an interactive API
   documentation accessible via a browser.

4. **Troubleshooting**:
   Whenever I encountered issues with migrations or tool versions, ChatGPT helped me resolve these problems by providing
   the right commands and settings.

## Instructions to Run

Follow the steps below to run the application on your local machine:

### Clone the repository

First, clone this repository to your device:

```bash
git clone https://github.com/YOUR_GITHUB_USERNAME/notes-api.git
cd notes-api
```

### Install dependencies

Navigate to the project folder and install the required dependencies:

```bash
dotnet restore
```

### Generate migrations (if not done yet)

If you haven't generated migrations yet, run the following command to create the migration:

```bash
dotnet ef migrations add InitialCreate
```

### Apply migrations

Next, apply the migration and create the database by running:

```bash
dotnet ef database update
```

### Run the application

Once the setup is complete, start the application using the following command:

```bash
dotnet run
```

The application will run on the default ports:

- http://localhost:5000 for HTTP
- https://localhost:5001 for HTTPS

Swagger UI will be available at the same address, e.g., https://localhost:5001 or http://localhost:5000.

### Test the API through Swagger UI

Once the application is running, open your browser and go to the Swagger UI:

- http://localhost:5000 (HTTP)
- https://localhost:5001 (HTTPS)

In the Swagger UI interface, you can test various API endpoints, such as:

- `GET /api/notes` – retrieve all notes
- `GET /api/notes/{id}` – retrieve a note by ID
- `POST /api/notes` – create a new note
- `PUT /api/notes/{id}` – update an existing note
- `DELETE /api/notes/{id}` – delete a note

