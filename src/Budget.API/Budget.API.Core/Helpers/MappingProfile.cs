using AutoMapper;

using DM = Budget.API.Data.Models;

namespace Budget.API.Core.Helpers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<DM.Category, Contracts.Category>();
			CreateMap<Contracts.Category, DM.Category>();
			CreateMap<Contracts.CategoryBase, DM.Category>();
		}
	}
}
