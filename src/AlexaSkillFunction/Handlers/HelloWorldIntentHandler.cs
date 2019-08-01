using AlexaSkillFunction.Resources;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System.Threading.Tasks;

namespace AlexaSkillFunction.Handlers
{
    public class HelloWorldIntentHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == "HelloWorldIntent");
            }

            return Task.FromResult(false);
        }

        public Task<Response> Handle(IHandlerInput handlerInput)
        {
            var name = "";
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                name = intent.Intent.Slots["Name"]?.Value;
            }
            var speechText = $"{Messages.Hello} {name}";
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard(Titles.Hello, speechText)
                .GetResponse());
        }
    }
}
