using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Models;

public class Student
{
    // Ідентифікатор студента
    public int Id { get; set; }

    // Ім'я студента
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public string? Name { get; set; }

    // Прізвище студента
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public string? Surname { get; set; }

    // Вік студента
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [Range(15, 60, ErrorMessage = "Неприпустимий вік")]
    public int Age { get; set; }

    // Середній бал
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [Range(0.0, 12.0, ErrorMessage = "Неприпустимий середній бал")]
    public double GPA { get; set; }
}