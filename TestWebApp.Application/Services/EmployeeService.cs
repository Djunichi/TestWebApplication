using TestWebApp.Application.Services.Interfaces;
using TestWebApp.Data.Repositories.Interfaces;
using TestWebApp.Domain.Enums;
using TestWebApp.Domain.PostgresEF;
using TestWebApp.Domain.Requests;

namespace TestWebApp.Application.Services;

public class EmployeeService : IEmployeeService
{
    
    private readonly IEntityRepository<Employee> _employeeRepository;
    private readonly IEntityRepository<SystemLog> _logRepository;

    public EmployeeService(IEntityRepository<Employee> employeeRepository,
        IEntityRepository<SystemLog> logRepository)
    {
        _employeeRepository = employeeRepository;
        _logRepository = logRepository;
    }
    
    public async Task CreateNewEmployeeAsync(CreateNewEmployeeRequest request, CancellationToken cancellationToken)
    {
        var dbEmployees = await _employeeRepository.GetAll();
        var dbEmployee = dbEmployees.Where(x => x.Title == request.Title);

        if (dbEmployee.Any())
        {
            throw new ArgumentException("Employee already exists");
        }

        var employee = new Employee()
        {
            Title = request.Title,
            Email = request.Email,
            CreatedAt = DateTime.Now,
            Companies = request.Companies
        };

         await _employeeRepository.InsertAsync(employee, cancellationToken);

         var logMessage = new SystemLog()
         {
             Resource = nameof(Employee),
             CreatedAt = DateTime.Now,
             EventType = EEventType.Create,
             Attributes = employee.ToString(),
             Comment = $"new employee {employee.Email} was created"
         };

         await _logRepository.InsertAsync(logMessage, cancellationToken);
    }
}