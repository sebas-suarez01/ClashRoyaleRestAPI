# Clash Royale REST API

College project for the course of Software Engineering.

## Architecture

The architecture of the project is a monolithic REST API.
DDD (Domain-Driven Design) is used to structure the project.

## Patterns
It was used the following patterns:
- **Repository(Generic) Pattern**: To abstract the data access layer
- **Service Pattern**: To abstract the business logic
- **CQRS (Command Query Responsibility Segregation)**: To separate the read and write operations
- **Outbox Pattern**: Using Domain Events to saves the events in a outbox table and a background service to process the events.
- **Decorator Pattern**: To add extra behavior to some services like Cache, Logging
- **Specification Pattern**: To create complex queries
- **Unit of Work Pattern**: To manage transactions
- **Result Pattern**: To return the result of the operations
- **Validation Pattern**: To validate the data
- **DTO (Data Transfer Object) Pattern**: To transfer the data between the layers
- **Mapper Pattern**: To map the entities to DTOs
- **Singleton Pattern**: To create a single instance of the services
- **Authentication and Authorization using JWT**: To authenticate and authorize the users

## DDD Project Architecture
![img_1.png](./images/img_1.png)

## Technologies
- **.NET 8**: To build the application
- **Entity Framework Core**: To access the database, create the migrations and seed the data, to manage transactions, tracking changes
- **SQL Server**: To store the data
- **AutoMapper**: To map the entities to DTOs
- **MediatR**: To implement the CQRS pattern
- **FluentValidation**: To validate the data
- **Redis**: To cache the data

## Extras
- **Swagger**: To document the API
- **Docker**: To containerize the application