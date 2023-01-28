using Task_webAPI.Dto;
using Task_webAPI.Models;

namespace Task_webAPI.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> getall();

        Department getbyid(int id);

        void insert(Department dept);

        void update(int id, Department dept);

        void delete(int id);
        Departmentlist departlist(int id);
    }
}
