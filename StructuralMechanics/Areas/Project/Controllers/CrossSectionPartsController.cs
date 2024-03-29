﻿using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.Mappers;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
    public class CrossSectionPartsController : BaseInformationController
    {
        private readonly ICrossSectionElementRepository crossSectionElementRepository;
        private readonly ICrossSectionPartRepository crossSectionPartRepository;

        public CrossSectionPartsController(IProjectRepository projectRepository, 
                                           IStructureRepository structureRepository,
                                           ICrossSectionElementRepository crossSectionElementRepository,
                                           ICrossSectionPartRepository crossSectionPartRepository) 
                                           : base(projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.crossSectionPartRepository = crossSectionPartRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            var crossSectionParts = crossSectionPartRepository.GetPartsByStructureId(Structure!.Id);
            return View(crossSectionParts);
        }

        [HttpGet]
        [TypeFilter(typeof(PointsSelectListGetterFilter<CrossSectionPartViewModel>))]
        public IActionResult Create()
        {
            return View(new CrossSectionPartViewModel { IsCreateView = true });
        }

        [HttpPost]
        [TypeFilter(typeof(CrossSectionPartPointsSetterFilter))]
        public IActionResult Create(CrossSectionPartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsCreateView = true;
                return View(model);
            }

            var crossSectionPart = CrossSectionPartCreator.Create(model);
            if (crossSectionPart == null)
            {
                ModelState.AddModelError(string.Empty, "Choose Cross-section Part Type");
                return View(model);
            }

            crossSectionPart.StructureId = Structure!.Id;
            crossSectionElementRepository.Add(crossSectionPart);
            return RedirectToAction("Index", "CrossSectionParts");
        }

        [HttpGet]
        [TypeFilter(typeof(PointsSelectListGetterFilter<CrossSectionPartViewModel>))]
        public IActionResult Edit(int id)
        {
            var crossSectionPart = crossSectionPartRepository.Get(id, Structure!.Id);
            if (crossSectionPart == null)
            {
                ViewBag.ErrorMessage = "The cross-section part is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            CrossSectionPartViewModel model = CrossSectionPartMapper.Map(crossSectionPart);
            return View(model);
        }

        [HttpPost]
        [TypeFilter(typeof(CrossSectionPartPointsSetterFilter))]
        public IActionResult Edit(CrossSectionPartViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var crossSectionPart = crossSectionPartRepository.Get(model.Id, Structure!.Id);
            if (crossSectionPart == null)
            {
                ViewBag.ErrorMessage = "The cross-section part is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            crossSectionPart.Edit(model.FirstPoint!, model.SecondPoint!, model.Thickness);
            crossSectionElementRepository.Update(crossSectionPart);
            return RedirectToAction("Index", "CrossSectionParts");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var crossSectionPart = crossSectionPartRepository.Get(id, Structure!.Id);
            if (crossSectionPart == null)
            {
                ViewBag.ErrorMessage = "The cross-section part is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            crossSectionElementRepository.Delete(crossSectionPart);
            return RedirectToAction("Index", "CrossSectionParts");
        }
    }
}
