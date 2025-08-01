﻿namespace NoteTakerAPI.Models;

public class Note : IEntityBase
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public required string Body { get; set; }
    public int NotebookId { get; set; }
    public Notebook Notebook { get; set; }
}
