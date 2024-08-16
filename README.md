# .NET 8 Web API Example

This repository contains a simplified Web API built with .NET 8, based on a previous production-level API. It is designed as a demo to showcase Clean Architecture, JWT-based authentication and authorization, and basic CRUD operations. The API is compatible with Microsoft SQL databases, both locally and in Azure.

## Target Audience

### Recruiters/Interested Parties

Please note that this is a demonstration project. The API includes key features such as Clean Architecture, JWT token-based authorization and authentication, and Swagger UI for testing JWT and refresh token logic. However, this is a minimalistic setup with no built-in data validation. The purpose is to offer a "plug-and-play" experience, allowing you to focus on testing the functionality without being hindered by data validation issues.

### Learners

This project is of intermediate difficulty and is **not** intended for deployment in its current state. JWT logic should be secured, and sensitive information like connection strings should be stored securely. If you're interested in learning more, feel free to reach out. I recommend using Azure CI/CD pipelines via GitHub and securing sensitive information using Azure Key Vault.

## Domain Overview

The API models a simple domain involving Venues and Events with the following relationships:

- A **Venue** can host multiple events.
- An **Event** is associated with one venue and can have:
  - Multiple Event Times
  - Multiple Additional Images
  - Multiple Lead Artists
  - Multiple Backup Artists

- Each of the above entities (Event Times, Additional Images, Lead Artists, Backup Artists) is uniquely associated with a single event.

These relationships are established through primary key (PK) and foreign key (FK) constraints, with ID-based relationships stored in junction tables.

## User Logic

User roles are basic but functional, influencing who has the ability to create events. More details can be found directly within the code.
