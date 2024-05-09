using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TestApp.Models;
using TestApp.Services.Interfaces;
using TestApp.Services.Transaction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public readonly IMemoryCache memoryCache;
        private readonly ITransactionRepository transactionRepository;
        private readonly TransactionProcessor transactionProcessor;

        public TransactionController(IMemoryCache memoryCache, ITransactionRepository transactionRepository, TransactionProcessor transactionProcessor)
        {
            this.memoryCache = memoryCache;
            this.transactionRepository = transactionRepository;
            this.transactionProcessor = transactionProcessor;
        }


        // GET: api/<TransactionController>
        [HttpGet]
        public async Task<IEnumerable<TransactionModel>> GetAll()
        {
            return transactionRepository.GetData();
            //return await transactionRepository.GetAll();
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionModel>> Get(Guid id)
        {
            return transactionRepository.GetData().First();
            //return await transactionRepository.GetById(id);
        }

        // POST api/<TransactionController>
        [HttpPost]
        public async Task<ActionResult> Post(TransactionModel transaction)
        {
            if(memoryCache.TryGetValue(
                transaction.PlayerId.ToString() + transaction.Amount + transaction.TransactionType,
                out var cachedTransactionResponse))
            {
                return Ok($"Transaction {cachedTransactionResponse}");
            }

            var transactionResponse = await transactionProcessor.ProcessTransaction(transaction);
            memoryCache.Set(
                transaction.PlayerId.ToString() + transaction.Amount + transaction.TransactionType,
                transactionResponse,
                DateTimeOffset.Now.AddSeconds(60));

            return Ok(transactionResponse);
        }
    }
}
