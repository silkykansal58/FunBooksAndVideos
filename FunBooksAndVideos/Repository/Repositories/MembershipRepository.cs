using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Repository.Repositories
{
	public class MembershipRepository: GenericRepository<Membership>,IMembershipRepository
	{
		public MembershipRepository(DbContext dbContext) : base(dbContext)
        {
		}

        public void AddMembership(Membership membership)
        {
             Create(membership);
        }

        public void UpdateMembership(Membership memebership)
        {
            Update(memebership);
        }
    }
}

