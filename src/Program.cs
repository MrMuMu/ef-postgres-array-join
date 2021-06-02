using System;
using System.Linq;
using System.Threading.Tasks;
using Ef.Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ef.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ctx = new EfTestContext();

            // var x = await ctx.Table1s.AsNoTracking().Where(...);
        }
    }
}
