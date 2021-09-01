using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using colors.Controllers.Resources;
using colors.Models;
using colors.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace colors.Controllers
{
  public class EntriesController : Controller
  {
    // Keep in mind, i would've used repositories/dependency injection for a larger project, just didn't want to overdo the structure
    private readonly ColorsDbContext context;
    private readonly IMapper mapper;

    public EntriesController(ColorsDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }


    [HttpGet("/api/entries")]
    public async Task<IEnumerable<Entry>> GetEntries()
    {
      return await context.Entries.OrderByDescending(e => e.EntryDate).ToListAsync();
    }

    [HttpGet("/api/entry-colors")]
    public async Task<IEnumerable<string>> GetEntryColors()
    {
      return await context.Entries.Select(e => e.Color).Distinct().ToListAsync();
    }

    [HttpGet("/api/entries/stats")]
    public async Task<List<StatsResult>> GetEntryStats()
    {
      return await context.Set<StatsResult>().FromSqlRaw("Select * from (Select TOP 1 Color, Count('Color') as color_count, 1 as filter from Entries where Age > 0 and Age <= 18 GROUP BY Color ORDER BY color_count DESC) s1 UNION ALL Select * from (Select TOP 1 Color, Count('Color') as color_count, 2 as filter from Entries where Age > 18 and Age <= 36 GROUP BY Color ORDER BY color_count DESC) s2 UNION ALL Select * from (Select TOP 1 Color, Count('Color') as color_count, 3 as filter from Entries where Age > 36 and Age <= 54 GROUP BY Color ORDER BY color_count DESC) s3 UNION ALL Select * from (Select TOP 1 Color, Count('Color') as color_count, 4 as filter from Entries where Age > 54 GROUP BY Color ORDER BY color_count DESC) s4 ORDER BY filter").ToListAsync();
    }
    

    [HttpPost("api/entries")]
    public async Task<IActionResult> CreateEntry([FromBody] EntryResource entryResource) {
      // Keep in mind, i would've used repositories/dependency injection for a larger project, just didn't want to overdo the structure
      
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      // Could also add some business rule validation here ...

      var entry = mapper.Map<EntryResource, Entry>(entryResource);
      entry.EntryDate = DateTime.Now;
      context.Entries.Add(entry);
      await context.SaveChangesAsync();

      return Ok(entry);
    } 

    [HttpPut("api/entries/{id}")]
    public async Task<IActionResult> UpdateEntry(int id, [FromBody] EntryResource entryResource) {

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      // Could also add some business rule validation here ...
      
      var entry = await context.Entries.FindAsync(id);
      if(entry == null) {
        return NotFound("Entry not found.");
      }

      entry = mapper.Map<EntryResource, Entry>(entryResource, entry);
      entry.EntryDate = DateTime.Now;
      await context.SaveChangesAsync();

      return Ok(entry);
    } 

  }
}