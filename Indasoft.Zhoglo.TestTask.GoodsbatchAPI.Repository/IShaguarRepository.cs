using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;

namespace Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository
{
    public interface IShaguarRepository
    {
        public IEnumerable<GoodsBatch> GetGoodsBatches();

        public GoodsBatch? GetGoodsBatch(long id);

        public long Add(GoodsBatch batch);

        public void Update(long id, GoodsBatch batch);

        public void Delete(long id);

        public IEnumerable<Goods> GetGoods();

        public IEnumerable<GoodsBatchStates> GetGoodsBatchStates();

        public IEnumerable<MeasureUnits> GetMeasureUnits();

        public IEnumerable<StorePlace> GetStorePlaces();

        public void Patch(long id, PatchGoodsBatch patchGoodsBatch);
    }
}
