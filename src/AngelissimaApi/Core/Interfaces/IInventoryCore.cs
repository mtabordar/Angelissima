﻿namespace AngelissimaApi.Core.Interfaces
{    
    using ViewModels;

    public interface IInventoryCore : IBaseCore<InventoryViewModel>
    {
        int GetTotalInventoryProductQuantity(int productId);

        int GetAvailableProductQuantity(int productId);
    }
}
