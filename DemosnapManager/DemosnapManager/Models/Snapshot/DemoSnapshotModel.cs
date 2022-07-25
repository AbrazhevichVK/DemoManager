using System;

namespace DemosnapManager.Models.Snapshot
{
    public class DemoSnapshotModel
    {
        public int Id { get; set; }
        public string Satellite { get; set; }
        public DateTime ShootingDate { get; set; }
        public decimal Cloudiness { get; set; }
        public int Coil { get; set; }
        public string Coordinates { get; set; }
    }
}
