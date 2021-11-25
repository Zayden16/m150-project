BEGIN;

INSERT INTO "Group"("Name", "Description")  
VALUES ('Peaky blinders', 'Birmingham gang');

INSERT INTO "User"("Username", "Email", "Password", "GroupId")  
VALUES ('thomas.shelby', 'thomas.shelby@gmail.com', 'password', 1);

INSERT INTO "User"("Username", "Email", "Password", "GroupId")  
VALUES ('arthur.shelby', 'arthur.shelby@gmail.com', 'password', 1);

INSERT INTO "ShoppingList"("GroupId")  
VALUES (1);

INSERT INTO "Category"("Name")  
VALUES ('Grocery');
INSERT INTO "Category"("Name")  
VALUES ('Bar/Party');
INSERT INTO "Category"("Name")  
VALUES ('Rent');
INSERT INTO "Category"("Name")  
VALUES ('Bill');
INSERT INTO "Category"("Name")  
VALUES ('Excursion/Culture');
INSERT INTO "Category"("Name")  
VALUES ('Health');
INSERT INTO "Category"("Name")  
VALUES ('Shopping');
INSERT INTO "Category"("Name")  
VALUES ('Restaurant');
INSERT INTO "Category"("Name")  
VALUES ('Accommodation');
INSERT INTO "Category"("Name")  
VALUES ('Transport');
INSERT INTO "Category"("Name")  
VALUES ('Sport');
INSERT INTO "Category"("Name")  
VALUES ('Reimbursement');

INSERT INTO "Cost"("Price", "Description", "Date", "CategoryId", "GroupId")  
VALUES (99, 'Einkauf', '10.10.2021', 1, 1);

INSERT INTO "Payment"("PaymentId", "UserId", "IsPayee", "CostId")  
VALUES (1, 1, true, 1);

INSERT INTO "Payment"("PaymentId", "UserId", "IsPayee", "CostId")  
VALUES (1, 2, true, 1);

INSERT INTO "Item"("Name", "Quantity", "IsPurchased", "ShoppingListId", "CategoryId", "UserId")  
VALUES ('Beer', 6, true, 1, 1, 1);

END;
