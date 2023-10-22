using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Mini_Auction.Core;

namespace Mini_Auction.Persistence
{
    /*public class AuctionStatusInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries<AuctionDB>())
            {
                Console.WriteLine(entry.Entity.Status);
                if (entry.Entity.EndTime <= DateTime.Now && entry.Entity.Status != 0)
                {
                    Console.WriteLine("Interceptor is executing.");
                    entry.Entity.Status = 0;
                }
            }
            
            return base.SavingChanges(eventData, result);
        }
    }*/

}
