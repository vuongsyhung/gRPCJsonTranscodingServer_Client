using Grpc.Core;
using GrpcServiceOnlineBanking.Models;
using GrpcServiceOnlineBanking.Protos;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace GrpcServiceOnlineBanking.Services
{
    public class OnlineBankingService: OnlineBanking.OnlineBankingBase
    {
        private readonly ILogger<OnlineBankingService> _logger;
        private readonly HungDbContext _dbContext;

        public OnlineBankingService(ILogger<OnlineBankingService> logger, HungDbContext hungDbContext)
        {
            _logger = logger;
            _dbContext = hungDbContext;
        }

        public override async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
        {
            if (request == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Data input not valid"));

            var customer = new Customer
            {
                FirstName = request.FirstName.ToString(),                
                LastName = request.LastName.ToString(),
                DateOfBirth = Convert.ToDateTime(request.DateOfBirth.ToString()),
                Email = request.Email.ToString(),
                StreesAddress = request.StreesAddress.ToString(),
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode,
                Country = request.Country,
                Sex = request.Sex
            };

            await _dbContext.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new CreateCustomerResponse
            {
                CustomerId = customer.CustomerId
            });
        }

        public override async Task<ReadCustomerResponse> ReadCustomer(ReadCustomerRequest request, ServerCallContext context)
        {
            if (request.CustomerId <= 0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "resouce index must be greater than 0"));

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(t => t.CustomerId == request.CustomerId);

            if (customer != null)
            {
                return await Task.FromResult(new ReadCustomerResponse
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth.ToString(),
                    Email = customer.Email.ToString(),
                    StreesAddress = customer.StreesAddress,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode,
                    Country = customer.Country,
                    Sex = customer.Sex
                });
            }

            throw new RpcException(new Status(StatusCode.NotFound, $"No Task with id {request.CustomerId}"));
        }

        public override async Task<GetAllCustomerResponse> GetAllCustomers(GetAllCustomerRequest request, ServerCallContext context)
        {
            var response = new GetAllCustomerResponse();
            var abc = await _dbContext.Customers.ToListAsync();

            foreach (var customer in abc)
            {
                response.Customers.Add(new ReadCustomerResponse
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth.ToString(),
                    Email = customer.Email.ToString(),
                    StreesAddress = customer.StreesAddress,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode,
                    Country = customer.Country,
                    Sex = customer.Sex
                });
            }

            return await Task.FromResult(response);
        }

        public override async Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request, ServerCallContext context)
        {
            if (request == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must suppply a valid object"));

            var xyz = await _dbContext.Customers.FirstOrDefaultAsync(t => t.CustomerId == request.CustomerId);

            if (xyz == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"No Task with Id {request.CustomerId}"));

            xyz.FirstName = request.FirstName.ToString();
            xyz.LastName = request.LastName.ToString();
            xyz.DateOfBirth = DateTime.Parse(request.DateOfBirth);
            xyz.Email = request.Email.ToString();
            xyz.StreesAddress = request.StreesAddress.ToString();
            xyz.City = request.City;
            xyz.State = request.State;
            xyz.ZipCode = request.ZipCode;
            xyz.Country = request.Country;
            xyz.Sex = request.Sex;

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new UpdateCustomerResponse
            {
                CustomerId = xyz.CustomerId,
            });
        }

        public override async Task<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request, ServerCallContext context)
        {
            if (request.CustomerId <= 0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "resouce index must be greater than 0"));

            var abc = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == request.CustomerId);

            if (abc == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"No Task with Id {request.CustomerId}"));
            _dbContext.Remove(abc);

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new DeleteCustomerResponse
            {
                CustomerId = abc.CustomerId
            });

        }
    }
}
