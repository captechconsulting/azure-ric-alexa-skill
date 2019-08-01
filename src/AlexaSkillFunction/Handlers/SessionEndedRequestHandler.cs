﻿using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System.Threading.Tasks;

namespace AlexaSkillFunction.Handlers
{
    public class SessionEndedRequestHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.RequestEnvelope.Request is SessionEndedRequest);
        }

        public Task<Response> Handle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.ResponseBuilder.GetResponse());
        }
    }
}
