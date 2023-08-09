using FunBooksAndVideos.Models;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideos.BusinessLogic
{
	public class PurchaseOrderBusinessRule : IPurchaseOrderBusinessRule
	{
        private IPurchaseOrderBusinessRule? nextBusinessRule;
        private PurchaseOrderStatus status;
        
        public PurchaseOrderBusinessRule(IPurchaseOrderBusinessRule? nextBusinessRule, PurchaseOrderStatus purchaseOrderStatus)
        {
            this.nextBusinessRule = nextBusinessRule;
            this.status = purchaseOrderStatus;
        }
		
        public virtual async Task ApplyBusinessRuleAsync(PurchaseOrder request)
        {
            if(this.nextBusinessRule != null)
            {
               await this.nextBusinessRule.ApplyBusinessRuleAsync(request);
            }
        }
    }
}

