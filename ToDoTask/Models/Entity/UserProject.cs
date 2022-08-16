﻿using System.Text.Json.Serialization;
using AspBackend.Models.Entity;

namespace AspBackend.Models.Entity;

public class UserProject
{
    [JsonIgnore]
    public int UserId { get; set; }

    public User User { get; set; }

    [JsonIgnore]
    public int ProjectId { get; set; }

    public Project Project { get; set; }
}
