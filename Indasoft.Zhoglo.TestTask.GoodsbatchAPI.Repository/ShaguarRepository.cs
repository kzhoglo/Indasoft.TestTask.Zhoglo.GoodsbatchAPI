using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository
{
    public class ShaguarRepository : IShaguarRepository
    {
        private readonly shaguarContext context;
        private readonly DbSet<tbl_goodsbatches> goodsbatchesEntity;
        private readonly DbSet<tbl_goods> goodsEntity;
        private readonly DbSet<tbl_goodsbatchstates> goodsBatchStatesEntity;
        private readonly DbSet<tbl_measureunits> measureUnitsEntity;
        private readonly DbSet<tbl_storeplaces> storePlaceEntity;

        public ShaguarRepository(shaguarContext context)
        {
            this.context = context;
            goodsbatchesEntity = context.Set<tbl_goodsbatches>();
            goodsEntity = context.Set<tbl_goods>();
            goodsBatchStatesEntity = context.Set<tbl_goodsbatchstates>();
            measureUnitsEntity = context.Set<tbl_measureunits>();
            storePlaceEntity = context.Set<tbl_storeplaces>();
        }

        public IEnumerable<GoodsBatch> GetGoodsBatches()
        {
            return goodsbatchesEntity.Select(g => new GoodsBatch()
            {
                Id = g.id,
                ManufactureDate = g.manufacture_date,
                State = new GoodsBatchStates()
                {
                    Id = g.state.id,
                    Name = g.state.name
                },
                Quantity = g.goods_quantity,
                MeasureUnit = new MeasureUnits()
                {
                    Id = g.measureunit.id,
                    Name = g.measureunit.name
                },
                Goods = new Goods()
                {
                    Id = g.goods.id,
                    Name = g.goods.name
                },
                StorePlace = new StorePlace()
                {
                    Id = g.storeplace.id,
                    Name = g.storeplace.name
                }
            }).AsEnumerable();
        }

        public GoodsBatch? GetGoodsBatch(long id)
        {
            return goodsbatchesEntity.Select(g => new GoodsBatch()
            {
                Id = g.id,
                ManufactureDate = g.manufacture_date,
                State = new GoodsBatchStates()
                {
                    Id = g.state.id,
                    Name = g.state.name
                },
                Quantity = g.goods_quantity,
                MeasureUnit = new MeasureUnits()
                {
                    Id = g.measureunit.id,
                    Name = g.measureunit.name
                },
                Goods = new Goods()
                {
                    Id = g.goods.id,
                    Name = g.goods.name
                },
                StorePlace = new StorePlace()
                {
                    Id = g.storeplace.id,
                    Name = g.storeplace.name
                }
            }).SingleOrDefault(s => s.Id == id);
        }

        public long Add(GoodsBatch batch)
        {
            var goodsbatches = new tbl_goodsbatches()
            {
                manufacture_date = batch.ManufactureDate,
                state_id = batch.State?.Id ?? 0,
                goods_quantity = batch.Quantity,
                measureunit_id = batch.MeasureUnit?.Id ?? 0,
                goods_id = batch.Goods?.Id ?? 0,
                storeplace_id = batch.StorePlace?.Id ?? 0,
            };
            goodsbatchesEntity.Add(goodsbatches);
            context.SaveChanges();
            return goodsbatches.id;
        }

        public void Update(long id, GoodsBatch batch)
        {
            var goodsbatches = goodsbatchesEntity.Find(id);
            if (goodsbatches != null)
            {
                goodsbatches.manufacture_date = batch.ManufactureDate;
                goodsbatches.state_id = batch.State?.Id ?? 0;
                goodsbatches.goods_quantity = batch.Quantity;
                goodsbatches.measureunit_id = batch.MeasureUnit?.Id ?? 0;
                goodsbatches.goods_id = batch.Goods?.Id ?? 0;
                goodsbatches.storeplace_id = batch.StorePlace?.Id ?? 0;

                context.Entry(goodsbatches).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var batch = goodsbatchesEntity.Find(id);
            if (batch != null)
            {
                goodsbatchesEntity.Remove(batch);
                context.SaveChanges();
            }
        }

        public IEnumerable<Goods> GetGoods()
        {
            return goodsEntity.Select(g => new Goods()
            {
                Id = g.id,
                Name = g.name
            }).AsEnumerable();
        }

        public IEnumerable<GoodsBatchStates> GetGoodsBatchStates()
        {
            return goodsBatchStatesEntity.Select(g => new GoodsBatchStates()
            {
                Id = g.id,
                Name = g.name
            }).AsEnumerable();
        }

        public IEnumerable<MeasureUnits> GetMeasureUnits()
        {
            return measureUnitsEntity.Select(g => new MeasureUnits()
            {
                Id = g.id,
                Name = g.name
            }).AsEnumerable();
        }

        public IEnumerable<StorePlace> GetStorePlaces()
        {
            return storePlaceEntity.Select(g => new StorePlace()
            {
                Id = g.id,
                Name = g.name
            }).AsEnumerable();
        }

        public void Patch(long id, PatchGoodsBatch patchGoodsBatch)
        {
            var goodsbatches = goodsbatchesEntity.Find(id);
            if (goodsbatches != null)
            {
                goodsbatches.state_id = patchGoodsBatch.IsFieldPresent(nameof(patchGoodsBatch.StateId)) ? patchGoodsBatch.StateId : goodsbatches.state_id;
                goodsbatches.storeplace_id = patchGoodsBatch.IsFieldPresent(nameof(patchGoodsBatch.StorePlaceId)) ? patchGoodsBatch.StorePlaceId : goodsbatches.storeplace_id;
                goodsbatches.goods_quantity = patchGoodsBatch.IsFieldPresent(nameof(patchGoodsBatch.Quantity)) ? patchGoodsBatch.Quantity : goodsbatches.goods_quantity;

                context.Entry(goodsbatches).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
