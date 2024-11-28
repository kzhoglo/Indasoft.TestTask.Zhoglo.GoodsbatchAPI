using System;
using System.Collections.Generic;

namespace Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.Entities;

public partial class tbl_goodsbatches
{
    public long id { get; set; }

    public long state_id { get; set; }

    public DateTime manufacture_date { get; set; }

    public long goods_id { get; set; }

    public double goods_quantity { get; set; }

    public long measureunit_id { get; set; }

    public long storeplace_id { get; set; }

    public virtual tbl_goods goods { get; set; } = null!;

    public virtual tbl_measureunits measureunit { get; set; } = null!;

    public virtual tbl_goodsbatchstates state { get; set; } = null!;

    public virtual tbl_storeplaces storeplace { get; set; } = null!;    
}
