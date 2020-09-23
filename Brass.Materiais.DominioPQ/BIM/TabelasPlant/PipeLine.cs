using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Brass.Materiais.DominioPQ.BIM.TabelasPlant
{
    public class PipeLine
    {
        public long PnPID { get; set; }
        public string? Tag { get; set; }
        public string? Size { get; set; }
        public string? Spec { get; set; }
        public string? Tracing { get; set; }
        public string? InsulationType { get; set; }
        public string? Insulation { get; set; }
        public string? PaintCode { get; set; }
        public string? To { get; set; }
        public string? From { get; set; }
        public string? OperatingTemperature { get; set; }
        public string? OperatingPressure { get; set; }
        public string? DesignPressure { get; set; }
        public string? DesignTemperature { get; set; }
        public string? TestingFluid { get; set; }
        public string? TestPressure { get; set; }
        public string? PostWeldHeatTreatment { get; set; }

        [Column("Spec Part")]
        public string? SpecPart { get; set; }
        public string? SpecPartGuid { get; set; }


        //"Spec Part" VarChar (255) collate nocase,
        //"SpecPartGuid" VarChar (255) collate nocase,
    }
}


//CREATE TABLE "PipeLines"(
//"PnPID" integer,
//"Tag" VarChar (255) collate nocase,
//"Size" VarChar (255) collate nocase,
//"Spec" VarChar (255) collate nocase,
//"Tracing" VarChar (255) collate nocase,
//"InsulationType" VarChar (255) collate nocase,
//"Insulation" VarChar (255) collate nocase,
//"PaintCode" VarChar (255) collate nocase,
//"To" VarChar (255) collate nocase,
//"From" VarChar (255) collate nocase,
//"OperatingTemperature" VarChar (255) collate nocase,
//"OperatingPressure" VarChar (255) collate nocase,
//"DesignPressure" VarChar (255) collate nocase,
//"DesignTemperature" VarChar (255) collate nocase,
//"TestingFluid" VarChar (255) collate nocase,
//"TestPressure" VarChar (255) collate nocase,
//"PostWeldHeatTreatment" VarChar (255) collate nocase,
//"Spec Part" VarChar (255) collate nocase,
//"SpecPartGuid" VarChar (255) collate nocase,
//Primary key ("PnPID"))