using Microsoft.EntityFrameworkCore.Migrations;

namespace colors.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Chuck','Sanders', 'red', GETDATE(), 32)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Larry','Bird','green', GETDATE(),63)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Jim','Carrey','green', GETDATE(),61)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Michael','Jordan', 'red', GETDATE(), 55)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Eric','Channey', 'blue', GETDATE(), 26)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Kobe','Bryant', 'purple', GETDATE(), 43)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Lebron','James', 'purple', GETDATE(), 38)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Derrick','Rose', 'red', GETDATE(), 35)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('Kyle','Harris', 'yellow', GETDATE(), 14)");
          migrationBuilder.Sql("INSERT INTO Entries VALUES ('John','Wayne', 'yellow', GETDATE(), 17)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
          migrationBuilder.Sql("DELETE FROM Entries WHERE LastName IN ('Sanders', 'Carrey', 'Harris', 'Wayne','Bird','Jordan','Channey','Bryant','James','Rose')");
        }
    }
}
