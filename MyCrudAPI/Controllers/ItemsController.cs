using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCrudAPI.Models;
using MyCrudAPI.Services;

namespace MyCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

         [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_context.Items);
        }

        [HttpGet("{id}")]
       
        public IActionResult GetItemById(int id)
        {
            var employee = _context.Items.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult AddItem(Items ItemDto)
        {
            var Item = new Items
            {
                Name = ItemDto.Name,
                Gender = ItemDto.Gender,
                Email = ItemDto.Email
               
            };
            _context.Items.Add(Item);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult UpdateItem(Items ItemDto)
        {
            var Item = _context.Items.Find(ItemDto.Id);
            if (Item == null)
            {
                return NotFound();
            }
            Item.Name = ItemDto.Name;
            Item.Gender = ItemDto.Gender;
            Item.Email = ItemDto.Email;
          
            _context.SaveChanges();
            return Ok(Item);
        }

        [HttpDelete("{id}")]
       
        public IActionResult DeleteItem(int id)
        {
            var Item = _context.Items.Find(id);
            if (Item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(Item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}