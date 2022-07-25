using System.Collections.Generic;

namespace DemosnapManager.Models.Snapshot
{
    public interface IDemoSnapshotRepository
    {
        void Create(DemoSnapshotModel model);
        void Delete(int id);
        DemoSnapshotModel Get(int id);
        List<DemoSnapshotModel> GetDemoSnapshotModels();
        void Update(DemoSnapshotModel model);
    }
}
