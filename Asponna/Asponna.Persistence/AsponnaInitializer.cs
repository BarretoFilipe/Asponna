using Asponna.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Asponna.Persistence
{
    public class AsponnaInitializer
    {
        public static void Initialize(AsponnaContext context)
        {
            var initializer = new AsponnaInitializer();
            initializer.SeedDefaultAsponna(context);
        }

        private void SeedDefaultAsponna(AsponnaContext context)
        {
            if (context.TaskBoards.Any())
            {
                return;
            }

            SeedPriorities(context);
            SeedTaskBoards(context);
            SeedCards(context);
        }

        private void SeedPriorities(AsponnaContext context)
        {
            var priorities = new List<Priority>
            {
                new Priority("Low", "#D3D3D3"),
                new Priority("Medium", "#ADD8E6"),
                new Priority("High", "#FFA500"),
                new Priority("Critical", "#FF0000")
            };

            context.Priorities.AddRange(priorities);
            context.SaveChanges();
        }

        private void SeedTaskBoards(AsponnaContext context)
        {
            var taskBoards = new List<TaskBoard>
            {
                new TaskBoard("Backlog", 1),
                new TaskBoard("In Progress", 2),
                new TaskBoard("Done", 3)
            };

            context.TaskBoards.AddRange(taskBoards);
            context.SaveChanges();
        }

        private void SeedCards(AsponnaContext context)
        {
            var cards = new List<Card>
            {
                new Card("Title 1", "Description 1", 1, null),
                new Card("Title 2", "Description 2", 1, null),
                new Card("Title 3", "Description 3", 1, 1),
                new Card("Title 4", "Description 4", 2, 2),
                new Card("Title 5", "Description 5", 2, 3),
                new Card("Title 6", "Description 6", 3, 4)
            };

            context.Cards.AddRange(cards);
            context.SaveChanges();
        }
    }
}