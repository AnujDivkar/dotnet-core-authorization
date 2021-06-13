
1)Create a DB in SQL as Applicationdb.
2)Set the DefaultConnection sting in appsettings.json file.
3)Only If you made any changes to ApplicationUser class you will need to generate the migration script
  execute in Package manager terminal   "add-migration initialmigration"
4)Create the table by executing "Update-Database"
5)If you are using Default Identity UI. Then you might need to update IdentityUser to ApplicationUser in the _LoginPartial.cshtml file.
6)Import the Req/Res from Postman Folder.