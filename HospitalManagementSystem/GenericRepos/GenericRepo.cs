using HospitalManagementSystem.AppContext;
using HospitalManagementSystem.IGenericRepos;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.GenericRepos
{
    public class GenericRepo <T> : IGenericRepo<T> where T : class

    {
        private readonly AppDbContext _context;
        public DbSet<T> db;


        public GenericRepo(AppDbContext context)
        {
            _context = context;
            db = _context.Set<T>();
        }
        public void Add(T entity)
        {
            db.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(db.Find(id));
            _context.SaveChanges();
        }

        public ICollection<T> GetAll()
        {
            return db.ToList();
        }

        public T GetbyId(int id)
        {
            return db.Find(id);
        }

        public void Update(T entity)
        {
            db.Update(entity);
            _context.SaveChanges();

        }
    }
}
