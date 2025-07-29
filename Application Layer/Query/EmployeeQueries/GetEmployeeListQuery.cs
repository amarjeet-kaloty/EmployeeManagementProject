using EmployeeManagementProject.Domain_Layer.Entity;
using MediatR;

namespace EmployeeManagementProject.Application_Layer.Query.EmployeeQueries
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
