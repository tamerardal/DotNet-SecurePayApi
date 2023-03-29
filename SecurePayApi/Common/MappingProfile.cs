using AutoMapper;
using static GetPaymentsQuery;
using static GetProductsQuery;

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
		CreateMap<Payment, PaymentListViewModel>()
		.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
		.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.Title + " " + src.Product.Price + "₺"));
		
		//Product Mapping
		CreateMap<Product, GetProductsViewModel>()
		.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price + " ₺"));
	}
}