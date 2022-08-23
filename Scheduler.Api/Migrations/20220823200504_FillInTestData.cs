using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Api.Migrations
{
    public partial class FillInTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Licencje
            migrationBuilder.Sql("INSERT INTO [dbo].[Licences] ([Id] ,[IsActive] ,[Name]) VALUES (N'7e231a2e-9eda-4b6c-b32b-006ee267608b', 1 ,'LifeTime')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Licences] ([Id] ,[IsActive] ,[Name]) VALUES (N'40b712a8-44d7-4352-8d3d-e9fd00836a66', 1 ,'Subscription')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Licences] ([Id] ,[IsActive] ,[Name]) VALUES (N'f0d0ae24-e00e-432f-a1e9-c7167dd8bed3', 1 ,'Free')");

            // Przypisanie licencji do admina
            migrationBuilder.Sql("INSERT INTO [dbo].[UserLicences] ([Id] ,[IsActive] ,[UserId] ,[LicenceId] ,[ValidFrom] ,[ValidTo]) VALUES (N'4876aaf3-36c2-46c7-9c55-092593b926dc', 1 ,N'4c289587-ba9f-40d8-b7e7-d62801358fd8' ,N'7e231a2e-9eda-4b6c-b32b-006ee267608b' ,'2000-01-01' ,'2999-12-31')");

            // Utworzenie firmy
            migrationBuilder.Sql("INSERT INTO [dbo].[Companies] ([Id] ,[IsActive] ,[Name])  VALUES (N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 1 ,'Deadline Maciej Woźniczka')");

            // Przypisanie firmy do admina
            migrationBuilder.Sql("INSERT INTO [dbo].[UserCompanies] ([Id] ,[IsActive] ,[UserId] ,[CompanyId]) VALUES (N'25b1db62-d43f-4943-b654-f277f3bcf99f', 1 ,N'4c289587-ba9f-40d8-b7e7-d62801358fd8' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084')");

            // Przypisanie godzin pracy firmy
            migrationBuilder.Sql("INSERT INTO [dbo].[CompaniesOpeningHours] ([Id] ,[IsActive] ,[CompanyId] ,[DayOfTheWeek] ,[OpeningTime] ,[ClosingTime]) VALUES (N'ed9d6db9-9801-4679-aaaf-4df2e8e69975', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,1 ,'0001-01-01 06:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[CompaniesOpeningHours] ([Id] ,[IsActive] ,[CompanyId] ,[DayOfTheWeek] ,[OpeningTime] ,[ClosingTime]) VALUES (N'7378f0a0-03da-4817-a592-132616daa8fd', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,2 ,'0001-01-01 06:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[CompaniesOpeningHours] ([Id] ,[IsActive] ,[CompanyId] ,[DayOfTheWeek] ,[OpeningTime] ,[ClosingTime]) VALUES (N'831bd1a4-fa1b-4dfa-8df7-d27871908e58', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,3 ,'0001-01-01 06:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[CompaniesOpeningHours] ([Id] ,[IsActive] ,[CompanyId] ,[DayOfTheWeek] ,[OpeningTime] ,[ClosingTime]) VALUES (N'59f7e852-5dbb-47d1-a3fc-3eed093e20b3', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,4 ,'0001-01-01 06:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[CompaniesOpeningHours] ([Id] ,[IsActive] ,[CompanyId] ,[DayOfTheWeek] ,[OpeningTime] ,[ClosingTime]) VALUES (N'476986df-c81d-4dbc-a1a5-b672d7ea7ca6', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,5 ,'0001-01-01 06:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[CompaniesOpeningHours] ([Id] ,[IsActive] ,[CompanyId] ,[DayOfTheWeek] ,[OpeningTime] ,[ClosingTime]) VALUES (N'a59f3f73-e376-45ac-a441-a637bedc6a08', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,6 ,'0001-01-01 06:00:00.0000000', '0001-01-01 22:00:00.0000000')");

            // Utworzenie pracowników
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'f1b5c9f2-f3f8-4b95-b437-a77285786735', 1 ,'Kierownik1' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,168 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'dead1b35-6b6f-4dc9-993a-d14511d927ef', 1 ,'Kierownik2' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,84 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'f9a08c71-f0cc-4bd6-8725-bca9fd2647f2', 1 ,'Pracownik1' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,168 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'4490cb06-dafc-4e65-bba4-b77170c1afb3', 1 ,'Pracownik2' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,168 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'2244e9c2-d651-4f30-a3ae-973ba8f3b52e', 1 ,'Pracownik3' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,168 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'496ee0b8-1549-46c1-b999-a0f621117378', 1 ,'Pracownik4' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,168 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'722a2f65-060a-41a8-b008-8199b8a4ec0b', 1 ,'Pracownik5' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,64 ,8 ,10 ,'Full')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Employees] ([Id] ,[IsActive] ,[Name] ,[CompanyId] ,[MonthlyWorkingHours] ,[DailyWorkingHours] ,[MaxDailyWorkingHours] ,[PreferredTimeOfDay]) VALUES (N'e7dcb104-eb2a-49b3-920d-51c80d6ea7bb', 1 ,'Pracownik6' ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,64 ,8 ,10 ,'Full')");

            // Utworzenie stanowisk
            migrationBuilder.Sql("INSERT INTO [dbo].[Positions] ([Id] ,[IsActive] ,[Name]) VALUES (N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1 ,'Kierownik')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Positions] ([Id] ,[IsActive] ,[Name]) VALUES (N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1 ,'Pracownik')");

            // Przypisanie ról do pracowników
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'49d7e0f3-dfea-4eae-8f9d-fa67114b4992', 1 ,N'f1b5c9f2-f3f8-4b95-b437-a77285786735' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'4d4f77bb-759a-4c91-9836-3500c61d05ce', 1 ,N'dead1b35-6b6f-4dc9-993a-d14511d927ef' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'10edde30-cc29-4bb2-b86c-35706be8b176', 1 ,N'f9a08c71-f0cc-4bd6-8725-bca9fd2647f2' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'6b114686-d10e-4624-83f0-78e9b134c884', 1 ,N'4490cb06-dafc-4e65-bba4-b77170c1afb3' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'abae9ecd-35df-46e4-9746-a53b44f579ee', 1 ,N'2244e9c2-d651-4f30-a3ae-973ba8f3b52e' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'87b85787-8bdd-4a96-9047-124ac77d35a2', 1 ,N'496ee0b8-1549-46c1-b999-a0f621117378' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'b00cf3e9-aa62-48e5-8bea-42321a08e496', 1 ,N'722a2f65-060a-41a8-b008-8199b8a4ec0b' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed')");
            migrationBuilder.Sql("INSERT INTO [dbo].[EmployeesPositions] ([Id] ,[IsActive] ,[EmployeeId] ,[PositionId]) VALUES (N'99215613-d78b-4d38-a2aa-6c6b3c1ab892', 1 ,N'e7dcb104-eb2a-49b3-920d-51c80d6ea7bb' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed')");

            // Wymagania do zmian dziennych
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'a8722d8e-a727-48ce-9cde-15e65b7a0096', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6' ,1 ,1 ,'0001-01-01 10:00:00.0000000', '0001-01-01 20:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'77bc160f-8653-4ecf-b324-8325202739a7', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,1 ,'0001-01-01 06:00:00.0000000', '0001-01-01 14:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'0a9c25e9-68c9-48db-9056-9eb59d82c66d', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,1 ,'0001-01-01 14:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'082d461b-c09a-4e9d-8594-c829d930aef9', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,1 ,1 ,'0001-01-01 13:00:00.0000000', '0001-01-01 17:00:00.0000000')");

            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'6055f617-47b4-4161-8a62-0cfbfe75cd78', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6' ,1 ,2 ,'0001-01-01 10:00:00.0000000', '0001-01-01 20:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'6b2ed51b-df15-4651-9fc4-ccc07eb48d05', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,2 ,'0001-01-01 06:00:00.0000000', '0001-01-01 14:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'0c4a36ba-0261-4fec-ad0f-3d9a363e1555', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,2 ,'0001-01-01 14:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'92025414-8759-4a39-bb3d-01c84bffecf8', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,1 ,2 ,'0001-01-01 13:00:00.0000000', '0001-01-01 17:00:00.0000000')");

            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'91e45c3c-a275-47fe-a203-7aa06a345849', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6' ,1 ,3 ,'0001-01-01 10:00:00.0000000', '0001-01-01 20:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'18a829b2-7048-419b-9d78-f91bd4b3f880', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,3 ,'0001-01-01 06:00:00.0000000', '0001-01-01 14:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'e5d43867-f579-4dbd-987c-c0d93453e158', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,3 ,'0001-01-01 14:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'ada1ff09-1f53-4b09-88bc-8098230c065d', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,1 ,3 ,'0001-01-01 13:00:00.0000000', '0001-01-01 17:00:00.0000000')");

            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'4444a3b7-7156-489b-9c21-e0c3662cf893', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6' ,1 ,4 ,'0001-01-01 10:00:00.0000000', '0001-01-01 20:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'24741c10-09e2-4b77-bc16-9050538e16d0', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,4 ,'0001-01-01 06:00:00.0000000', '0001-01-01 14:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'ae09cdc3-3cca-43bd-bb4a-9f305a7f999d', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,4 ,'0001-01-01 14:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'711811a6-f83b-4c63-8808-6afde598a5be', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,1 ,4 ,'0001-01-01 13:00:00.0000000', '0001-01-01 17:00:00.0000000')");

            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'1e52f8d0-1972-4672-b5e4-6c07d03e486c', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6' ,1 ,5 ,'0001-01-01 10:00:00.0000000', '0001-01-01 20:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'd1ad81c7-95b8-40eb-aa3f-d683414215db', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,5 ,'0001-01-01 06:00:00.0000000', '0001-01-01 14:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'e0e9ffd8-6621-4fc2-a2aa-5909740e3d4e', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,5 ,'0001-01-01 14:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'6b0e347e-2ed1-4dd1-9689-2a54519c29af', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,5 ,'0001-01-01 10:00:00.0000000', '0001-01-01 18:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'fbd38163-e29f-42f6-a81e-c71c3d3f7579', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,5 ,'0001-01-01 12:00:00.0000000', '0001-01-01 16:00:00.0000000')");

            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'1e07f138-7968-4c2d-a69b-c5b31243366c', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6' ,1 ,6 ,'0001-01-01 10:00:00.0000000', '0001-01-01 20:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'300f7173-828a-4c3e-80c3-d72f4c07dc04', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,6 ,'0001-01-01 06:00:00.0000000', '0001-01-01 14:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'3f877c0b-3088-45fe-96f0-2d4e25c1d318', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,6 ,'0001-01-01 14:00:00.0000000', '0001-01-01 22:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'912b021d-1fd9-48e3-9623-1bf4331133ed', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,6 ,'0001-01-01 10:00:00.0000000', '0001-01-01 18:00:00.0000000')");
            migrationBuilder.Sql("INSERT INTO [dbo].[WorkdayRequirements] ([Id] ,[IsActive] ,[CompanyId] ,[PositionId] ,[Quantity] ,[DayOfTheWeek] ,[StartTime] ,[EndTime]) VALUES (N'e15e94c1-cee2-461a-a561-60dac4f29eec', 1 ,N'7F3F5FFA-BF1C-4C9B-98A6-2B1BD0BD7084' ,N'9702d623-3b79-413a-a67d-7928c2e3e5ed' ,2 ,6 ,'0001-01-01 12:00:00.0000000', '0001-01-01 16:00:00.0000000')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
