using Microsoft.EntityFrameworkCore;
using Task_webAPI.Dto;
using Task_webAPI.Models;

namespace Task_webAPI.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DbContextAPI db;

        public EmployeeRepository(DbContextAPI db)
        {
            this.db = db;
        }
        public List<EmployeeWithDepartmentNameDto> getall()
        {
            List <Employee> employees= db.Employees.Include(n => n.Department).ToList();
            List<EmployeeWithDepartmentNameDto> empDto = new List<EmployeeWithDepartmentNameDto>();
            foreach (var item in employees)
            {
                empDto.Add(new EmployeeWithDepartmentNameDto { EmpId = item.ID, EmployeeName = item.Name ,EmpSalary=item.Salary,DepartmentName=item.Department.Name});
            }
            return empDto;
        }
        public EmployeeWithDepartmentNameDto getallWithDeptName(int id)
        {
            Employee employee = db.Employees.Include(n => n.Department).FirstOrDefault(n=>n.ID==id);
            EmployeeWithDepartmentNameDto empDto = new EmployeeWithDepartmentNameDto();
            empDto.EmpId = employee.ID;
            empDto.EmployeeName = employee.Name;
            empDto.EmpSalary   = employee.Salary;
            empDto.DepartmentName = employee.Department.Name;
            return empDto;
        }
        public Employee getbyid(int id)
        {
            return db.Employees.FirstOrDefault(n => n.ID == id);
        }
       
        public void insert(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }
        public void update(int id, Employee emp)
        {
            Employee old = db.Employees.FirstOrDefault(n => n.ID == id);
            if (old != null)
            {
                old.Name = emp.Name;
                old.Salary =emp.Salary;
                old.Address = emp.Address;
                old.Dept_ID = emp.Dept_ID;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("not found");
            }
        }
        public void delete(int id)
        {

            Employee old = db.Employees.FirstOrDefault(n => n.ID == id);
            if (old != null)
            {
                db.Employees.Remove(old);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("not found");
            }

        }

      
    }
}
