# BurgerApp

## Overview

BurgerApp is an MVC Web application designed for burger shops to efficiently manage burger orders and locations. Serving as a comprehensive burger manager, the application offers features such as order statistics, a burger menu, location management, and order tracking.

## Features

### Home Page

- Welcome message and overview of the most ordered burger.
- Display of the total number of orders and the average price, calculated from the database.
- List of all shop locations.

### Admin Section

#### Burger Menu

- Ability to create, edit, and delete burger entries. 
  - Edit options include adjusting price, changing burger name, specifying vegetarian/non-vegetarian status, and indicating if fries are included.

#### Locations

- List of all shop locations with the option to edit, delete, or add new locations. 
  - Edit options include setting the shop's address, name, and operating hours.

#### Orders

- Comprehensive list of all orders made, including customer details, shop location, and delivery status. 
  - Ability to create new orders, view order details, and add or remove burgers from an order. 
  - Edit orders to modify customer information, delivery status, and shop location. 
  - Delete orders if they are canceled.

#### About Us

- Information about the burger shop and its business.

## Getting Started

1. Open the [SEDC.BurgerApp.DataAccess.sln](link-to-your-project) solution in Visual Studio.
2. Navigate to **Tools** > **NuGet Package Manager** > **Package Manager Console**.
3. Set the default project to **SEDC.BurgerApp.DataAccess** and run the following commands:
   - `add-migration [migration-name]`
   - `update-database`

Ensure that the project works with [MsSQL Server](link-to-mssql).

4. Right-click on **SEDC.BurgerApp.Web** and set it as the default start project.

## Project Structure

- **SEDC.BurgerApp.DataAccess**
  - **Data**: Contains DBContext and static database data.
  - **Migrations**: Stores all database migrations.
  - **Repositories**: Holds repository classes.

- **SEDC.BurgerApp.Domain**
  - Defines the project's entities and modules (e.g., BaseEntity, Burger, BurgerOrder, Location, and Order).

- **SEDC.BurgerApp.Helpers**
  - Contains reusable code, including DependencyInjectionHelper for dependency injection.

- **SEDC.BurgerApp.Mappers**
  - Maps items from various classes, including BurgerMapper, LocationMapper, and OrderMapper.

- **SEDC.BurgerApp.Services**
  - Houses the core logic of the application.

- **SEDC.BurgerApp.ViewModels**
  - Includes view models for each page, such as BurgerViewModels, HomeViewModels, LocationViewModels, and OrderViewModels.

- **SEDC.BurgerApp.Web**
  - The main MVC Web application.
  - **Controllers**: Controllers for handling view models.
  - **Views**: Presentation layer for UI.
  - **Models**: Model classes for the application.
  - **Program.cs**: Entry point for the application.
  - **appsettings.json**: Configuration file for the MsSQL database.

## Dependencies

- [MsSQL Server](link-to-mssql)

Feel free to reach out if you have any questions or need further assistance!
