using IServices;

namespace EmployeeService
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        Employee Get(int id);
    }
}
