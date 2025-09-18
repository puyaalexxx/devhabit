using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabit.Api.Migrations.Application;

/// <inheritdoc />
public partial class Changed_Some_Wrong_Models_Fields : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "frequency_time_per_period",
            schema: "dev_habit",
            table: "habits",
            newName: "frequency_times_per_period");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at_utc",
            schema: "dev_habit",
            table: "habits",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "frequency_times_per_period",
            schema: "dev_habit",
            table: "habits",
            newName: "frequency_time_per_period");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at_utc",
            schema: "dev_habit",
            table: "habits",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");
    }
}
