using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;

namespace FunBooksAndVideos.Repository.Interfaces
{
	public interface IMembershipRepository: IGenericRepostory<Membership>
	{
		void AddMembership(Membership membership);
        void UpdateMembership(Membership memebership);
	}
}

