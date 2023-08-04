using TestWebApp.Application.Services.Interfaces;
using TestWebApp.Data.Repositories.Interfaces;
using TestWebApp.Domain.Enums;
using TestWebApp.Domain.PostgresEF;
using TestWebApp.Domain.Requests;

namespace TestWebApp.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly IEntityRepository<Company> _companyRepository;
    private readonly IEntityRepository<SystemLog> _logRepostoryl;

    public CompanyService(IEntityRepository<Company> companyRepository,
        IEntityRepository<SystemLog> logRepostoryl)
    {
        _companyRepository = companyRepository;
        _logRepostoryl = logRepostoryl;
    }

    public async Task CreateNewCompanyAsync(CreateNewCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = new Company()
        {
            Name = request.Name,
            CreatedAt = DateTime.Now,
            Employees = request.Employees
        };

        await _companyRepository.InsertAsync(company, cancellationToken);

        var logMessage = new SystemLog()
        {
            Resource = nameof(Employee),
            CreatedAt = DateTime.Now,
            EventType = EEventType.Create,
            Attributes = company.ToString(),
            Comment = $"new employee {company.Name} was created"
        };

        await _logRepostoryl.InsertAsync(logMessage, cancellationToken);
    }
}