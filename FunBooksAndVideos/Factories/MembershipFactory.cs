

using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.Enums;

namespace FunBooksAndVideos.BusinessLogic
{
    public class MembershipFactory : IMembershipFactory
    {
     
        // AutoGenMembership Id
        public Membership getObject(Item item , PurchaseOrder order)
        {
            Membership membership = new Membership();
            membership.ItemId = item.ItemId;
            membership.CustomerId = order.CustomerId;
            membership.isActive = true;

            if (item.Type.Equals(ItemTypeEnum.BookMembership))
                membership.MembershipType = MembershipEnum.BookClub;
            else if (item.Type.Equals(ItemTypeEnum.VideoMembership))
                membership.MembershipType = MembershipEnum.VideoClub;
            else
                membership.MembershipType = MembershipEnum.Premium;

            membership.Customer = order.Customer;

            return membership;

        }
    }
}

