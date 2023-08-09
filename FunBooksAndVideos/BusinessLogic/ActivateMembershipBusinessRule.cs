using FunBooksAndVideos.Uow;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Enums;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.BusinessLogic
{
    // Process the items which is of membership type.
    // One of the processor as per Chain of Resp design pattern.
    public class ActivateMembershipBusinessRule : PurchaseOrderBusinessRule
    {
        private ICustomerRepository customerRepository;
        private MembershipFactory membershipFactory;
        private IUnitOfWork unityOfWork;

        public ActivateMembershipBusinessRule(
                PurchaseOrderBusinessRule? nextProcessor,
                PurchaseOrderStatus purchaseOrderStatus,
                IUnitOfWork unityOfWork
            ) : base(nextProcessor, purchaseOrderStatus)
        {
            this.unityOfWork = unityOfWork;
            customerRepository = unityOfWork.CustomerRepository;
            membershipFactory = new MembershipFactory();
        }

        public override async Task ApplyBusinessRuleAsync(PurchaseOrder order)
        {

            // Filter items which is of membership type.
            List<Item> membershipItems =
                order.Items
                .Where(x => x.Type != ItemTypeEnum.Product).ToList();

            if (membershipItems.Count > 0)
            {
                // Customer for which we need to update the membership
                var customer = order.Customer;

                if (customer != null)
                {
                    List<Membership> exitingMemberships = customer.Memberships.ToList();
                    foreach (Item purchaseItem in membershipItems)
                    {
                        if (purchaseItem.Type.Equals(ItemTypeEnum.VideoMembership))
                            customer.Memberships.Add(membershipFactory.getObject(purchaseItem, order));
                        else if (purchaseItem.Type.Equals(ItemTypeEnum.BookMembership))
                            customer.Memberships.Add(membershipFactory.getObject(purchaseItem, order));
                        else
                            customer.Memberships.Add(membershipFactory.getObject(purchaseItem, order));

                        customerRepository.Update(customer);

                    }
                }
            }
            await unityOfWork.save();
            await base.ApplyBusinessRuleAsync(order);
        }
    }
}

