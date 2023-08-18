namespace DurakListeApp.Models
{
    public class DurakViewModel
    {
        public int objectid { get; set; }

        public string id { get; set; }

        public NetTopologySuite.Geometries.Geometry geometry { get; set; }

        public string durak_no { get; set; }

        public string durak_adi { get; set; }

        public string durak_tip { get; set; }

        public string durak_yon { get; set; }

        public string durak_adres { get; set; }

        public string durak_kullanim { get; set; }

        public string bisiklet_tramvay { get; set; }

        public string guncel_tarih_saat { get; set; }
    }
}