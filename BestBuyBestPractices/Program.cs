﻿

using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("Zack's New Department");

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
	Console.WriteLine(department.DepartmentID);
	Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}
