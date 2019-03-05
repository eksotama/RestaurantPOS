using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.LineItems;
using SP19.P05.Web.Features.Menus;

namespace SP19.P05.Web.Controllers
{
    //public class MenuItemsController : ApiBase
    //{
    //    private readonly DataContext dataContext;
    //    private readonly IMapper mapper;

    //    public MenuItemsController(DataContext dataContext, IMapper mapper)
    //    {
    //        this.dataContext = dataContext;
    //        this.mapper = mapper;
    //    }

    //    [HttpGet("{menuId}")]
    //    public async Task<ActionResult<IEnumerable<MenuItemDto>>> Get(int menuId)
    //    {
    //        var entityQueryable = dataContext.Set<MenuItem>().Where(x => x.MenuId == menuId);
    //        var dtoQueryable = mapper.ProjectTo<MenuItemDto>(entityQueryable);
    //        var itemDtos = await dtoQueryable.ToArrayAsync();
    //        return itemDtos;
    //    }

    //    [HttpPut]
    //    public async Task<ActionResult<MenuItemDto>> Put(MenuItemDto dto)
    //    {
    //        var entity = await dataContext.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == dto.Id);
    //        if (entity == null)
    //        {
    //            return NotFound();
    //        }
    //        mapper.Map(dto, entity);
    //        await dataContext.SaveChangesAsync();
    //        return dto;
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<MenuItemDto>> Post(MenuItemDto dto)
    //    {
    //        var entity = new MenuItem();
    //        mapper.Map(dto, entity);
    //        dataContext.Add(entity);
    //        await dataContext.SaveChangesAsync();
    //        dto.Id = entity.Id;
    //        return dto;
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult> Delete(int id)
    //    {
    //        var entity = await dataContext.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == id);
    //        if (entity == null)
    //        {
    //            return NotFound();
    //        }

    //        dataContext.Remove(entity);
    //        await dataContext.SaveChangesAsync();
    //        return Ok();
    //    }
    //}


    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;


        public MenuItemsController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //give you all the menuitem
        [HttpGet]
        public ActionResult<IEnumerable<MenuItemDto>> GetAllMenuItem()
        {
            var menuItem = context.MenuItem;
            return Ok(mapper.Map<IEnumerable<MenuItemDto>>(menuItem));





        }

        //gives you menuItem of id
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItem(int id)
        //{

        //    var menuItemOfId = await context.MenuItem.FindAsync(id);

        //    return Ok(mapper.Map<MenuItemDto>(menuItemOfId));

        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItem(int id)
        {

            var menuItemOfId = await context.MenuItem.FindAsync(id);

            if (menuItemOfId == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MenuItemDto>(menuItemOfId));

        }



        //gives you menuItem of menuid
        [HttpGet("/fk/{id}")]
        public ActionResult<IEnumerable<MenuItemDto>> GetMenuItemThroughForeignKey(int id)
        {

            var menuItemOfId = context.MenuItem.Where(x => x.MenuId == id).ToList();


            return Ok(mapper.Map<IEnumerable<MenuItemDto>>(menuItemOfId));


            //return Ok(mapper.Map<MenuItemDto>());

           

        }

        //creates a new menuItem 
        [HttpPost]
        public async Task<ActionResult<MenuItemDto>> createMenuItem(MenuItemDto menuItemDto)
        {
            var menuItem = new MenuItem();

            mapper.Map(menuItemDto, menuItem);
            context.Add(menuItem);
            await context.SaveChangesAsync();
            //t    menuDto.Id = menu.Id;

            return menuItemDto;

        }
        //for updating current MenuItems
        [HttpPut("{id}")]
        public async Task<ActionResult<MenuItemDto>> updateMenuItem(int id, MenuItemDto menuItemDto)
        {
            var menuItem = await context.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }
            mapper.Map(menuItemDto, menuItem);
            await context.SaveChangesAsync();
            return menuItemDto;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteMenuItem(int id)
        {

            var menuItem =await context.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }
            context.Remove(menuItem);
            await context.SaveChangesAsync();

            return Ok();

        }

        



    }

   }