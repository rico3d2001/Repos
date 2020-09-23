using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models
{
    public class PipeLines
    {
        [DbColumn(IsIdentity = true, IsPrimary = true)]
        public long PnPID { get; set; }

        [DbColumn]
        public string Tag { get; set; }

        [DbColumn]
        public string Size { get; set; }

        [DbColumn]
        public string Spec { get; set; }

        [DbColumn]
        public string Tracing { get; set; }

        [DbColumn]
        public string InsulationType { get; set; }

        [DbColumn]
        public string Insulation { get; set; }

        [DbColumn]
        public string PaintCode { get; set; }

        [DbColumn]
        public string To { get; set; }

        [DbColumn]
        public string From { get; set; }

        [DbColumn]
        public string OperatingTemperature { get; set; }

        [DbColumn]
        public string OperatingPressure { get; set; }

        [DbColumn]
        public string DesignPressure { get; set; }

        [DbColumn]
        public string DesignTemperature { get; set; }

        [DbColumn]
        public string TestingFluid { get; set; }

        [DbColumn]
        public string TestPressure { get; set; }

        [DbColumn]
        public string PostWeldHeatTreatment { get; set; }

//[DbColumn]
        //public string Spec Part { get; set; }




        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"" VarChar(255) collate nocase,
        //"SpecPartGuid" VarChar(255) collate nocase,
        //Primary key("PnPID"))







    }
}
