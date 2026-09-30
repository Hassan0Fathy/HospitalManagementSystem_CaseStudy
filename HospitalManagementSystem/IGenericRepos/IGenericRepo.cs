namespace HospitalManagementSystem.IGenericRepos
{
    public interface IGenericRepo <T> where T : class
    {
        ICollection<T> GetAll();
        T GetbyId(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
