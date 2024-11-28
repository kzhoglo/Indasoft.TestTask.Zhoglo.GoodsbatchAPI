namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data
{
    public class GoodsBatch
    {
        public long Id { get; set; }
        public DateTime ManufactureDate { get; set; }
        public GoodsBatchStates? State { get; set; }
        public MeasureUnits? MeasureUnit { get; set; }
        public Goods? Goods { get; set; }
        public StorePlace? StorePlace { get; set; }
        public double Quantity { get; set; }

        public static bool Validate(GoodsBatch goodsBatch)
        {
            return goodsBatch.State != null && goodsBatch.Goods != null && goodsBatch.MeasureUnit != null && goodsBatch.StorePlace != null;
        }
    }
}
