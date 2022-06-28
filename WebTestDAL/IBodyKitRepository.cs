using System;
using System.Collections.Generic;
using WebTestDAL.Entities;

namespace WebTestDAL
{
    public interface IBodyKitRepository
    {
        Guid Add(BodyKitDto kit);
        IEnumerable<BodyKitDto> GetAll();
        BodyKitDto GetById(Guid id);
        BodyKitDto GetBySeveralParams(Guid id, string rear); // Existing for instance
        bool Remove(Guid id);
        bool Update(BodyKitDto newKit);
        BodyKitDto UpdateRearBumper(Guid id, string newRearBumper);
    }
}