using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignScheduler.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndicies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Customers_Age] ON [dbo].[Customers]
                (
	                [Age] ASC
                )");

            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Customers_Gender] ON [dbo].[Customers]
                (
	                [Gender] ASC
                )");

            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Customers_City] ON [dbo].[Customers]
                (
	                [City] ASC
                )");

            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Customers_Deposit] ON [dbo].[Customers]
                (
	                [Deposit] ASC
                )");

            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Customers_NewCustomer] ON [dbo].[Customers]
                (
	                [NewCustomer] ASC
                )");

            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Customers_CampaignSentDate] ON [dbo].[Customers]
                (
	                [CampaignSentDate] ASC
                )");

            migrationBuilder.Sql(
                @"CREATE NONCLUSTERED INDEX [IX_Campaigns_IsSent] ON [dbo].[Campaigns]
                (
	                [IsSent] ASC
                )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Customers_Age] ON [dbo].[Customers]");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Customers_Gender] ON [dbo].[Customers]");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Customers_City] ON [dbo].[Customers]");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Customers_Deposit] ON [dbo].[Customers]");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Customers_NewCustomer] ON [dbo].[Customers]");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Customers_CampaignSentDate] ON [dbo].[Customers]");
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS [IX_Campaigns_IsSent] ON [dbo].[Campaigns]");
        }
    }
}
