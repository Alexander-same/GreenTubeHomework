using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Services.Interfaces.Player;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<IEnumerable<PlayerModel>> Get()
        {
            return playerRepository.GetData();
            //return await playerRepository.GetAll();
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerModel>> Get(Guid id)
        {
            return playerRepository.GetData().First();
            //return await playerRepository.GetById(id);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public async Task<ActionResult> Post(PlayerModel player)
        {
            if (player == null || player.Name.Length < 3)
            { return BadRequest(); }

            player.GuidId= Guid.NewGuid();
            var playerData = playerRepository.GetData();
            playerData.Add(player);
            //await playerRepository.Add(player);
            return Ok($"Player {player.GuidId} added");
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] PlayerModel player)
        {
            if (player == null || player?.Name.Length < 3)
            { return BadRequest(); }
            //await playerRepository.Update(player);
            return Ok($"Player {player.GuidId} updated");
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            //var player = await playerRepository.GetById(id);
            //if (player != null)
            //{
            //    await playerRepository.Delete(player);
            //}
            return Ok($"Player {id} deleted");
        }
    }
}
