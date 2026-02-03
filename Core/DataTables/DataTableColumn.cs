using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GuayabitosMvc.Core.DataTables
{
    public class DataTableColumn
    {
        public string Title { get; set; }
        public string Data { get; set; }
        public bool Visible { get; set; } = true;
        public bool Orderable { get; set; } = true;
        public bool Searchable { get; set; } = true;
        public string Width { get; set; }
        public string ClassName { get; set; }
        public string Render { get; set; }
    }
}