# FunBooksAndVideos
 
## Overview

FunBooksAndVideos is an e-commerce shop where customers can view books and watch online videos. Users can have memberships for the book club, the video club, or both clubs (premium).

### Highlights:

- Rule Engine to add the new business rules. The rule engine is built using the Chain of Responsibilty Pattern.
- Application use EF Core In-Memory Database.
- Application is built using the Layered Architecture.

- Application has used the following design patterns :

    - Repository Patten
    - Unit of Work Pattern
    - Chain of Responsibility Pattern
    - Factory Pattern
    - SOLID principles


### REST APIs :
- Add Customers and Get Customer's details (Customer, Orders, Memberships)
- Add an Item in the catalog and fetch the Item from the catalog
- Process the Order - Apply all the rules using Rule Engine
- Get Shipping Slips.

### Technologies
FunBooksAndVideos is ASP.NET Core application.


| Technology   | Version | 
| ---------------------------------------------- | ---------- |
| ASP .NET Core | 7.0     | 
| Entity Framework | 7.0  | 

## ER Diagram

<p align="center">
  <img width="1500" height="650" src="SB - ER Diagram.png">
</p>

## Layered Architecture

<p align="center">
  <img width="900" height="200" src="Layered Architecture.png">
</p>

## Rule Engine

Rule engine provides the flexibility to add the business rules to process the order.

To add a new rule, Developer needs to extend the class "PurchaseOrderBusinessRule" and add the rule to the chain (in Process order service) to maintain the order in which it needs to be applied.

Currently, the Application has 2 business rules and runs in the below order :

1) ActivateMembershipBusinessRule
2) GenerateShippingSlipBusinessRule

These rules and corresponding priority can be defined in the DB table and the application can pull it dynamically. 

