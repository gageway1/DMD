﻿namespace DMD.Data.Models
{
    public class DbBandMember : DbModelBase
    {
        public string Instrument { get; set; } = string.Empty;
        public Guid DbBandId { get; set; }
    }
}