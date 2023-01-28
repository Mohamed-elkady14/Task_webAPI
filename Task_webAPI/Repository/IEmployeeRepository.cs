using Task_webAPI.Dto;
using Task_webAPI.Models;

namespace Task_webAPI.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeWithDepartmentNameDto> getall();
        EmployeeWithDepartmentNameDto getallWithDeptName(int id);
        Employee getbyid(int id);

        void insert(Employee emp);

        void update(int id, Employee emp);

        void delete(int id);
    }
}
