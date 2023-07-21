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

# Validation Behavior | MediaR + FluentValidation

# JWT Bearer Authentication

# 3 Steps for Modeling a Complex Domain
```
To recap:															|	Tóm lại:
1. Identify Entities and treat each entity as an aggregate root		|	1. Xác định các Thực thể và coi mỗi thực thể là một gốc tổng hợp
2. Identify relationships between the entities						|	2. Xác định mối quan hệ giữa các thực thể
3. Merge aggregates if there are constraints						|	3. Hợp nhất các aggregate nếu có ràng buộc
																	|
Possible constraints:												|	Hạn chế có thể:
1. Enforcing Invariants												|	1. Thực thi bất biến
2. Eventual consistency cannot be tolerated							|	2. Không thể dung thứ cho sự nhất quán cuối cùng
																	|
Good indicators that an entity should be an aggregate root:			|	Các chỉ số tốt cho thấy một thực thể phải là gốc tổng hợp:
1. It is referenced by other aggregates								|	1. Nó được tham chiếu bởi các aggregate khác
2. It will be looked up by Id										|	2. Nó sẽ được tra cứu bởi Id

```

<img src="./Images/Domain.JPG"/>
<img src="./Images/Aggregates.JPG"/>

# Domain Layer Structure & Skeleton
<img src="./Images/DomainStructure.JPG"/>
<img src="./Images/DomainStructureDetail.JPG"/>

