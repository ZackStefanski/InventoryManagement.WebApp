# InventoryManagement.WebApp
Welcome! This project is an inventory management web applicate for a fictional music store. Having been given access to it, you are now able to add, edit, delete, reinstate, and export all the data and information in this database of music equipment.
The code for this project was developed using the MVC format, and the database is managed using SQLite.

The website will initialize the database upon clicking the "Inventory" or "Employees" tab. If this does not succeed, please close the application, delete the "Inventory.db" file, and try again. Having said this, I do not anticipate this being a problem.

The features I use in this program are the following...
 - Create an additional class which inherits one or more properties from its parent
 - Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
 - Use a LINQ query to retrieve information from a data structure (such as a list or array) or file

Additional features include...
 - Expanded the search functionality to search ALL items in the database. It is not case-sensitive.
 - Items that are "deleted" are not removed from the database, but simply marked as "deleted" and not included in the inventory index. They are included in the deleted items list.
 - Newly created items are first checked with existing items in the database to ensure duplicates are not created. The Item Name is the reference for this. For example, if the user deletes a "guitar stand" then attempts to add a new item by the same name, they will be prompted to re-instate it from the deleted list.
 - Users can export the list as a csv file.

Thank you!
Zachary Stefanski