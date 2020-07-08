using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Wmsinboundordertbl
    {
        public string Id { get; set; }
        public string ExternalNo { get; set; }
        public string ExternalType { get; set; }
        public int Status { get; set; }
        public string OrderType { get; set; }
        public string GoodsType { get; set; }
        public string PurchaseNo { get; set; }
        public string StockId { get; set; }
        public string OwnerId { get; set; }
        public string ShipperId { get; set; }
        public string SupplierId { get; set; }
        public DateTime? ScheduledInboundTime { get; set; }
        public string Remark { get; set; }
        public bool? Enable { get; set; }
        public string TransferType { get; set; }
        public bool InBondedArea { get; set; }
        public decimal ReturnBoxNum { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }
        public string OrgId { get; set; }
    }
}
