#nullable enable
using System;

namespace FruitApi.Models.Helpers
{
    public interface ILogModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}