using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Wmsinboundorderdtbl
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceNoTax { get; set; }
        public bool InStockStatus { get; set; }
        public int AsnStatus { get; set; }
        public string GoodsId { get; set; }
        public string GoodsBatch { get; set; }
        public string QualityFlg { get; set; }
        public decimal OrderNum { get; set; }
        public decimal InNum { get; set; }
        public decimal LeaveNum { get; set; }
        public decimal HoldNum { get; set; }
        public string ProdDate { get; set; }
        public string ExpireDate { get; set; }
        public decimal? TaxRate { get; set; }
        public string OwnerId { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }
    }
}
