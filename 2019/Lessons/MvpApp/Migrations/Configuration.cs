namespace MvpApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Конфигурация миграций
    /// Add-Migration nnn -- добавление очередной миграции
    /// Update-Database -TargetMigration nnn -- переход к нужной миграции
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<MvpApp.Storage.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Начальное заполнение базы данных
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MvpApp.Storage.Database db)
        {
            // Если нет ни одного студента
            if (db.Students.Count() == 0)
            {
                var g = new Storage.Group()
                {
                    Number = 1
                };
                db.Groups.Add(g);
                var s = new Storage.Student()
                {
                    Name = "Иван",
                    FamilyName = "Иванов",                   
                    Group = g
                };
                db.Students.Add(s);
                db.SaveChanges();
            }
        }
    }
}
