using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.CategoryDTO;
using Tejedor.Infrastructure.Entity;
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
        return (await CategoryRepository.GetCategories()).Select(x => (GetCategoryListDTO) x);        
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
    public async Task AddCategories(SetCategoryListDTO categories)
    {
        await CategoryRepository.AddCategories(new List<Category>() { (Category) categories } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categories"></param>
    [HttpPut("updateCategories")]
    public async Task UpdateCategories(SetCategoryListDTO categories)
    {
        await CategoryRepository.UpdateCategories(new List<Category>() { (Category) categories });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categories"></param>
    [HttpDelete("deleteCategories")]
    public async Task DeleteCategories(SetCategoryListDTO categories)
    {
        await CategoryRepository.DeleteCategories(new List<Category>() { (Category) categories });
    }
}