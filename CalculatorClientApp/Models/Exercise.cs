using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorClientApp.Models
{
    public class Exercise
    {
        public int FirstVal { get; set; }
        public int SecondVal { get; set; }
        public char Op { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class ExerciseResult
    {
        public Exercise Exercise { get; set; }
        public bool Success { get; set; }
        public int Result { get; set; }
    }
}
