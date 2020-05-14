using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartStoreInventoryManagement.Core.Migrations
{
    public partial class Sp_GetAllCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
                                CREATE PROCEDURE Sp_GetAllCategory
                                   @Keyword [nvarchar](150),
                                    @pageIndex [int] = 1,
                                    @pageSize [int] = 50
                                AS
                                BEGIN
    
    
                                    SET DATEFORMAT dmy;
                                    select [Id], [CategorNumber],[Name],[Description],
									FORMAT(createdon, 'dd/MM/yyyy, hh:mm tt') [Date]
									,COUNT(*) over() as TotalCount from Category dep
                                    where ((@Keyword IS NULL) OR (dep.Name like '%'+ @Keyword + '%')
									 OR (dep.CategorNumber like '%'+ @Keyword + '%'))
                                    and dep.IsDeleted =0
                                    Order By dep.CreatedOn
                                    OFFSET ((@pageIndex-1)*@pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY
    
                                END
                                 ";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE Sp_GetAllCategory";
            migrationBuilder.Sql(procedure);
        }
    }
}
