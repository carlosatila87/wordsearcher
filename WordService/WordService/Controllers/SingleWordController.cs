using Microsoft.AspNetCore.Mvc;
using WordService.Repository;

namespace WordService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleWordController : ControllerBase
    {
        private readonly ISingleWordRepository _singleWordRepository;

        public SingleWordController(ISingleWordRepository singleWordRepository)
        {
            _singleWordRepository = singleWordRepository;
        }

        [HttpGet("search/{word}")]
        public IActionResult Search(string word)
        {
            if (!_singleWordRepository.SearchWord(word))
            {
                return NotFound();
            }                
            return Ok();
        }

        [HttpPost("update/")]
        public IActionResult Update([FromBody]string word)
        {
            _singleWordRepository.AddWord(word);
            return Ok();
        }

        [HttpGet("listtop5/")]
        public IActionResult ListTop5()
        {
            var singleWords = _singleWordRepository.GetTop5();
            return new OkObjectResult(singleWords);
        }
    }
}
