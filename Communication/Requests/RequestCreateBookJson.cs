﻿namespace LibraryAPI.Communication.Requests;

public class RequestCreateBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }
}
