using StudentsDiApi.Models;

namespace StudentsDiApi.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAll();

    Student? GetById(int id);
}
