# Notes
#Important
- change the connection string before running the project if you are running locally  because i have an installation bug that requires writing the full name of the server not localdb or .

#ThoughtProcess (less important)
- This was a simple task so i acted accordingly and didn't go all the way in some cases like seprating concerns as it was trivial and would only impact big projects
- I seperated the book from the borrowing mechanism because it might change like instead if incrementing or decrementing it might be adding and object with the date
of the borrow and return ..etc
- i merged the two tables (Book / BookCopies) together in fluent api but entity framework for some reason still makes a join so i would change that to a manual query in a real project and elminate that extra join
-  exceptions were left simple intentionally to save time
  
