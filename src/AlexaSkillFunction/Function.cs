using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ask.Sdk.Azure.WebJobs;
using Ask.Sdk.Core.Skill.Factory;
using Ask.Sdk.Azure.WebJobs.Validation;
using AlexaSkillFunction.Handlers;
using Ask.Sdk.Model.Request;
using Newtonsoft.Json;
using System.IO;
using AlexaSkillFunction.Resources;

namespace AlexaSkillFunction
{
    public static class Function
    {
        [FunctionName("AlexaSkillFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [AlexaSkill(RequestHandlers = new [] { typeof(CancelAndStopIntentHandler),
                typeof(HelloWorldIntentHandler),
                typeof(HelpIntentHandler),
                typeof(LaunchRequestHandler),
                typeof(SessionEndedRequestHandler),
                typeof(FallbackIntentHandler)
            })] CustomSkillBuilder builder,
            ILogger log)
        {
            var requestEnvelope = await RequestValidator.ValidateRequest(req);
            if (requestEnvelope == null)
            {
                return new BadRequestResult();
            }

            builder.AddRequestInterceptors((input) =>
            {
                Messages.Culture = Titles.Culture = new System.Globalization.CultureInfo(input
                    .RequestEnvelope.Request.Locale);

                return Task.CompletedTask;
            });

            return new OkObjectResult(await builder.Execute(requestEnvelope));
        }
    }
}
