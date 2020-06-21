# CleanCode
An API build with .Net Core using Clean Architecture. It uses SqLite data base. Unit tests and integration tests cover most of the functionality.

1. Open solution in visual studio 2019 
2. Once API is set as start-up project, running the project in debug mode should open Swagger UI for it, otherwise can be accessed from link “/swagger “.

## Here’s  some explanation of the design and tools I ended up using for it:

1. Clean Architecture. It’s Domain layer doesn’t depend upon any other layer. Application layer have only dependency on Domain layer and is independent of Persistence.
2. Application layer have commands and queries based upon Command Query Responsibility Segregation(CQRS) . It also defines interfaces for our infrastructure layer, which only have Persistence at the moment.
3. Some of the tools I am using are
  FluentValidation  - For having validations in application layer and writing unit tests for it

  *AutoMapper* – To help mapping View models from the domain entities.

  *EntityFrameworkCore* – Persistence Layer and for using In Memory Database feature for unit testing.

  *Swagger API Documentation* – For auto generating API documentation and a platform to test the APIs
