using System; 
using System.Collections.Generic; 

class Subscriber
{
    public string Name;
    public Subscriber(string name) { Name = name; }
    
    public void Notify(string video)
    { 
        Console.WriteLine(Name + " got: " + video); 
    }
}

class Channel
{
    // The List stores all our observers (subscribers)
    private List<Subscriber> subs = new List<Subscriber>(); 
    
    public void Subscribe(Subscriber sub) 
    { 
        subs.Add(sub); 
    }
    
    public void UploadVideo(string video)
    {
        // This loops through everyone and sends the update
        foreach (var sub in subs)
            sub.Notify(video);
    }
}

// This is the "Entry Point" that makes the code actually run
class Program
{
    static void Main()
    {
        Channel myChannel = new Channel();
        
        // Creating subscribers
        Subscriber user1 = new Subscriber("Amit");
        Subscriber user2 = new Subscriber("Priya");
        
        // Registering them to the channel
        myChannel.Subscribe(user1);
        myChannel.Subscribe(user2);
        
        // This triggers the notification logic
        myChannel.UploadVideo("Design Patterns Tutorial");
    }
}
