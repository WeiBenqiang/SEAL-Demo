﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;
using AsureRunService.DataObjects;

namespace AsureRunService.Models
{
    public class AsureRunContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=AR_TableConnectionString";

        public AsureRunContext() : base(connectionStringName)
        {
        }
        
        public DbSet<RunItem> RunItems { get; set; }
        public DbSet<KeyItem> KeyItems { get; set; }
        public DbSet<SummaryItem> SummaryItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }        
    }
}
