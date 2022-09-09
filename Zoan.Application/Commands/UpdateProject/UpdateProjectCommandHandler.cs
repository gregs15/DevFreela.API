using MediatR;
using Zoan.Core.Repositories;

namespace Zoan.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project != null)
            {
                project.Update(request.Title, request.Description, request.TotalCost);
              await  _projectRepository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}


//COM EF CORE


// 
// var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

// project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
// _dbContext.SaveChanges();
