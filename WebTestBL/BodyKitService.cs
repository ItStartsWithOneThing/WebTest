using AutoMapper;
using System;
using System.Collections.Generic;
using WebTest.Models;
using WebTestDAL;
using WebTestDAL.Entities;

namespace WebTestBL
{
    public class BodyKitService
    {
        private BodyKitRepository _repository;
        private IMapper _mapper;

        public BodyKitService(IMapper mapper, BodyKitRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Guid AddKit(BodyKit kit)
        {
            if(kit != null)
            {
                var dbBodyKit = _mapper.Map<BodyKitDto>(kit);

                var id = _repository.Add(dbBodyKit);

                return id;
            }

            return Guid.Empty;
        }

        public IEnumerable<BodyKit> GetAll()
        {
            var dbBodyKits = _repository.GetAll();

            var result = _mapper.Map<IEnumerable<BodyKit>>(dbBodyKits);

            return result;
        }

        public BodyKit GetByID(Guid id)
        {
            var dbBodyKit = _repository.GetById(id);

            var result = _mapper.Map<BodyKit>(dbBodyKit);

            return result;
        }

        public BodyKit GetBySeveralParams(string front, string rear)
        {
            var dbBodyKit = _repository.GetBySeveralParams(front, rear);

            var result = _mapper.Map<BodyKit>(dbBodyKit);

            return result;
        }

        public BodyKit GetByQuerryString(string front, string rear)
        {
            var dbBodyKit = _repository.GetBySeveralParams(front, rear);

            var result = _mapper.Map<BodyKit>(dbBodyKit);

            return result;
        }

        public bool RemoveKit(Guid id)
        {
            return _repository.Remove(id);
        }

        public bool UpdateKit(BodyKit kit)
        {
            var dbKit = _mapper.Map<BodyKitDto>(kit);

            return _repository.Update(dbKit);
        }

        public BodyKit UpdateRearBumper(Guid id, string newRearBumper)
        {
            var dbBodykit = _repository.UpdateRearBumper(id, newRearBumper);

            var result = _mapper.Map<BodyKit>(dbBodykit);

            return result;
        }
    }
}
