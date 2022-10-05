using System.ComponentModel.DataAnnotations;

namespace DotNetTraining_Assignments4.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
