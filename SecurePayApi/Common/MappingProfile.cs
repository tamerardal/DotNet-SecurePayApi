using AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		//Customer Mapping
		CreateMap<CreateCustomerCommand.CreateCustomerViewModel, Customer>();
		CreateMap<Customer, GetCustomersQuery.CustomersViewModel>()
		.ForMember(dest => dest.PaymentMethods, opt => opt.MapFrom(src => src.PaymentMethods.Select(x => x.CardName)));
		
		//Payment Mapping
		CreateMap<CreatePaymentCommand.CreatePaymentViewModel, Payment>();
	}
}