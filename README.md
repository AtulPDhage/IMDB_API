# IMDB API - ASP.NET Core Web API Project

## Overview

This project is a RESTful Web API built using **ASP.NET Core** for managing movie-related data, inspired by the Internet Movie Database (IMDB). It provides endpoints to handle **Actors**, **Genres**, **Movies**, **Producers**, and **Reviews**. The API supports full CRUD (Create, Read, Update, Delete) operations for each entity, making it suitable for a movie catalog backend.

Key features:
- **Entity Framework Core** for data access (assumed integration with a database like SQL Server).
- **Swagger/OpenAPI** for API documentation and testing (accessible at `/swagger`).
- Modular design with separate controllers for each resource.
- Built with .NET 8 or later for modern performance and features.

This API can be used to build a full-stack movie review application, such as a web or mobile app for browsing films, adding reviews, and managing metadata.

## Technologies Used

- **Backend**: ASP.NET Core Web API
- **MicroORM**: Dapper
- **Documentation**: Swashbuckle.AspNetCore (Swagger)
- **Database**: SQL Server (configurable via connection string)
- **IDE**: Visual Studio 
- **Version Control**: Git/GitHub

## Project Structure

```
IMDB_API/
├── Controllers/
│   ├── ActorsController.cs
│   ├── GenresController.cs
│   ├── MoviesController.cs
│   ├── ProducersController.cs
│   └── ReviewsController.cs
├── Models/
│   ├── Actor.cs
│   ├── Genre.cs
│   ├── Movie.cs
│   ├── Producer.cs
│   └── Review.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Program.cs
├── appsettings.json
├── IMDB_API.csproj
└── README.md
```

## API Endpoints

The API follows REST conventions with the base path `/api/`. All endpoints return JSON and use standard HTTP status codes (e.g., 200 OK, 201 Created, 404 Not Found).

### Actors
| Method | Endpoint          | Description                  |
|--------|-------------------|------------------------------|
| GET    | `/api/Actors`     | Get all actors               |
| POST   | `/api/Actors`     | Create a new actor           |
| GET    | `/api/Actors/{id}`| Get actor by ID              |
| PUT    | `/api/Actors/{id}`| Update actor by ID           |
| PATCH  | `/api/Actors/{id}`| Partially update actor by ID |
| DELETE | `/api/Actors/{id}`| Delete actor by ID           |

### Genres
| Method | Endpoint          | Description                  |
|--------|-------------------|------------------------------|
| GET    | `/api/Genres`     | Get all genres               |
| POST   | `/api/Genres`     | Create a new genre           |
| GET    | `/api/Genres/{id}`| Get genre by ID              |
| PUT    | `/api/Genres/{id}`| Update genre by ID           |
| PATCH  | `/api/Genres/{id}`| Partially update genre by ID |
| DELETE | `/api/Genres/{id}`| Delete genre by ID           |

### Movies
| Method | Endpoint          | Description                  |
|--------|-------------------|------------------------------|
| GET    | `/api/Movies`     | Get all movies               |
| POST   | `/api/Movies`     | Create a new movie           |
| GET    | `/api/Movies/{id}`| Get movie by ID              |
| PUT    | `/api/Movies/{id}`| Update movie by ID           |
| PATCH  | `/api/Movies/{id}`| Partially update movie by ID |
| DELETE | `/api/Movies/{id}`| Delete movie by ID           |

### Producers
| Method | Endpoint              | Description                    |
|--------|-----------------------|--------------------------------|
| GET    | `/api/Producers`      | Get all producers              |
| POST   | `/api/Producers`      | Create a new producer          |
| GET    | `/api/Producers/{id}` | Get producer by ID             |
| PUT    | `/api/Producers/{id}` | Update producer by ID          |
| PATCH  | `/api/Producers/{id}` | Partially update producer by ID|
| DELETE | `/api/Producers/{id}` | Delete producer by ID          |

### Reviews
| Method | Endpoint          | Description                  |
|--------|-------------------|------------------------------|
| GET    | `/api/Reviews`    | Get all reviews              |
| POST   | `/api/Reviews`    | Create a new review          |
| GET    | `/api/Reviews/{id}`| Get review by ID             |
| PUT    | `/api/Reviews/{id}`| Update review by ID          |
| PATCH  | `/api/Reviews/{id}`| Partially update review by ID|
| DELETE | `/api/Reviews/{id}`| Delete review by ID          |

## Models (Schemas)

### Actor
- `Id` (int, primary key)
- `Name` (string, required)
- `Bio` (string, optional)
- `DateOfBirth` (DateTime, optional)

### Genre
- `Id` (int, primary key)
- `Name` (string, required, e.g., "Action", "Drama")

### Movie
- `Id` (int, primary key)
- `Title` (string, required)
- `ReleaseDate` (DateTime, required)
- `Description` (string, optional)
- `GenreId` (int, foreign key)
- `ProducerId` (int, foreign key)
- `ActorIds` (List<int>, many-to-many)

### Producer
- `Id` (int, primary key)
- `Name` (string, required)
- `Bio` (string, optional)

### Review
- `Id` (int, primary key)
- `Rating` (int, 1-10, required)
- `Comment` (string, optional)
- `MovieId` (int, foreign key)
- `UserId` (string, optional)

*Note: Relationships (e.g., Movies to Genres/Producers/Actors) are handled via foreign keys in the database.*

## Setup and Running Locally

1. **Clone the Repository**:
   ```
   git clone https://github.com/AtulPDhage/IMDB_API.git
   cd IMDB_API
   ```

2. **Install Dependencies**:
   - Ensure .NET SDK 8.0+ is installed: [Download here](https://dotnet.microsoft.com/download).
   - Run:
     ```
     dotnet restore
     ```

3. **Configure Database**:
   - Update `appsettings.json` with your SQL Server connection string:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=IMDBDb;Trusted_Connection=true;MultipleActiveResultSets=true"
       }
     }
     ```
  -Add Tables using file in Queries.sql 

4. **Run the Application**:
   ```
   dotnet run
   ```
   - The API will start at `https://localhost:7001` (or check console output).
   - Swagger UI: Navigate to `https://localhost:7001/swagger`.

5. **Test Endpoints**:
   - Use Swagger UI to execute requests directly in the browser.
   - Or use tools like Postman or curl.



## Contributing
1. Fork the repo.
2. Create a feature branch (`git checkout -b feature/AmazingFeature`).
3. Commit changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
- **Author**: Atul P Dhage
- **GitHub**: [AtulPDhage](https://github.com/AtulPDhage)
- **Issues**: Report bugs or request features [here](https://github.com/AtulPDhage/IMDB_API/issues).

---

**Built with passion by Atul P Dhage ❤️**
