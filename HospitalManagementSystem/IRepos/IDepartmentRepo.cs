using HospitalManagementSystem.IGenericRepos;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.IRepos
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        Department DoctorCount();

    }
}
