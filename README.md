# Books Web App for RGT

## Description

This purpose of this project was to complete an interview task to set up a webapp for manipulating book data. Unfortunately, due to unforseen extreme health circumstances, we could not complete the full scope of the project. However, I will outline the current structure of the project as well as the roadmap/goals, so as to explain to the reviewer how the project would look under ideal circumstances.

## Roadmap

- Architecture
  - nginx
  - Ubuntu 24.04
  - C# .NET Core 9.0
  - SQLite 3.0
  - Vue3 JS

- Database
  - Simple books table
    - book_id
    - author
    - title
    - sold (copies sold)

- Frontend
  - Vue3 Single File Components (SFCs)
  - Axios HTTP Library
  - Flexbox
  - Grid
  - Bootstrap
  - Pinia
  - Unit tests using Cypress

- Backend
  - WebApi Controller endpoints (REST API)
  - Factory
  - Factory interface
  - Models
  - SQL queries
  - Unit tests using Moq

## Implementation

### Architecture
The intended architecture for this is very simple. The server would be hosted using nginx, a popular free and open-source server software. The frontend would be implemented using the Vue3 Javascript library, along with helper libraries. The server backend would be implemented in C# using ASP.NET Core v9.0. For our database backend, we chose SQLite3, however we intend for the server backend to be extensible so that other database implementations maybe used. The end goal was an application that could be packaged inside a docker container that could be easily deployed using Kubernetes.

When the user makes a request on the frontend to the backend, the request is first sent to the nginx server, which then routes the request to the C# .NET Core executable. The executable, in turn, handles these requests, and executes the requested operations on the SQLite3 databse.

### Database
Because the data we wish to hold is rather simple and lightweight, an ordinary SQLite3 database file is sufficient for this example. Within it, we simply have one table, `main.books`, which holds the book data we wish to store, including book id, author, title, and the number of book copies that have been sold.

### Frontend
For the frontend of the application, we chose Vue3 Javascript due to our previous experience in it. In the code, we elected to separate the frontend and the backend, and to not have the backend folder host any frontend code. The frontend code is currently stored in the `rgt-demo` folder. Currently, it's is only a basic Vue3 Javascript template.

For the user interface, we will use CSS Grid and Flexbox to make a paginated table-based user interface to display the book data and necessary buttons. This user interface will also be responsive, allowing it to display on mobile devices properly. For each book, we will have buttons and fields that allow us to edit the book title and author, or to increment the books sold. These buttons and fields will be styled using Bootstrap.

We will use Pinia as a Vue store which communicates with the backend, as well as caching the book data that comes back from it. Since we must paginate the book date, the store will have state variables that track the number of books per page, the current page number, and the book data on the current page. To communicate with the backend, the store will have methods which we call their analogous REST API endpoints on the backend. These methods will use the Axios library to make the AJAX requests.

### Backend
For the backend, we elected to use .NET Core due to our previous experience with it. The C# project is stored in the `rgt-backend` folder. Since we chose to keep the backend and frontend code separated (modular), and to use Vue3 SFCs, using the Model-View-Controller (MVC) paradigm does not make sense in this example. Instead, we chose to implement REST API endpoints using a C# WebApi controller. To communicate with the database, we implement a factory, `BookFactory`, which inherits from a factory interface, `IBookFactory`. `BookFactory` is only for SQLite3 databases, but the factory interface allows us to extend to other database implementations, such as PostgreSQL. Because the controller uses the interface definition of the factory, we can swap out the factory implementations easily. We're also investigating how to include dependency injection in this controller.

If the incoming or outgoing data is complex, the C# WebApi requires the we define models for the data. We have `BookModel` which encapsulates the book table schema, and `EditBookRequest`, which encapsulates the data for the "modify/update book" request.

For manipulating data within the SQL database, we have templated SQL files defined in the `rgt-backend/sql`. The factory will read this files, populate the required variables, and then execute the queries using the SQL functions defined in the .NET API.
