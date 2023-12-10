using Assistente.Api.Data;
using Assistente.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assistente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGroupsController : ControllerBase
    {
        private ApiDbContext dbContext;

        public EventGroupsController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await this.dbContext.EventGroups.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await this.dbContext.EventGroups.FindAsync(id);

            if(result == null)
            {
                return NotFound("Group not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EventGroup eventGroup)
        {
            await this.dbContext.EventGroups.AddAsync(eventGroup);
            await this.dbContext.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] EventGroup eventGroupObj)
        {
            var eventGroup = await this.dbContext.EventGroups.FindAsync(id);

            if (eventGroup == null)
            {
                return NotFound("Group not found.");
            }

            eventGroup.Name = eventGroupObj.Name;
            eventGroup.Description = eventGroupObj.Description;
            await this.dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var eventGroup = await this.dbContext.EventGroups.FindAsync(id);
            this.dbContext.EventGroups.Remove(eventGroup);
            await this.dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
