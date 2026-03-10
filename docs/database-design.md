Core Entities
1️⃣ Organization (Multi-Tenant Root)
•	Id
•	Name
•	Industry
•	CreatedDate
Relationships:
•	One-to-many → Users
•	One-to-many → Cases
________________________________________
2️⃣ User
•	Id
•	FirstName
•	LastName
•	Email
•	OrganizationId (FK)
•	RoleId (FK)
Relationships:
•	Many-to-one → Organization
•	Many-to-one → Role
•	One-to-many → Cases (CreatedBy)
•	One-to-many → CaseAssignments
________________________________________
3️⃣ Role
•	Id
•	Name (Admin, Manager, Analyst, Viewer)
________________________________________
4️⃣ Case (Core Business Entity)
•	Id
•	Title
•	Description
•	StatusId (FK)
•	PriorityId (FK)
•	OrganizationId (FK)
•	CreatedById (FK)
•	AssignedToId (FK)
•	SLAExpiration
Relationships:
•	Many-to-one → Organization
•	Many-to-one → User (Creator)
•	Many-to-one → User (Assignee)
•	One-to-many → CaseComments
•	One-to-many → CaseAttachments
•	One-to-many → WorkflowSteps
•	One-to-many → AuditLogs
________________________________________
5️⃣ WorkflowStep
•	Id
•	CaseId (FK)
•	StepName
•	StepOrder
•	IsCompleted
•	CompletedDate
________________________________________
6️⃣ CaseComment
•	Id
•	CaseId (FK)
•	UserId (FK)
•	Message
•	CreatedDate
________________________________________
7️⃣ AuditLog
•	Id
•	EntityName
•	EntityId
•	ActionType
•	OldValue (JSON)
•	NewValue (JSON)
•	PerformedByUserId
•	Timestamp
________________________________________
🧩 Advanced EF Core Concepts To Implement
This is where complexity becomes impressive.
✔ Multiple Foreign Keys to Same Table
Case:
•	CreatedById → User
•	AssignedToId → User
Configure with Fluent API.
________________________________________
✔ Many-to-Many Example
User ↔ Skill
Using join table:
UserSkill
________________________________________
✔ Value Conversions
Store enums as strings:
•	Status
•	Priority
________________________________________
✔ Composite Indexes
Example:
•	OrganizationId + StatusId
•	Email unique constraint
________________________________________
✔ Soft Delete
Add:
public bool IsDeleted { get; set; }
Apply global query filter.
________________________________________
✔ Table Per Hierarchy (TPH)
Example:
Case
→ IncidentCase
→ ServiceRequestCase
