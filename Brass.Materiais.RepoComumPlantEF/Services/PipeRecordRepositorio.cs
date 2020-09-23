using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.RepoComumPlantEF.Services
{
    public class PipeRecordRepositorio : IRecordRepositorio<Pipe>
    {
        private readonly BIM360DataContext _context;

        //private readonly ILogger _logger;
        public PipeRecordRepositorio(BIM360DataContext context) //ILoggerFactory loggerFactory)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger(nameof(PipeRecordRepositorio));
        }

        public List<Pipe> GetAll()
        {
            
            return _context.Pipe.ToList();
        }

        public Pipe Get(int pnPID)
        {
            return _context.Pipe.First(t => t.PnPID == pnPID);
        }

        public void Post(Pipe pipe)
        {
            _context.Pipe.Add(pipe);
            _context.SaveChanges();
        }

        public void Put(long id, Pipe pipe)
        {
            _context.Pipe.Update(pipe);
            _context.SaveChanges();
        }

        public void Delete(int pnPID)
        {
            var entity = _context.Pipe.First(t => t.PnPID == pnPID);
            _context.Pipe.Remove(entity);
            _context.SaveChanges();
        }

    }
}
