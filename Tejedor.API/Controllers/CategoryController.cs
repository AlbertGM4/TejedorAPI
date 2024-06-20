using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.CategoryDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository CategoryRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryRepository"></param>
    public CategoryController(ICategoryRepository categoryRepository)
    {
        CategoryRepository = categoryRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getCategories")]
    public async Task<IEnumerable<GetCategoryListDTO>> GetAllCategories()
    {
        return (await CategoryRepository.GetCategories()).Select(category => (GetCategoryListDTO) category);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryID"></param>
    /// <returns></returns>
    [HttpGet("getCategory/({categoryID})")]
    public async Task<ActionResult<GetCategoryListDTO>> GetCategory([FromRoute] int categoryID)
    {
        var getCategory = await CategoryRepository.GetCategory(categoryID);
        return getCategory != null ? (GetCategoryListDTO)getCategory : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categories"></param>
    [HttpPost("addCategories")]
    public async Task<IActionResult> AddCategories([FromBody] IEnumerable<SetCategoryListDTO> categories)
    {
        var categoryEntities = categories.Select(dto => (Category)dto).ToList();
        await CategoryRepository.AddCategories(categoryEntities);
        return CreatedAtAction(nameof(GetAllCategories), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categories"></param>
    [HttpPut("updateCategories")]
    public async Task<IActionResult> UpdateCategories([FromBody] IEnumerable<SetCategoryListDTO> categories)
    {
        var categoryEntities = categories.Select(dto => (Category)dto).ToList();
        await CategoryRepository.UpdateCategories(categoryEntities);
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categories"></param>
    [HttpDelete("deleteCategories")]
    public async Task<IActionResult> DeleteCategories([FromBody] IEnumerable<SetCategoryListDTO> categories)
    {
        var categoryEntities = categories.Select(dto => (Category)dto).ToList();
        await CategoryRepository.DeleteCategories(categoryEntities);
        return NoContent();
    }
}