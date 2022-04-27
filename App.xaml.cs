using EmployeeManagementSystem.DbContexts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DbContextsFactory _dbContextsFactory;

        public App()
        {
            string connectionString = @"Host=pgsql14.server758561.nazwa.pl;Database=server758561_EmployeeManagementSystem;Username=server758561_EmployeeManagementSystem;Password=EMSGreen1!";
            _dbContextsFactory = new DbContextsFactory(connectionString);
        }

    }
}
