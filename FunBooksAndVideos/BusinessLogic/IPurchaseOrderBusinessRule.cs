using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideos.BusinessLogic
{
	public interface IPurchaseOrderBusinessRule
	{
        Task ApplyBusinessRuleAsync(PurchaseOrder request);
	}
}