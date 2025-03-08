using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, 
        CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, 
        RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            this._getCategoryQueryHandler = getCategoryQueryHandler;
            this._getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this._createCategoryCommandHandler = createCategoryCommandHandler;
            this._updateCategoryCommandHandler = updateCategoryCommandHandler;
            this._removeCategoryCommandHandler = removeCategoryCommandHandler;
        } 
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _getCategoryQueryHandler.Handle();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command){
            await _createCategoryCommandHandler.Handle(command); 
            return Ok("Kategori ekleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryss(int id){
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id)); 
            return Ok("Kategori silme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command){
            await _updateCategoryCommandHandler.Handle(command); 
            return Ok("Kategori güncelleme işlemi başarılı");
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id){
            var result = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
    }
}