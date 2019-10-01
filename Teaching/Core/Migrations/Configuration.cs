namespace Bmstu.IU6.Teaching.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Конфигурация миграций
    /// Add-Migration nnn -- добавление очередной миграции
    /// Update-Database -TargetMigration nnn -- переход к нужной миграции
    /// Update-Database -TargetMigration $InitialDatabase - переход к начальному состоянию БД
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Bmstu.IU6.Teaching.Storage.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Bmstu.IU6.Teaching.Storage.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
