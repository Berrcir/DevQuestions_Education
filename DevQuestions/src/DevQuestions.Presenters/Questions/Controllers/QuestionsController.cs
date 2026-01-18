using DevQuestions.Application.Questions;
using DevQuestions.Contracts.Questions;
using DevQuestions.Presenters.Questions.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters.Questions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionCreateDto request, CancellationToken cancellationToken)
        {
            Guid questionId = await _questionsService.Create(request, cancellationToken);
            return Ok(questionId);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QuestionsGetDto request, CancellationToken cancellationToken)
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
            [FromBody] QuestionUpdateDto request,
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
            [FromBody] AnswerAddDto request,
            CancellationToken cancellationToken)
        {
            return Ok("Answer added");
        }
    }
}