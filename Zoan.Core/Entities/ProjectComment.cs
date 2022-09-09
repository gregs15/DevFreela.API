using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoan.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get;  set; }
        public virtual Project Project { get;  set; }
        public  virtual User User { get; set; }
        public int IdProject { get;  set; }
        public int IdUser { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
