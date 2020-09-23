using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.RepoComumPlantEF.Services
{
    public class UnidadePipeRecordRepositorio: IRecordRepositorio<UnidadePipe>
    {
        private readonly BIM360DataContext _context;

        //private readonly ILogger _logger;
        public UnidadePipeRecordRepositorio(BIM360DataContext context) //ILoggerFactory loggerFactory)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger(nameof(PipeRecordRepositorio));
        }

        public List<UnidadePipe> GetAll()
        {

            return _context.UnidadePipe.ToList();
        }

        public UnidadePipe Get(int pnPID)
        {
            return null;//_context.Valve_PNP.First(t => t.PnPID == pnPID);
        }

        public void Post(UnidadePipe valve)
        {
            _context.UnidadePipe.Add(valve);
            _context.SaveChanges();
        }

        public void Put(long id, UnidadePipe valve)
        {
            _context.UnidadePipe.Update(valve);
            _context.SaveChanges();
        }

        public void Delete(int pnPID)
        {
            //var entity = _context.Valve_PNP.First(t => t.PnPID == pnPID);
            //_context.Valve_PNP.Remove(entity);
            _context.SaveChanges();
        }
    }
}
