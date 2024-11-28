using System;
using System.Collections.Generic;

namespace Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.Entities;

public partial class tbl_measureunits
{
    public long id { get; set; }

    public string code { get; set; } = null!;

    public string name { get; set; } = null!;

    public virtual ICollection<tbl_goodsbatches> tbl_goodsbatches { get; set; } = new List<tbl_goodsbatches>();
}
