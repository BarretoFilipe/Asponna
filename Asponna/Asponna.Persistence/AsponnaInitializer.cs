using Asponna.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Asponna.Persistence
{
    public class AsponnaInitializer
    {
        private readonly Dictionary<int, TaskBoard> TaskBoards = new Dictionary<int, TaskBoard>();
        private readonly Dictionary<int, Card> Cards = new Dictionary<int, Card>();

        public static void Initialize(AsponnaContext context)
        {
            var initializer = new AsponnaInitializer();
            initializer.SeedDefaultAsponna(context);
        }

        private void SeedDefaultAsponna(AsponnaContext context)
        {
            context.Database.EnsureCreated();

            if (context.TaskBoards.Any())
            {
                return;
            }

            SeedTaskBoards(context);
            SeedCards(context);
        }

        private void SeedTaskBoards(AsponnaContext context)
        {
            var taskBoards = new[]
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
            var cards = new[]
            {
                new Card("Title 1", "Description 1", 1, 1),
                new Card("Title 2", "Description 2", 2, 1),
                new Card("Title 3", "Description 3", 3, 1),
                new Card("Title 4", "Description 4", 4, 2),
                new Card("Title 5", "Description 5", 5, 2),
                new Card("Title 6", "Description 6", 6, 3)
            };

            context.Cards.AddRange(cards);

            context.SaveChanges();
        }
    }
}