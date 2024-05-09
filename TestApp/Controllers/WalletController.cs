using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Services.Interfaces.Wallet;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletReporitory walletRepository;
        private readonly IWalletService walletService;
        public WalletController(IWalletReporitory walletRepository, IWalletService walletService)
        {
            this.walletRepository = walletRepository;
            this.walletService = walletService;
        }

        // GET: api/<WalletController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WalletModel>> GetById(Guid id)
        {
            return walletRepository.GetData().First();
            //return await walletRepository.GetById(id);
        }

        // GET api/<WalletController>/wallet-history/5
        [HttpGet("wallet-history/{id}")]
        public async Task<ActionResult<ICollection<TransactionModel>>> GetTransactionsByWalletId(Guid id)
        {
            return Ok(await walletService.GetAllWalletTransactions(id));
        }

        // POST api/<WalletController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WalletModel wallet)
        {
            if (wallet == null) return BadRequest();
            var walletData = walletRepository.GetData();

            wallet.GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            walletData.Add(wallet);

            //await walletRepository.Add(wallet);
            return Ok($"Wallet {wallet.GuidId} added");
        }
    }
}
