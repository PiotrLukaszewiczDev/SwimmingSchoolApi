SwimmingSchoolApi
Overview
SwimmingSchoolApi is a REST API built with ASP.NET Core and .NET. It allows users to manage a swimming school — create lessons with limited capacity, enroll students, check availability and remove enrollments.
The project was built to practice and demonstrate knowledge of C# backend development, with a focus on clean architecture and design patterns.
Features
    • Create swimming lessons with a defined participant limit 
    • Enroll students into lessons with automatic availability check 
    • Prevent overbooking — enrollment is rejected when a lesson is full 
    • Retrieve enrollments by lesson 
    • Remove enrollments by ID 
Architecture
The application follows the Repository Pattern. Controllers handle HTTP requests and delegate data access to repository interfaces. IEnrollmentRepository and ILessonRepository abstract the data layer, keeping controllers clean and testable. Dependencies are registered in Program.cs using the built-in .NET dependency injection container.
Technology Stack
    • Language: C# 
    • Framework: .NET 8 
    • API: ASP.NET Core Web API 
    • ORM: Entity Framework Core 
    • Database: SQL Server 
    • Architecture: Repository Pattern + DTOs 
Getting Started
Prerequisites
    • .NET 8 SDK 
    • SQL Server (or SQL Server Express) 
    • Visual Studio 2022 
Installation
git clone https://github.com/PiotrLukaszewiczDev/SwimmingSchoolApi.git
Open SwimmingSchoolApi.sln in Visual Studio, update the connection string in appsettings.json and apply migrations:
dotnet ef database update
Press F5 to run. Swagger UI is available in development mode.
API Endpoints
Lessons
Method
Endpoint
Description
POST
/api/lesson
Create a new lesson
GET
/api/lesson
Get all lessons
GET
/api/lesson/{id}
Get lesson by ID
GET
/api/lesson/{id}/available-places
Check availability
Enrollments
Method
Endpoint
Description
POST
/api/enrollment
Enroll a student
GET
/api/enrollment/{id}
Get enrollment by ID
GET
/api/enrollment/lesson/{lessonId}
Get enrollments for a lesson
DELETE
/api/enrollment/{id}
Remove an enrollment
Author
Piotr Łukaszewicz GitHub: github.com/PiotrLukaszewiczDev
