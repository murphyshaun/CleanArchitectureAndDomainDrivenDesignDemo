# Global Error Handling
1. Via middleware
2. Via exception filter attribute
3. Problem details
4. Via error endpoint
5. Custom problem details factory


# Flow control
1. Via exceptions
2. Via OneOf
3. Via FluentResults
4. Via ErrorOr & Domain Error

# CQRS + MediatR =
1. CQS vs CQRS
```
CQS (Command Query Seperation):
A command (procedure) does something but does not return a result.
A query (function or attribute) returns a result but does not change the state.
```

```
CQRS (Command query responsibility segregation):
The fundamental difference is that in CQRS objects are split into two objects, one containing the Commands one containing the Queriess.
```
2. MediatR + Mediator Pattern
3. Split by Feature & Clean Architecture


# Object Mapping - Mapster (~ AutoMapper)
