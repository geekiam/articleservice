## Recreate a Migration


>Remove the existing files from the Migrations folder

>execute the following command - cd into the database project folder
dotnet ef  migrations add initial
>
> 

### Entity Relationship Diagram
```mermaid
  erDiagram
    SOURCES ||--o{ FEED : allows
    SOURCES {
        uuid id
        string name
        string domain
        string url
        string identifier
    }
    POSTS ||--o{ FEED : is
    POSTS {
        uuid id
        string title
        string permalink
        datetime published
        uuid source_id
    }
```