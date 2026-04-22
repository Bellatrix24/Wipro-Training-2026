using System;

namespace Day06Practice
{
    // A delegate representing the method signature for a news update
    public delegate void NewsHandler(string topic, string message);

    // --- PUBLISHER ---
    class NewsAgency
    {
        // The event that subscribers will listen to
        public event NewsHandler OnNewsPublished;

        public void Publish(string topic, string msg)
        {
            Console.WriteLine($"\n[Agency]: Publishing news on {topic}...");
            
            // If there are any subscribers, notify them
            if (OnNewsPublished != null)
            {
                OnNewsPublished(topic, msg);
            }
        }
    }

    // --- SUBSCRIBER ---
    class Reader
    {
        public string Name { get; set; }

        public Reader(string name) { Name = name; }

        // This method matches the delegate signature
        public void SubscribeToNews(string topic, string msg)
        {
            Console.WriteLine($"   -> {Name} received update [{topic}]: {msg}");
        }
    }

    class PublisherSubscriberDemo
    {
        static void Main(string[] args)
        {
            NewsAgency agency = new NewsAgency();

            Reader student1 = new Reader("Amit");
            Reader student2 = new Reader("Sita");

            // Subscribing: Connecting the Readers to the Agency
            agency.OnNewsPublished += student1.SubscribeToNews;
            agency.OnNewsPublished += student2.SubscribeToNews;

            // Publisher sends out a message
            agency.Publish("Politics", "New election dates announced.");
            agency.Publish("Sports", "Local team wins big!");

            Console.WriteLine("\nNote: The Agency (Publisher) doesn't know who the Readers are directly.");
        }
    }
}
