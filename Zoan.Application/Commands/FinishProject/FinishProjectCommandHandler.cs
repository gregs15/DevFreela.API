using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.Repositories;
using Zoan.Infrastructure.Persistence;

namespace Zoan.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler: IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public FinishProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project != null)
            {
               project.Finish();
                await _projectRepository.SaveChangesAsync();
            }

            return Unit.Value;

        }
    }
}
