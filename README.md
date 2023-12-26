
# ThirdTask 

## Overview

ThirdTask is a .NET 6 MVC application designed for managing products, orders, and categories. It leverages Dapper for database access and follows modern development practices, including Dependency Injection (DI) for managing dependencies. Now all of this is a bit long winded way of saying that it just displays a bunch of products.

## Project Structure

- **Models**: Contains data models representing database tables.
- **Repositories**: Implements the logic for database operations using Dapper.
- **Controllers**: Handles incoming HTTP requests and returns responses.
- **Views**: Razor views for rendering the UI.
- **Helper**: Includes helper classes like `ConnectionFactory` for database connection management.

## Dependency Injection Setup

Dependency Injection is configured in the `Program.cs` file:

- Services like `ConnectionFactory` and various repositories (`ProductRepository`, `OrderRepository`, etc.) are registered with the DI container.
- These services are then injected into controllers through their constructors.

## Controllers and Actions

- **ProductsController**: Manages product-related operations.
  - `Index` action returns a view with a list of products.
