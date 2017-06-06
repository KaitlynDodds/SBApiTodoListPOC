namespace SBApiTodoListPOC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SBApiTodoListPOC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SBApiTodoListPOC.Models.SBApiTodoListPOCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SBApiTodoListPOC.Models.SBApiTodoListPOCContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Projects.AddOrUpdate(p => p.Id,
                    new Project() {  Id = 1, Name = "Azure App Migration"},
                    new Project() { Id = 2, Name = "Build Front Deck" },
                    new Project() { Id = 3, Name = "Household Chores" },
                    new Project() { Id = 4, Name = "Personal Website" }
                );

            context.ProjectTasks.AddOrUpdate(t => t.Id,
                    new ProjectTask() { Id = 1, Description = "Sand wood for deck",  IsCompleted = false, ProjectId = 2 },
                    new ProjectTask() { Id = 2, Description = "Vaccum Living Room",  IsCompleted = true, ProjectId = 3 },
                    new ProjectTask() { Id = 3, Description = "Buy Nails",  IsCompleted = false, ProjectId = 2 },
                    new ProjectTask() { Id = 4, Description = "Refactor Html",  IsCompleted = false, ProjectId = 4 },
                    new ProjectTask() { Id = 5, Description = "Clean Bathroom",  IsCompleted = false, ProjectId = 3 },
                    new ProjectTask() { Id = 5, Description = "Upload resume",  IsCompleted = true, ProjectId = 4 },
                    new ProjectTask() { Id = 5, Description = "Cook dinner",  IsCompleted = false, ProjectId = 3 }
                );
        }
    }
}
