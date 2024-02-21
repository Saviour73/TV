using TVApi.DataLayer;
using TVApi.Model;
using TVApi.Repository;

namespace TVApi.TVRepository
{
    public class TVRepository : IRepository<TV> 
    {
        // TVRepository.cs
        
            private readonly TVDbContext _dbContext;

            public TVRepository(TVDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IEnumerable<TV> GetAll()
            {
                return _dbContext.TVs.ToList();
            }

            public TV GetById(int id)
            {
                return _dbContext.TVs.Find(id);
            }

            public void Add(TV entity)
            {
                _dbContext.TVs.Add(entity);
                _dbContext.SaveChanges();
            }

            public void Update(TV entity)
            {
                _dbContext.TVs.Update(entity);
                _dbContext.SaveChanges();
            }

            public void Delete(TV entity)
            {
                _dbContext.TVs.Remove(entity);
                _dbContext.SaveChanges();
            }
       

    }
}
