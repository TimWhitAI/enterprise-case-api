🌐 API Endpoints
Authentication
POST /api/auth/login
POST /api/auth/register
________________________________________
Organizations
GET    /api/organizations
POST   /api/organizations
________________________________________
Cases
GET    /api/cases
GET    /api/cases/{id}
POST   /api/cases
PUT    /api/cases/{id}
DELETE /api/cases/{id}
________________________________________
Advanced Filtering Endpoint
GET /api/cases/search?
    status=Open&
    priority=High&
    organizationId=2&
    createdAfter=2026-01-01&
    assignedTo=5
Use:
•	IQueryable
•	Expression Trees
•	Dynamic LINQ
