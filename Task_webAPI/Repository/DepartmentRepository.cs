using Microsoft.EntityFrameworkCore;
using Task_webAPI.Dto;
using Task_webAPI.Models;

namespace Task_webAPI.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly DbContextAPI db;

        public DepartmentRepository(DbContextAPI db)
        {
            this.db = db;
        }
        public List<Department> getall()
        {
            return db.Departments.Include(n => n.Employees).ToList();
        }
        public Department getbyid(int id)
        {
            return db.Departments.FirstOrDefault(n => n.ID == id);
        }
       
        public void insert(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }
        public void update(int id, Department dept)
        {
            Department old = db.Departments.FirstOrDefault(n => n.ID == id);
            if (old != null)
            {
                old.Name = dept.Name;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("not found");
            }
        }
        public void delete(int id)
        {

            Department old = db.Departments.FirstOrDefault(n => n.ID == id);
            if (old != null)
            {
                db.Departments.Remove(old);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("not found");
            }

        }

        public Departmentlist departlist(int id)
        {
            Department depart = db.Departments.Include(n => n.Employees).FirstOrDefault(x => x.ID == id);
            Departmentlist depatlist = new Departmentlist();
            depatlist.Id = depart.ID;
            depatlist.Name = depart.Name;
            foreach (var item in depart.Employees)
            {
                depatlist.emps.Add(new emp { Id = item.ID, Name = item.Name });
            }
            return  depatlist;
        }

      
    }
}
