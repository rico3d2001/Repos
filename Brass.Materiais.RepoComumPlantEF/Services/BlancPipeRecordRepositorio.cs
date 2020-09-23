using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.RepoComumPlantEF.Services
{
    public class BlancPipeRecordRepositorio:IRecordRepositorio<BlancPipe>
    {
        private readonly BIM360DataContext _context;

        //private readonly ILogger _logger;
        public BlancPipeRecordRepositorio(BIM360DataContext context) //ILoggerFactory loggerFactory)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger(nameof(PipeRecordRepositorio));
        }

        public List<BlancPipe> GetAll()
        {

            return _context.BlancPipe.ToList();
        }

        public BlancPipe Get(int pnPID)
        {
            return _context.BlancPipe.First(t => t.PnPID == pnPID);
        }

        public void Post(BlancPipe pipe)
        {
            _context.BlancPipe.Add(pipe);
            _context.SaveChanges();
        }

        public void Put(long id, BlancPipe pipe)
        {
            _context.BlancPipe.Update(pipe);
            _context.SaveChanges();
        }

        public void Delete(int pnPID)
        {
            var entity = _context.BlancPipe.First(t => t.PnPID == pnPID);
            _context.BlancPipe.Remove(entity);
            _context.SaveChanges();
        }
    }
}
