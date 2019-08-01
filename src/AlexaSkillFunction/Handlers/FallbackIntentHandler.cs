using AlexaSkillFunction.Resources;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexaSkillFunction.Handlers
{
    public class FallbackIntentHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == BuiltInIntent.Fallback);
            }

            return Task.FromResult(false);
        }

        public Task<Response> Handle(IHandlerInput handlerInput)
        {
            var speechText = Messages.Fallback;
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard(Titles.Fallback, speechText)
                .Reprompt(speechText)
                .GetResponse());
        }
    }
}
