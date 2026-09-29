
using System.ComponentModel.DataAnnotations;
// this namespace is used for data validation attributes like [Required], [StringLength], etc.


namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public DateOnly EnrollmentDate { get; set; }

        public string Course { get; set; }

        public int Semester { get; set; }

    }
}
