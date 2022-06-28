using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTestDAL.Entities;

namespace WebTestDAL
{
    public class BodyKitRepository : IBodyKitRepository
    {
        private readonly EFCoreContext _dbcontext;

        public BodyKitRepository(EFCoreContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public Guid Add(BodyKitDto kit)
        {
            kit.Id = Guid.NewGuid();

            _dbcontext.BodyKits.Add(kit);

            _dbcontext.SaveChanges();

            return kit.Id;
        }

        public IEnumerable<BodyKitDto> GetAll()
        {
            return _dbcontext.BodyKits.ToList();
        }

        public BodyKitDto GetById(Guid id)
        {
            return _dbcontext.BodyKits.Where(x => x.Id == id).FirstOrDefault();
        }

        public BodyKitDto GetBySeveralParams(Guid id, string rear) // Existing for instance
        {
            return _dbcontext.BodyKits.Where(x => x.Id == id && x.RearBumper == rear).FirstOrDefault();
        }

        public bool Remove(Guid id)
        {
            var dbKit = GetById(id);

            if(dbKit != null)
            {
                _dbcontext.Remove(dbKit);

                _dbcontext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Update(BodyKitDto newKit)
        {
            _dbcontext.BodyKits.Update(newKit);

            var result = _dbcontext.SaveChanges();

            return result != 0;
        }

        public BodyKitDto UpdateRearBumper(Guid id, string newRearBumper)
        {
            var dbKit = GetById(id);

            dbKit.RearBumper = newRearBumper;

            _dbcontext.BodyKits.Update(dbKit);

            _dbcontext.SaveChanges();

            return dbKit;
        }
    }
}
