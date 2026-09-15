using StudentsDiApi.Models;

namespace StudentsDiApi.Services;

public class StudentService : IStudentService
{
    private readonly List<Student> students = new()
    {
        new Student { Id = 1, Name = "Alex", Group = "SE-301" },
        new Student { Id = 2, Name = "Anna", Group = "SE-302" },
        new Student { Id = 3, Name = "Max", Group = "SE-301" }
    };

    public IEnumerable<Student> GetAll()
    {
        return students;
    }

    public Student? GetById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }
}
