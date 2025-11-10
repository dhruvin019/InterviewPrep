using System.ComponentModel.DataAnnotations;

namespace practice1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100")]
        public int Age { get; set; }
        public string City { get; set; }

        public string Text { get; set; }
        public int Value { get; set; }

        public string Gender { get; set; }
        public string Hobby { get; set; }

    }
}
