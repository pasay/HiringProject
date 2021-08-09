using MediatR;

namespace HiringProject.Model.Commands.Companies
{
    public class DecrementPublishJobCountCompanyCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
