using practicaef.Shared.Infrastructure.Persistence.EFC.Configuration;
using practicaef.Shared.Infrastructure.Persistence.EFC.Repositories;
using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Repositories;

namespace practicaef.wms.Infrastructure.Persistence.EFC.Repositories;

public class InventoryItemRepository(AppDbContext context): BaseRepository<InventoryItem>(context), IInventoryItemRepository
{
    
    public async Task<InventoryItem?> FindInventoryItemByEpicorSkuAsync(string epicorSku)
    {   
        var guid = Guid.Parse(epicorSku);
        return Context.Set<InventoryItem>().FirstOrDefault(i =>i.EpicorSku == guid);
    }
        
}