using System;
using System.Collections.Generic;
using MiddlewareRazorPagesApp.Models;

namespace MiddlewareRazorPagesApp.Services
{
    /// <summary>
    /// Static in-memory item repository representing persistent store for beginner training.
    /// </summary>
    public class ItemStore
    {
        private static readonly List<Item> _items = new List<Item>();
        private static int _nextId = 1;
        private static readonly object _lock = new object();

        static ItemStore()
        {
            // Seed the store with initial sample items as requested
            _items.Add(new Item { Id = _nextId++, Name = "Sample Item 1", Description = "This is the first seeded sample item." });
            _items.Add(new Item { Id = _nextId++, Name = "Sample Item 2", Description = "This is the second seeded sample item." });
            _items.Add(new Item { Id = _nextId++, Name = "Sample Item 3", Description = "This is the third seeded sample item." });
        }

        /// <summary>
        /// Retrieves all items in the store.
        /// </summary>
        public IEnumerable<Item> GetAll()
        {
            lock (_lock)
            {
                // Return a copy of the list to prevent external modification
                return new List<Item>(_items);
            }
        }

        /// <summary>
        /// Adds a new item to the static store thread-safely.
        /// </summary>
        public void Add(string name, string description)
        {
            lock (_lock)
            {
                var newItem = new Item
                {
                    Id = _nextId++,
                    Name = name,
                    Description = description
                };
                _items.Add(newItem);
            }
        }
    }
}
