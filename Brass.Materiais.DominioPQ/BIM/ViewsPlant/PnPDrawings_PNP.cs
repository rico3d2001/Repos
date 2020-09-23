using System.ComponentModel.DataAnnotations.Schema;

namespace Brass.Materiais.DominioPQ.BIM.ViewsPlant
{
    public class PnPDrawings_PNP
    {
        public long PnPID { get; set; }
        public string? PnPClassName { get; set; }
        public int? PnPStatus { get; set; }
        public int? PnPRevision { get; set; }
        public string? PnPGuid { get; set; }
        public int? PnPTimestamp { get; set; }


        public string? PnPDrawingGuid { get; set; }
        public string? PnPParentGuid { get; set; }
        public string? PnPType { get; set; }
        public string? PnPTimestampGuid { get; set; }
        public string? PnID { get; set; }

        [Column("Dwg Name")]
        public string? DwgName { get; set; }

        public string? Title { get; set; }
        public string? Path { get; set; }
        public string? PnPRelativePath { get; set; }
        public string? PnPUnc { get; set; }

        public int? PnPPromptForTemplate { get; set; }

        public string? PnPTemplateFile { get; set; }
        public string? PnPTemplateFileRelative { get; set; }
        public string? PnPTemplateFileUnc { get; set; }

        public int? PnPDwgOutOfSync { get; set; }

        public string? Revision { get; set; }
        public string? Area { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Area_Area { get; set; }
        public string? Area_SubArea { get; set; }

    }
}

