using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Api.Migrations
{
    public partial class AddBaseUserSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // add users
            migrationBuilder.Sql("INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'Admin', N'ADMIN', N'maciej.wozniczka@outlook.com', N'MACIEJ.WOZNICZKA@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEGF0vqv9zdrQg3x5R/NjqKMTQjL2qVHHilVGsW3P6oJexM8ArasgRNdwasik0b9oHg==', N'SWSUNKRE64TQAQL3TPRXD3UNJYRTKCCX', N'c8706780-216f-4e31-82a3-6ea012937c22', NULL, 0, 0, NULL, 1, 0)");
            migrationBuilder.Sql("INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ab746421-ccd2-4994-89c0-a61bf4e4c305', N'ClientAdmin', N'CLIENTADMIN', N'maciej.wozniczka2@outlook.com', N'MACIEJ.WOZNICZKA2@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEHbBc87Q49u1Us5Z7myzelZX9PdEy2kj6XeG85UiT35CgDytzVXHYlqzs93OfR+NEg==', N'KGLLOJBKE42ZTDH5CTB5LF746GJS6F2O', N'7347eca9-d6f7-4220-9f8b-260765820205', NULL, 0, 0, NULL, 1, 0)");
            migrationBuilder.Sql("INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'becf732d-9b33-481c-9c14-e60df1342be7', N'ClientUser', N'CLIENTUSER', N'maciej.wozniczka3@outlook.com', N'MACIEJ.WOZNICZKA3@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEB0vYugMO8Tu03fSJSxpgWyLx3orGV/hTekjjcum4q6hXfyzUqJm9Oi4QAzc8wXN2w==', N'JQWUSMGMGEWLLAN34XCYYEAMJIVCSUOO', N'beeb70ba-805d-4790-89a1-a55ee548640b', NULL, 0, 0, NULL, 1, 0)");

            // add roles
            migrationBuilder.Sql("INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'45b29d8e-a5f5-4041-9821-4ecbcf64aa18', N'admin', N'ADMIN', N'eaec138b-6d3e-4731-8f2b-180531da429b')");
            migrationBuilder.Sql("INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'23fae70a-8a08-4b93-9173-8ce66a329709', N'clientadmin', N'CLIENTADMIN', N'ec478b73-0bd7-4a79-a003-eab5ffd3dd88')");
            migrationBuilder.Sql("INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cb24aebf-935e-49e9-a268-5427c6889b16', N'clientuser', N'CLIENTUSER', N'7103347c-bbd8-4907-8286-466789550c9a')");

            // add user roles
            migrationBuilder.Sql("INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'45b29d8e-a5f5-4041-9821-4ecbcf64aa18')"); //admin
            migrationBuilder.Sql("INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'23fae70a-8a08-4b93-9173-8ce66a329709')");
            migrationBuilder.Sql("INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'cb24aebf-935e-49e9-a268-5427c6889b16')");
            migrationBuilder.Sql("INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'ab746421-ccd2-4994-89c0-a61bf4e4c305', N'23fae70a-8a08-4b93-9173-8ce66a329709')"); //client admin
            migrationBuilder.Sql("INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'becf732d-9b33-481c-9c14-e60df1342be7', N'cb24aebf-935e-49e9-a268-5427c6889b16')"); //client user
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
