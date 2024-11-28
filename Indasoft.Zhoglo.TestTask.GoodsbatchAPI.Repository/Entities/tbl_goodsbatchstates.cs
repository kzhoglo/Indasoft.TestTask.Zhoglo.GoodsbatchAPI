using System;
using System.Collections.Generic;

namespace Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.Entities;

public partial class tbl_goodsbatchstates
{
    public long id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public virtual ICollection<tbl_goodsbatches> tbl_goodsbatches { get; set; } = new List<tbl_goodsbatches>();
}
