using NewsSystem.Models;

namespace NewsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Data.NewsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(NewsSystem.Data.NewsSystemDbContext context)
        {
            context.News.AddOrUpdate(
                n => n.Content,
                new News { Content = "Swag ima tazi vecher"},
                new News { Content = "Shte e peem ili shte piem?"},
                new News { Content = "Aide na moreto"},
                new News { Content = "Ebati kefa?"},
                new News { Content = "Ne mi kazvai kakvo da pravq"},
                new News { Content = "Don't briiaang mee downnn"}
            );
        }
    }
}
