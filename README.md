# FoodDbApp

This is a simple backend/database server for keeping track of inventory items.

## How to start?

Create a new `json` file in the `FoodDbApp.Api/` directory.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=foodapp;Username=YOUR_USER_NAME;Password=YOUR_PASSWORD"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}
