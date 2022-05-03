using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    public abstract class BaseInformationController : Controller
    {
        private protected readonly IProjectRepository projectRepository;
        private protected readonly IStructureRepository structureRepository;

        internal ApplicationUser? ApplicationUser { get; set; }
        internal Project? Project { get; set; }
        internal Structure? Structure { get; set; }
        internal bool IsReady { get; set; } = false;

        public BaseInformationController(IProjectRepository projectRepository,
                                         IStructureRepository structureRepository)
        {
            this.projectRepository = projectRepository;
            this.structureRepository = structureRepository;
        }
    }
}
