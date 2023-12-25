public class Link
{
    public int? Id { get; set; }
    public string URL { get; set; }

    // Parameterless constructor for Entity Framework Core
    public Link()
    {
    }

    public Link(string link)
    {
        URL = link;
    }
}