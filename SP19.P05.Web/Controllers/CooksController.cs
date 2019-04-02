using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Authorization;
using SP19.P05.Web.Features.Cook;


namespace SP19.P05.Web.Controllers
{
    public class CooksController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CooksController(DataContext dataContext, IMapper mapper, UserManager<User> userManager)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<CookDto>>> Get()
        {
            var entityQueryable = dataContext.Set<Cook>();
            var dtoQuearyable = mapper.ProjectTo<CookDto>(entityQueryable);
            var itemDtos = await dtoQuearyable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPost]
        public async Task<ActionResult<CookDto>> PostAsync(CreateCookDto dto)
        {
            using (var transaction = await dataContext.Database.BeginTransactionAsync())
            {
                var user = new User();
                mapper.Map(dto, user);
                var identityResult = await userManager.CreateAsync(user, dto.Password);
                if (!identityResult.Succeeded)
                {
                    return BadRequest(identityResult.Errors);   
                }
                await userManager.AddToRoleAsync(user, UserRoles.Cook);
                var cook = new Cook
                {
                    User = user
                };
                mapper.Map(dto, cook);
                dataContext.Add(cook);
                await dataContext.SaveChangesAsync();

                var result = mapper.Map<CookDto>(dto);
                result.Id = cook.Id;
                transaction.Commit();
                return result;
            }
        }
        
    }
}
