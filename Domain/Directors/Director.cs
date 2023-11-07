﻿using Domain.Enums;

namespace Domain.Directors;

public class Director
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
}
