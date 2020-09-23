using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.RepoComumPlantEF.Services
{
    public class PipeLineRecordRepositorio : IRecordRepositorio<PipeLine>
    {
        private readonly BIM360DataContext _context;

        //private readonly ILogger _logger;
        public PipeLineRecordRepositorio(BIM360DataContext context) //ILoggerFactory loggerFactory)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger(nameof(PipeRecordRepositorio));
        }

        public List<PipeLine> GetAll()
        {

            return _context.PipeLines.ToList();
        }

        public PipeLine Get(int pnPID)
        {
            return _context.PipeLines.First(t => t.PnPID == pnPID);
        }

        public void Post(PipeLine pipe)
        {
            _context.PipeLines.Add(pipe);
            _context.SaveChanges();
        }

        public void Put(long id, PipeLine pipe)
        {
            _context.PipeLines.Update(pipe);
            _context.SaveChanges();
        }

        public void Delete(int pnPID)
        {
            var entity = _context.PipeLines.First(t => t.PnPID == pnPID);
            _context.PipeLines.Remove(entity);
            _context.SaveChanges();
        }
    }
}
