# PizzaApp

PizzaApp is a .NET MVC project designed to streamline the ordering process for pizza sellers. With features for creating, editing, and deleting orders, PizzaApp empowers businesses to efficiently manage their pizza orders.

## Table of Contents
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [How to Start the App](#how-to-start-the-app)

## Features

- **Dynamic Home Page:** Welcoming sellers with real-time updates on current promotions and order count.

- **Privacy Page:** Offering valuable insights into the application's privacy policies and company details.

- **Orders Page:** Displaying colored cards for each order, indicating whether they have been delivered (green) or not (red). Sellers can create, edit, and delete orders, specifying details such as location, payment method, and delivery status.

## Project Structure

The project is organized into several key components:

1. **SEDC.PizaaApp.Refactored.DataAccess:**
    - Contains the databases (StaticDb and DBContext) housing essential data for the application, including user information, orders, and pizza lists.

2. **SEDC.PizaaApp.Refactored.Domain:**
    - Houses Enums (Pizza size and Payment methods) and Models (BaseEntity, Order, Pizza, Pizzaorder, and User.cs).

3. **SEDC.PizaaApp.Refactored.Helpers:**
    - Centralizes reusable code, including the DependencyInjectionHelper.

4. **SEDC.PizaaApp.Refactored.Mappers:**
    - Handles mapping throughout the code with specific mappers for Order, Pizza, and User.

5. **SEDC.PizaaApp.Refactored.Services:**
    - Core logic of the project resides here, managing business rules and application behavior.

6. **SEDC.PizaaApp.Refactored.ViewModels:**
    - Defines view models for different components, such as HomeViewModel, Order, Pizza, and UserViewModels.

7. **SEDC.PizaaApp.Refactored.Web:**
    - The main application entry point, housing Controllers, Modules, and Views.

    - **Controllers:** Handle user input and interaction.
  
    - **Modules:** Provide modular functionality.
  
    - **Views:** Contain the presentation layer.

## Getting Started

To understand the project better, familiarize yourself with the key components mentioned above. Make any necessary adjustments based on your specific requirements.

## How to Start the App

1. Open the project using `SEDC.PizaaApp.Refactored.sln`.
2. In Visual Studio, right-click on `SEDC.PizaaApp.Refactored.Web` and set it as the startup project.
3. Start the application.
