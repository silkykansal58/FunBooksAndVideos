using FunBooksAndVideos.Uow;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.DTO;

namespace FunBooksAndVideos.BusinessLogic
{

	public class BusinessRuleProcessor
	{
		private IPurchaseOrderBusinessRule chain;
		private IUnitOfWork unityOfWork;
		private PurchaseOrderStatus status;

		public BusinessRuleProcessor(IUnitOfWork unityOfWork)
		{
			this.unityOfWork = unityOfWork;
			this.status = new PurchaseOrderStatus();
			buildChain();
        }

		public async Task<PurchaseOrderStatus> ApplyBusinessRulesAsync(PurchaseOrder purchaseOrder)
		{
            await chain.ApplyBusinessRuleAsync(purchaseOrder);
			return status;
		}

        /// <summary>
        /// This chain (Order of operations/Rules) can be dynamically build. Rules can be stored in database and can be fetch to create dynamic chain.
        ///
        /// To add new rule , please follow steps :
        ///  1) Add new business rule by extending the class PurchaseOrderBusinessRule.
        ///  2) Add new rule to chain in a order.
        ///
        /// Cuurent business rules order :
		///   1) Activate Membership
		///   2) Generate Shippingslip
        /// </summary>

        public void buildChain()
		{
            GenerateShippingSlipBusinessRule generateShippingSlipBusinessRule = new GenerateShippingSlipBusinessRule(null, status, unityOfWork);
            this.chain = new ActivateMembershipBusinessRule(generateShippingSlipBusinessRule, status, unityOfWork);

        }
	}
}