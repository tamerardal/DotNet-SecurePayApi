using AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		//Customer Mapping
		CreateMap<CreateCustomerCommand.CreateCustomerViewModel, Customer>();
		CreateMap<Customer, GetCustomersQuery.CustomersViewModel>();
		CreateMap<Customer, GetCustomerDetailQuery.CustomerDetailViewModel>()
		.ForMember(dest => dest.PurchasedProducts, opt => opt.MapFrom(src => src.Payment.Select(x => x.Product.Title + " isimli ürünü " + x.PaymentDate.ToShortDateString() + " tarihinde " + x.Product.Price + " TL'ye satın almıştır.")));		
		
		//Payment Mapping
		CreateMap<CreatePaymentCommand.CreatePaymentViewModel, Payment>();
	}
}