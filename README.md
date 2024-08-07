# Hotel Management System

## Overview

The Hotel Management System is designed to streamline the operations of a hotel, enabling efficient management of customer and room information, booking reservations, and generating statistical reports. This system uses Entity Framework Core, LINQ, and WPF with MVVM architecture, ensuring a robust and scalable solution. The application also implements the Repository and Singleton patterns, ensuring data integrity and efficient resource management.

## Features

### Common Features

- **CRUD Operations**: Perform Create, Read, Update, and Delete operations on data entities.
- **LINQ Queries**: Utilize LINQ for data querying and sorting.
- **Data Passing**: Efficiently pass data within the WPF application.
- **3-Layer Architecture**: Separates the application into Presentation, Business Logic, and Data Access layers.
- **MVVM Pattern**: Implements the Model-View-ViewModel pattern for a clear separation of concerns.
- **Repository Pattern**: Encapsulates data access logic and promotes a more testable and maintainable codebase.
- **Singleton Pattern**: Ensures a single instance of critical classes to manage resources effectively.
- **Data Validation**: Validates data types for all fields to ensure data integrity.

### Admin Functions

- **Manage Customer Information**: Admins can create, update, view, and delete customer information.
- **Manage Room Information**: Admins can manage room details. Deleting a room will only be allowed if it is not part of any existing booking transaction; otherwise, its status will be updated.
- **Manage Booking Reservations**: Admins can handle all aspects of booking reservations, including booking details.
- **Generate Statistical Reports**: Admins can create reports based on a specified period, with data sorted in descending order.

### Customer Functions

- **Profile Management**: Customers can manage their profile information.
- **View Booking History**: Customers can view their booking reservation history.

## Application Architecture

### 3-Layer Architecture

1. **Presentation Layer**: This layer includes all the WPF UI elements and views.
2. **Business Logic Layer**: Contains the application’s business logic and view models.
3. **Data Access Layer**: Handles database interactions using Entity Framework Core and repositories.

### MVVM Pattern

- **Model**: Represents the data and business logic.
- **View**: Represents the UI elements.
- **ViewModel**: Acts as an intermediary between the Model and the View, handling data binding and command execution.

### Patterns Implemented

- **Repository Pattern**: Provides a collection-like interface for accessing domain objects.
- **Singleton Pattern**: Ensures that a class has only one instance and provides a global point of access to it.

## Implementation Details

### Entity Framework Core

- **Database Context**: Configured to handle the database interactions.
- **Entities**: Represents tables in the database.

### LINQ Queries

- **Querying**: Use LINQ for querying data from the database.
- **Sorting**: Sort data using LINQ based on specific criteria.

### CRUD Operations

- **Create**: Add new entries to the database.
- **Read**: Retrieve data from the database.
- **Update**: Modify existing data in the database.
- **Delete**: Remove data from the database, with constraints as specified.

### Data Passing

- **Between Views**: Pass data between different views using view models and data binding.

### Data Validation

- **Validation Logic**: Implement validation for all fields to ensure correct data types and constraints.

## Main Functionalities

### Admin Authentication

- **Login**: Admins can log in using email and password.
- **Access Control**: Based on the role, admins can access specific management features.

### Customer Authentication

- **Login**: Customers can log in using email and password.
- **Profile Management**: Customers can update their personal information.
- **Booking History**: Customers can view their past booking details.

### Reporting

- **Report Generation**: Admins can generate statistical reports for a specified period.
- **Data Sorting**: Reports are sorted in descending order by default.
