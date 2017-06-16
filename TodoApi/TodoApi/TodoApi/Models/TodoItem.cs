using System.Globalization;
namespace TodoApi.Models
{
    public class TodoItem
    {
        public bool IsComplete { get; set; }
        public long id { get; set; }
        public string Nama { get; set; }
        public string TglOrderdItenoss { get; set; }
        public string KomentarTeknisi { get; set; }
        public int AreaCode { get; set; }
        public string Metro { get; set; }
        public string TglPerintahSurvei { get; set; }
        public string Tagging { get; set; }
        public string TeknisiSurvei { get; set; }
        public string TaggingOp { get; set; }
        public string TglPerintahPT1 { get; set; }
        public string TglSelesai { get; set; }
        public string TeknisiPT1 { get; set; }
        public string TglPerintahJT { get; set; }
        public string TglJTSelesai { get; set; }
        public string Komentar { get; set; }
        public string TglCloser { get; set; }
        public string Status { get; set; }
        public string sid { get; set; }
        public string tq { get; set; }
        public string ao { get; set; }
        public string Alamat { get; set; }
        public string Gpon { get; set; }
        public string sn { get; set; }
        public string vlan { get; set; }
        public byte[] pic { get; set; }

        
    }
}