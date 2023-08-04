using TestWebApp.Domain.Requests;

namespace TestWebApp.Application.Services.Interfaces;

public interface ICompanyService
{
    public Task CreateNewCompanyAsync(CreateNewCompanyRequest request, CancellationToken cancellationToken);
}