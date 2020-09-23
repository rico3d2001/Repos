using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.RepoComumPlantEF.Services
{
    public class TabelasPipeRecordRepositorio : IRecordRepositorio<PnPTables>
    {
        private readonly BIM360DataContext _context;

        //private readonly ILogger _logger;
        public TabelasPipeRecordRepositorio(BIM360DataContext context) //ILoggerFactory loggerFactory)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger(nameof(PipeRecordRepositorio));
        }

        public List<PnPTables> GetAll()
        {

            return _context.PnPTables.ToList();
        }

        public PnPTables Get(int pnPID)
        {
            return null;//_context.Valve_PNP.First(t => t.PnPID == pnPID);
        }

        public void Post(PnPTables valve)
        {
            _context.PnPTables.Add(valve);
            _context.SaveChanges();
        }

        public void Put(long id, PnPTables valve)
        {
            _context.PnPTables.Update(valve);
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
