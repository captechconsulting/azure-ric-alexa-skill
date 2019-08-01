using AlexaSkillFunction.Resources;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System.Threading.Tasks;

namespace AlexaSkillFunction.Handlers
{
    public class LaunchRequestHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest);
        }

        public Task<Response> Handle(IHandlerInput input)
        {
            var speechText = Messages.Launch;
            return Task.FromResult(input.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard(Titles.Launch, speechText)
                .GetResponse());

        }
    }
}
