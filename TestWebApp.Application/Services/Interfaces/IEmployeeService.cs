using TestWebApp.Domain.Requests;

namespace TestWebApp.Application.Services.Interfaces;

public interface IEmployeeService
{
    public Task CreateNewEmployeeAsync(CreateNewEmployeeRequest request, CancellationToken cancellationToken);
}