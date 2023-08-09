using System;
using FunBooksAndVideos.BusinessLogic;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.Enums;
using FunBooksAndVideos.Repository.Interfaces;
using FunBooksAndVideos.Repository.Repositories;
using FunBooksAndVideos.Uow;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FunBooksAndVideosTest.BusinessLogic
{
	public class ActivateMembershipBusinessRuleTests
	{
		private ActivateMembershipBusinessRule activateMembershipRule;
		private PurchaseOrderStatus purchaseOrderStatus;
		private Mock<IUnitOfWork> _unitOfWorkMock;
		private PurchaseOrder purchaseOrder;
		private Mock<CustomerRepository> _customerRepositoryMock;
		private Mock<DbContext> dbContext = new Mock<DbContext>();
        Customer customer = new Customer();

        public ActivateMembershipBusinessRuleTests()
		{
			_unitOfWorkMock = new Mock<IUnitOfWork>();
			_customerRepositoryMock = new Mock<CustomerRepository>(dbContext.Object);
            purchaseOrderStatus = new PurchaseOrderStatus();
			activateMembershipRule = new ActivateMembershipBusinessRule(null, purchaseOrderStatus, _unitOfWorkMock.Object);
			purchaseOrder = new PurchaseOrder();

			
			customer.CustomerId = Guid.NewGuid();
            customer.FirstName = "FirstName";
			customer.LastName = "LastName";
			customer.Address = "Address";
			customer.Email = "First.Last@gmail.com";


			List<Item> items = new List<Item>();
			Item videoM = new Item();
			videoM.Type = ItemTypeEnum.VideoMembership;
			videoM.Category = "Entertainment";
			videoM.ItemId = Guid.NewGuid();
			items.Add(videoM);

			ICollection<Item> collectionItems = items;

            purchaseOrder.CustomerId = customer.CustomerId;
            purchaseOrder.Customer = customer;
            purchaseOrder.TotalPrice = 100;
            purchaseOrder.PurchaseOrderId = Guid.NewGuid();
			purchaseOrder.Items = collectionItems;

        }


        [Fact]
        public async void ApplyBusinessRuleAsync_WhenCalled_ShouldActivateMembership()
        {
			/*
			_unitOfWorkMock.SetupGet(u => u.CustomerRepository)
				.Returns(_customerRepositoryMock.Object);

			_unitOfWorkMock.Setup(u => u.save());

            _customerRepositoryMock.Setup(c => c.Update(It.IsAny<Customer>()));

			await activateMembershipRule.ApplyBusinessRuleAsync(purchaseOrder);

			Assert.NotNull(customer.Memberships);
			*/

        }

    }


	
}

