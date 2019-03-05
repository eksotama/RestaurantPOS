using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Menus;

//namespace SP19.P05.Web.Controllers
//{
//    public class MenusController : ApiBase
//    {
//        private readonly DataContext dataContext;
//        private readonly IMapper mapper;

//        public MenusController(DataContext dataContext, IMapper mapper)
//        {
//            this.dataContext = dataContext;
//            this.mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<MenuDto>>> Get()
//        {
//            var entityQueryable = dataContext.Set<Menu>();
//            var dtoQueryable = mapper.ProjectTo<MenuDto>(entityQueryable);
//            var itemDtos = await dtoQueryable.ToArrayAsync();
//            return itemDtos;
//        }

//        [HttpPut]
//        public async Task<ActionResult<MenuDto>> Put(MenuDto dto)
//        {
//            var entity = await dataContext.Set<Menu>().FirstOrDefaultAsync(x => x.Id == dto.Id);
//            if (entity == null)
//            {
//                return NotFound();
//            }
//            mapper.Map(dto, entity);
//            await dataContext.SaveChangesAsync();
//            return dto;
//        }

//        [HttpPost]
//        public async Task<ActionResult<MenuDto>> Post(MenuDto dto)
//        {
//            var entity = new Menu();
//            mapper.Map(dto, entity);
//            dataContext.Add(entity);
//            await dataContext.SaveChangesAsync();
//            dto.Id = entity.Id;
//            return dto;
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var entity = await dataContext.Set<Menu>().FirstOrDefaultAsync(x => x.Id == id);
//            if (entity == null)
//            {
//                return NotFound();
//            }

//            dataContext.Remove(entity);
//            await dataContext.SaveChangesAsync();
//            return Ok();
//        }

//[HttpPut("{id}")]
//public async Task<ActionResult<IEnumerable<MenuDto>>> put(int id, MenuDto menuDto)
//{
//    var menu = context.Menu.FindAsync(id);
//    if (id != menuDto.id)
//    {
//        return BadRequest();
//    }

//   // await mapper.Map(menuDto, menu);
//    context.Entry(menuDto).State = EntityState.Modified;
//    await context.SaveChangesAsync();
//    return Ok(mapper.Map<MenuDto>(menu));


//}





//// PUT: api/Menu1/5
//[HttpPut("{id}")]
//public async Task<ActionResult<IEnumerable<MenuDto>>> PutMenu(int id, Menu menu)
//{

//    if (id != menu.Id)
//    {
//        return BadRequest();
//    }

//    context.Entry(menu).State = EntityState.Modified;


//    await context.SaveChangesAsync();

//    var var = await context.Menu.FindAsync(id);
//    return Ok(mapper.Map<MenuDto>(var));
//}
//    }
//}
//[HttpPut("{id}")]
//public async Task<ActionResult<IEnumerable<MenuDto>>> put(int id, MenuDto menuDto)
//{
//    var menu = context.Menu.FindAsync(id);
//    if (id != menuDto.id)
//    {
//        return BadRequest();
//    }

//   // await mapper.Map(menuDto, menu);
//    context.Entry(menuDto).State = EntityState.Modified;
//    await context.SaveChangesAsync();
//    return Ok(mapper.Map<MenuDto>(menu));


//}





//// PUT: api/Menu1/5
//[HttpPut("{id}")]
//public async Task<ActionResult<IEnumerable<MenuDto>>> PutMenu(int id, Menu menu)
//{

//    if (id != menu.Id)
//    {
//        return BadRequest();
//    }

//    context.Entry(menu).State = EntityState.Modified;


//    await context.SaveChangesAsync();

//    var var = await context.Menu.FindAsync(id);
//    return Ok(mapper.Map<MenuDto>(var));
//}



namespace SP19.P05.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        //creating an instance of datacontext
        private readonly DataContext context;

        //creating an instance of Imapper
        private readonly IMapper mapper;


        //creating a constructor for MenusControllerclass
        public MenusController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        //this will get you all the menus form database
        [HttpGet]
        public ActionResult<IEnumerable<MenuDto>> GetAllMenuDto()
        {
            var menu = context.Menu;

            return Ok(mapper.Map<IEnumerable<MenuDto>>(menu));

        }


        //this will get you only the asked id datas from menus 
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MenuDto>>> GetMenuDtoAsync(int id)
        {
            //   return Ok(mapper.Map<IEnumerable<MenuDto>>(cont ext.Menu.FindAsync(id)));
            var dto = await context.Menu.FindAsync(id);

            return Ok(mapper.Map<MenuDto>(dto));


        }


        // this will create new entry in the database from the application
        [HttpPost]
        public async Task<ActionResult<MenuDto>> CreateMenu(MenuDto menuDto)
        {
            var menu = new Menu();

            mapper.Map(menuDto, menu);
            context.Add(menu);
            await context.SaveChangesAsync();
            //t    menuDto.Id = menu.Id;

            return menuDto;

            
        }



       

        [HttpPut("{id}")]
        public async Task<ActionResult<MenuDto>> Put(int id,MenuDto dto)
        {
            var entity = await context.Set<Menu>().FirstOrDefaultAsync(x => x.Id ==id);
            if (entity == null)
            {
                return NotFound();
            }
            mapper.Map(dto, entity);
            await context.SaveChangesAsync();
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await context.Set<Menu>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            context.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}


 