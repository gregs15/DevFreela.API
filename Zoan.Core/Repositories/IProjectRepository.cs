using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.Entities;

namespace Zoan.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task<Project> GetDetailsByIdAsync(int id);
       
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
        Task SaveChangesAsync();
    }
}
