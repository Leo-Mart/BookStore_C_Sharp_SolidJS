# **WIP** BookStore - A fullstack e-commerce book shop **WIP**

## Motivation

The main purpose of this project is to build something larger, while incorporating different systems and components that a e-commerce site would require. Handling orders, user-pages, pagination, searching etc.
A secondary goal is to learn C# and just build something to keep learning.

## Quick Start

To start using the app locally a few things have to be set up first.

Clone the repo.
In the Backend/BookStore folder, update the appsettings.json (or appsetting.Development.json) with the connection string to a MS SQL DB and a JWT Secret (a base64 string), issuer, and audience.

```json
"JWT": {
    "SigningKey": "YOUR_SIGNING_KEY_HERE",
    "Issuer": "YOUR_ISSUER",
    "Audience": "YOUR_AUDIENCE"
  },
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING_HERE"
  }
```

Run a MS SQL Database in a manner you prefer or alternatively, there is a docker-compose.yml file in the Backend/Bookstore folder that can be used to start a MS SQL Database through Docker.

```bash
docker compose up
```

Make sure to update the DefaultConnection string accordingly.

Run the database migrations from the Backend/BookStore folder (or pass the project to the command)

```bash
dotnet ef database update
```

In the Frontend/BookStore folder run:

```bash
npm i
```

to download dependencies for the frontend.

Then it should be time to start up, run:

```bash
dotnet run -lp https
```

either from BookStore/backend or by passing the path to the project, to start the backend.
Then run:

```bash
npm run dev
```

from the BookStore/Frontend folder.

Once everything is up and running the page should be available at localhost:3000.

## Usage

Once everything has been started as per the [Quick start](#quick-start) section the page should be up and ready to use, like any other e-commerce site. Click around, browse the books, and "buy"" something you like.

For more practical concern, account and their passwords can be seeded by adding to the seeding in Backend/Bookstore/DbContext/ApplicationDbContext.cs. Here more books/authors/genres can also be added. Or you can generate a JSON file with books and have those seed the database with extra data. See the files in Backend/Bookstore/SeedData/ for the schema, and then just replace those files. Be mindful of the Ids though.

## Technologies

### Backend

- [C#/.NET](https://dotnet.microsoft.com/en-us/)
- [Entity Framework Core](https://github.com/dotnet/efcore)
- [MS SQL Server](https://www.microsoft.com/en-us/sql-server/)

### Frontend

- [Typescript](https://www.typescriptlang.org/)
- [SolidJs](https://www.solidjs.com/) For Frontend reactivity and state management.
- [Formisch](https://formisch.dev/) For handling form-validation and runtime-validation in conjunction with [Valibot](https://valibot.dev/)
- [TailwindCSS](https://tailwindcss.com/) For styling

## Contributing

If you'd like to contribute, please fork the repo and open a pull request. Or reach out with your suggestion.
