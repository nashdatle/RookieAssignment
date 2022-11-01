using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5._1.Models
{
    public class UpdateTaskModel
    {
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}