﻿namespace DMD.Domain.Models
{
    public class Song : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Length { get; set; }
    }
}