using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBot2.Bots
{
    public class AttachmentsBot
    {
        private static async Task DisplayOptionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            // Create a HeroCard with options for the user to interact with the bot.
            var card = new HeroCard
            {
                Text = "You can upload an image or select one of the following choices",
                Buttons = new List<CardAction>
        {
            // Note that some channels require different values to be used in order to get buttons to display text.
            // In this code the emulator is accounted for with the 'title' parameter, but in other channels you may
            // need to provide a value for other parameters like 'text' or 'displayText'.
            new CardAction(ActionTypes.ImBack, title: "1. Inline Attachment", value: "1"),
            new CardAction(ActionTypes.ImBack, title: "2. Internet Attachment", value: "2"),
            new CardAction(ActionTypes.ImBack, title: "3. Uploaded Attachment", value: "3"),
        },
            };

            var reply = MessageFactory.Attachment(card.ToAttachment());
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }
    }
}
