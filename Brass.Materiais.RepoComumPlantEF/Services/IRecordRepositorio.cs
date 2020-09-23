using System.Collections.Generic;

namespace Brass.Materiais.RepoComumPlantEF.Services
{
    public interface IRecordRepositorio<T>
    {
        void Delete(int PnPID);
        T Get(int PnPID);
        List<T> GetAll();
        void Post(T pipeRecord);
        void Put(long id, T pipeRecord);
    }
}
