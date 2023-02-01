## DealerOn App
## Sales Taxes
### Written in C#/.NET 6

### Build:
### `cd src/SalesTax`
### `dotnet build`

### RUN:
### `cd src/SalesTax`
### `dotnet run`

### Unit tests:
### `dotnet test`

&nbsp;
#### This application takes input from the customer one line at a time for items they would like to add to the cart.
#### Once they are done adding items, it prints out a receipt with the items, sales taxes, and total.

```
Example input:
1 Book 12.49
1 Book 12.49
1 Music CD 14.99
1 Chocolate bar 0.85
```

```
Example output:
Book: 24.98 (2 @ 12.49)
Music CD: 16.49
Chocolate bar: 0.85
Sales Taxes: 1.50
Total: 42.32
```