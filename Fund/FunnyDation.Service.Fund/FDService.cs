using FunnyDation.Common.Service;
using FunnyDation.Data;
using FunnyDation.IService.Fund;
using FunnyDation.Repository.Fund;
using System;
using System.Collections.Generic;

namespace FunnyDation.Service.Fund
{
    public class FDService : FDEntityServiceBase<FD_Entity, FDEntityRepository>, IFDEntityService
    {
        public FD_Entity Add(FD_Entity entity)
        {
            throw new NotImplementedException();
        }

        public List<FD_Entity> Adds(List<FD_Entity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(FD_Entity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByID(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIDList(List<long> idList)
        {
            throw new NotImplementedException();
        }

        public void Deletes(List<FD_Entity> entities)
        {
            throw new NotImplementedException();
        }

        public FD_Entity GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Dictionary<string, string> condition)
        {
            throw new NotImplementedException();
        }

        public List<FD_Entity> GetList(Dictionary<string, string> condition)
        {
            throw new NotImplementedException();
        }

        public FD_Entity GetNew()
        {
            throw new NotImplementedException();
        }

        public RPagerInfo<FD_Entity> GetRecords(Dictionary<string, string> condition)
        {
            throw new NotImplementedException();
        }

        public FD_Entity Update(FD_Entity entity)
        {
            throw new NotImplementedException();
        }

        public List<FD_Entity> Updates(List<FD_Entity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
