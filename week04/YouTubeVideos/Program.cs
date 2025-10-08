using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create 3–4 videos
        var v1 = new Video { _title = "Intro to OOP", _author = "TechWithAna", _lengthSeconds = 540 };
        var v2 = new Video { _title = "Healthy Meal Prep", _author = "ChefLuis", _lengthSeconds = 780 };
        var v3 = new Video { _title = "Travel in Japan", _author = "MinaTravels", _lengthSeconds = 915 };

        // Add 3–4 comments per video
        v1.AddComment(new Comment("Carlos", "Great explanation!"));
        v1.AddComment(new Comment("Julia", "Clear and concise."));
        v1.AddComment(new Comment("Sam", "Please do inheritance next."));

        v2.AddComment(new Comment("Paty", "Loved the tips!"));
        v2.AddComment(new Comment("Rafa", "Where is the recipe PDF?"));
        v2.AddComment(new Comment("Mon", "Tried it—delicious!"));

        v3.AddComment(new Comment("Akira", "Arigato!"));
        v3.AddComment(new Comment("Lia", "Add Kyoto spots please."));
        v3.AddComment(new Comment("Timo", "The train montage was awesome."));
        v3.AddComment(new Comment("Elena", "Saved for my trip."));

        // Put videos in a list
        var videos = new List<Video> { v1, v2, v3 };

        // Iterate and display each video with comments
        foreach (var video in videos)
        {
            video.Display();
        }
    }
}
