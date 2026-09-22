using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Comment
    {
        public string Author { get; }
        public string Text { get; }

        public Comment(string author, string text)
        {
            Author = author;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int Length { get; }

        private readonly List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video(
                "Amazing White Water Rafting Adventure",
                "Adventure Channel",
                420
            );

            video1.AddComment(new Comment("John", "that looked like an amazing adventure1"));
            video1.AddComment(new Comment("Sarah", "I would love to try White water rafting."));
            video1.AddComment(new Comment("Mike", "The scenery was incredible!"));
            video1.AddComment(new Comment("Emily", "Great video!"));

            Video video2 = new Video(
                "How to cook the perfect steak",
                "food Master",
                315
            );

            video2.AddComment(new Comment("Alice", "This recipe looks great!"));
            video2.AddComment(new Comment("Bob", "I'll definitely try this at home."));
            video2.AddComment(new Comment("Alice", "This recipe looks great!"));
            video2.AddComment(new Comment("Tom", "Great cooking tips!"));
            video2.AddComment(new Comment("Anna", "I learn something new today."));

            Video video3 = new Video(
                "Top 10 Travel Destinations for 2024",
                "Travel Guru",
                600
            );

            video3.AddComment(new Comment("Daniel", "This was very helpful!"));
            video3.AddComment(new Comment("Jessica", "Japan looks amazing!"));
            video3.AddComment(new Comment("Robert", "Thanks for the recommendation."));
            video3.AddComment(new Comment("Amanda", "Adding these places to my travel list."));

            Video video4 = new Video(
                "Beginner Guitar Lesson",
                "Music academy",
                480
            );

            video4.AddComment(new Comment("Daniel", "This was very helpful."));
            video4.AddComment(new Comment("Sophie", "I finally learned the chords!"));
            video4.AddComment(new Comment("James", "Please make more lessons."));
            video4.AddComment(new Comment("Olivia", "Great lesson for beginners."));

            List<Video> videos = new List<Video>
            {
                video1,
                video2,
                video3,
                video4
            };

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Comments: {video.GetComments().Count}");
                List<Comment> comments = video.GetComments();
                foreach (Comment comment in comments)
                {
                    Console.WriteLine($"- {comment.Text} (by {comment.Author})");
                }
                Console.WriteLine();
            }
        }
    }
}
