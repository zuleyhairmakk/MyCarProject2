# DATABASE

The database in this project was MSSQL Localdb. To build the database, go to Visual Studio 2019 and select "View > SQL Server Object Explorer." A new panel will appear on the left. Follow the path "SQL Server > (localdb)MSSQLLocalDB" from this panel, then right-click on the "Databases" folder in the opened folders below, pick "Add New Database," and build your database. Cars is the name of my database.

![image-20220207204559382](C:\Users\züleyha\AppData\Roaming\Typora\typora-user-images\image-20220207204559382.png)

# DATABASE ER DIAGRAM:

![databaseer](https://user-images.githubusercontent.com/87870858/157235470-610afabb-0feb-4b2b-9f4b-68eae04f07cd.png)

# LAYERED ARCHITECTURE:

+ I used layered architecture while preparing the backend of our project. The names of these layers are Business, Core, DataAccess, Entity and WebApi. For each layer, I first created 2 folders called Abstract and Concrete. I wrote the interface codes in the Abstract folder and the codes I used these interfaces in the Concrete folder.

![katmanli mimari](https://user-images.githubusercontent.com/87870858/157235313-bc4a579d-73ff-4d69-b77a-54ce77c14a3d.png)

+ **Entities Layer:** It's here that the object classes that will be used throughout the application are specified. Each class in this layer corresponds to a database table, and it also contains DTO (Data Transfer Object) classes that link data from multiple tables

+ **Data Access Layer:** It's the layer that handles database connections and operations. The necessary database connection setting is completed here. This layer also encodes activities like data extraction, addition, deletion, and updating.

+ **Business Layer:** It is the layer where business rules are defined and controlled. When a command comes to the program, what actions it should perform and which set of rules it should pass through are defined here. Cross-Cutting Concerns are triggered in this layer.

+ **Core Layer:** It is the part where structures, cross-cutting concerns, aspects, extensions and tools to be used in common in all layers are coded.

+ **Service Layer (Web API):** It is the part where the services that enable the Front-End part and other platforms to communicate with the program and perform operations are written.

  # **Used Technologies**

  - Restful     API

  - Result     Types

  - Interceptor

  - Autofac

  - AOP,     Aspect Oriented Programming

  - Caching

  - Performance

  - Transaction

  - Validation

  - Fluent     Validation

  - Cache     Management

  - JWT     Authentication/Encryption/Hashing/Salting

  - Repository     Design Pattern

  - Cross     Cutting Concerns

  - Caching

  - Validation

  - Extensions

  - Claim

  - Service Collection

  -   Validation Error Details

    

    





    

    




