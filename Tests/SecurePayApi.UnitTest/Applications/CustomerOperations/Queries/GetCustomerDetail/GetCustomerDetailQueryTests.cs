using AutoMapper;
using FluentAssertions;
using Xunit;

public class GetCustomerDetailTests : IClassFixture<CommonTestFixture>
{
	private readonly SecurePayDbContext _context;
	private readonly IMapper _mapper;

	public GetCustomerDetailTests(CommonTestFixture testFixture)
	{
		_context = testFixture.Context;
		_mapper = testFixture.Mapper;
	}
	
	[Fact]
	public void WhenNonValidIdIsGiven_InvalidOperationException_ShouldBeReturn()
	{
		GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
		
		FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("ID's not correct!");
	}
}