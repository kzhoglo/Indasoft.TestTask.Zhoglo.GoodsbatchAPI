namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data
{
    public class PatchGoodsBatch
    {
        private HashSet<string> PropertiesInHttpRequest { get; set; } = new HashSet<string>();

        /// <summary>
        /// Returns true if property was present in http request; false otherwise 
        /// </summary>
        public bool IsFieldPresent(string propertyName)
        {
            return PropertiesInHttpRequest.Contains(propertyName.ToLowerInvariant());
        }

        public void SetHasProperty(string propertyName)
        {
            PropertiesInHttpRequest.Add(propertyName.ToLowerInvariant());
        }

        public long StateId { get; set; }

        public long StorePlaceId { get; set; }

        public double Quantity { get; set; }
    }
}
