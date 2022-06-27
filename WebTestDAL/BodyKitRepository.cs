using System;
using System.Collections.Generic;
using System.Linq;
using WebTestDAL.Entities;

namespace WebTestDAL
{
    public class BodyKitRepository
    {
        private static List<BodyKitDto> _bodies;

        static BodyKitRepository()
        {
            _bodies = new List<BodyKitDto>();
        }

        public Guid Add(BodyKitDto kit)
        {
            kit.Id = Guid.NewGuid();

            _bodies.Add(kit);

            return kit.Id;
        }

        public IEnumerable<BodyKitDto> GetAll()
        {
            return _bodies;    
        }

        public BodyKitDto GetById(Guid id)
        {
            return _bodies.FirstOrDefault(x => x.Id == id);
        }

        public BodyKitDto GetBySeveralParams(string front, string rear)
        {
            var dbBodyKit = _bodies.FirstOrDefault(x => x.FrontBumper == front && x.RearBumper == rear);

            return dbBodyKit;
        }

        public bool Remove(Guid id)
        {
            var target = _bodies.FirstOrDefault(x => x.Id == id);

            if(target != null)
            {
                _bodies.Remove(target);

                return true;
            }

            return false;
        }

        public bool Update(BodyKitDto newKit)
        {
            var dbKit = GetById(newKit.Id);

            if(dbKit != null)
            {
                var index = _bodies.IndexOf(dbKit);

                _bodies[index] = newKit;
            }

            return dbKit != null;
        }

        public BodyKitDto UpdateRearBumper(Guid id, string newRearBumper)
        {
            var result = _bodies.FirstOrDefault(x => x.Id == id);

            if(result != null)
            {
                result.RearBumper = newRearBumper;

                return result;
            }    

            return null;
        }
    }
}
