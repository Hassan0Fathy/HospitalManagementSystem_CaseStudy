using HospitalManagementSystem.AppContext;
using HospitalManagementSystem.GenericRepos;
using HospitalManagementSystem.IGenericRepos;
using HospitalManagementSystem.IRepos;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repos
{
    public class DepartmentRepo : GenericRepo<DepartmentRepo>, IDepartmentRepo
    {
       
        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Department> DoctorCount()
        {
            return _context.Departments
                           .Select(d => new Department
                           {
                               DepartmentName = d.DepartmentName,
                               DoctorCount = d.Doctors.Count
                           })
                           .ToList();
        }

       
    }
}
