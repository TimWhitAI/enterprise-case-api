# Architecture Document

## 1. Overview

The Enterprise Service Request API is a RESTful backend system designed to manage service requests, workflows, comments, audit logs, and role-based access control.

---

## 2. Architecture Style

This application follows a layered architecture:

Controller → Service → Repository → Entity Framework Core → SQL Server

---

## 3. Key Components

### API Layer
- ASP.NET Core Web API
- Controllers handle HTTP requests
- Swagger documentation enabled

### Business Logic Layer
- Service classes contain business rules
- Validation of workflow transitions
- SLA enforcement

### Data Access Layer
- Entity Framework Core
- Repository pattern
- SQL Server relational database

---

## 4. Security

- JWT-based authentication
- Role-based authorization
- Secure password storage (to be implemented)

---

## 5. Future Enhancements

- Docker containerization
- Cloud deployment (AWS or Azure)
- CI/CD pipeline integration