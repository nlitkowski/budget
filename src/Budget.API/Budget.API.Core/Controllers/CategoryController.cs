using AutoMapper;
using Budget.API.Contracts;
using Budget.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DM = Budget.API.Data.Models;

namespace Budget.API.Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CategoryController : ControllerBase
	{
		private readonly BudgetDbContext _context;
		private readonly ILogger<CategoryController> _logger;
		private readonly IMapper _mapper;

		public CategoryController(BudgetDbContext context, ILogger<CategoryController> logger, IMapper mapper)
		{
			_context = context;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _context.Categories.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] int id)
		{
			var category = await GetById(id);

			if (category == null) return NotFound();

			return Ok(_mapper.Map<Category>(category));
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CategoryBase value)
		{
			var category = _mapper.Map<DM.Category>(value);

			var res = await _context.Categories.AddAsync(category);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch(DbUpdateException)
			{
				_logger.LogError($"Could not add category: {value}");
				return BadRequest();
			}

			_logger.LogInformation($"Added category: {category}");
			return Ok(res.Entity.Id);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Category value)
		{
			var category = _mapper.Map<DM.Category>(value);

			try
			{
				_context.Update(category);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				_logger.LogError($"Could not update category: {value}");
				return BadRequest();
			}

			_logger.LogInformation($"Updated category: {category}");
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var category = await GetById(id);

			if (category == null) return NotFound();

			_context.Categories.Remove(category);

			int rc = await _context.SaveChangesAsync();
			if (rc == 0) return BadRequest();

			_logger.LogInformation($"Removed category with id: {id}");

			return Ok();
		}

		private async Task<DM.Category?> GetById(int id)
		{
			var category = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

			if (category == null) _logger.LogDebug($"Category id {id} not found");

			return category;
		}
	}
}
