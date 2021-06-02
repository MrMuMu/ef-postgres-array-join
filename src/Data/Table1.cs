using System;
using System.Collections.Generic;

#nullable disable

namespace Ef.Test.Data
{
    public partial class Table1
    {
        public long Id { get; set; }
        public long[] Table2Ids { get; set; }
    }
}
