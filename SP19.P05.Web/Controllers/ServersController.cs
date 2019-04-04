using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Authorization;
using SP19.P05.Web.Features.Server;

namespace SP19.P05.Web.Controllers
{
    public class ServersController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ServersController(DataContext dataContext, IMapper mapper, UserManager<User> userManager)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServerDto>>> Get()
        {
            var entityQueryable = dataContext.Set<Server>();
            var dtoQuearyable = mapper.ProjectTo<ServerDto>(entityQueryable);
            var itemDtos = await dtoQuearyable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPost]
        public async Task<ActionResult<ServerDto>> PostAsync(CreateServerDto dto)
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
                await userManager.AddToRoleAsync(user, UserRoles.Server);
                var server = new Server
                {
                    User = user
                };
                mapper.Map(dto, server);
                dataContext.Add(server);
                await dataContext.SaveChangesAsync();

                var result = mapper.Map<ServerDto>(dto);
                result.Id = server.Id;
                transaction.Commit();
                return result;
            }
        }

    }
}
