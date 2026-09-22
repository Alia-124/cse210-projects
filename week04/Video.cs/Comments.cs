public class Comments
{
    public string Text { get; set; } 
    public string Author { get; set; } 
    
    public Comments(string text, string author)
    {
        Text = text;
        Author = author;
    }
}
