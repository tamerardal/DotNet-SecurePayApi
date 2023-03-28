using AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		//Customer Mapping
		CreateMap<CreateCustomerCommand.CreateCustomerViewModel, Customer>();
		CreateMap<Customer, GetCustomersQuery.CustomersViewModel>();
		CreateMap<Customer, GetCustomerDetailQuery.CustomerDetailViewModel>()
		.ForMember(dest => dest.PurchasedGoods, opt => opt.MapFrom(src => src.Payment.Select(x => x.Title + " isimli ürünü " + x.PaymentDate.ToShortDateString() + " tarihinde satın almıştır.")));		
		//Payment Mapping
		CreateMap<CreatePaymentCommand.CreatePaymentViewModel, Payment>();
	}
}