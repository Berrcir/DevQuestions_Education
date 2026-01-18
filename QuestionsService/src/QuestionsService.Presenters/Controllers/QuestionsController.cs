using DirectoryService.Presenters.Models.Questions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presenters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionCreateModel model, CancellationToken cancellationToken)
        {
            return Ok("Question created");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QuestionsGetModel model, CancellationToken cancellationToken)
        {
            return Ok("Questions got");
        }

        [HttpGet("{questionId:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid questionId, CancellationToken cancellationToken)
        {
            return Ok("Question got");
        }

        [HttpPut("{questionId:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid questionId,
            [FromBody] QuestionUpdateModel model,
            CancellationToken cancellationToken)
        {
            return Ok("Question updated");
        }

        [HttpDelete("{questionId:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid questionId, CancellationToken cancellationToken)
        {
            return Ok("Question deleted");
        }

        [HttpPut("{questionId:guid}/resolve")]
        public async Task<IActionResult> Resolve(
            [FromRoute] Guid questionId,
            [FromQuery] Guid answerId,
            CancellationToken cancellationToken)
        {
            return Ok("Question resolved");
        }

        [HttpPost("{questionId:guid}/answers")]
        public async Task<IActionResult> AddAnswer(
            [FromRoute] Guid questionId,
            [FromBody] AnswerAddModel model,
            CancellationToken cancellationToken)
        {
            return Ok("Answer added");
        }
    }
}