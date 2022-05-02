using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    public abstract class BaseInformationController : Controller
    {
        private protected readonly UserManager<ApplicationUser> userManager;
        private protected readonly IProjectRepository projectRepository;
        private protected readonly IStructureRepository structureRepository;

        internal ApplicationUser? ApplicationUser { get; set; }
        internal Project? Project { get; set; }
        internal Structure? Structure { get; set; }
        internal bool IsReady { get; set; } = false;

        public BaseInformationController(UserManager<ApplicationUser> userManager,
                              IProjectRepository projectRepository,
                              IStructureRepository structureRepository)
        {
            this.userManager = userManager;
            this.projectRepository = projectRepository;
            this.structureRepository = structureRepository;
        }
    }
}
