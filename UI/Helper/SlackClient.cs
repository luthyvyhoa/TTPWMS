using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Collections.Generic;

//A simple C# class to post messages to a Slack channel  
//Note: This class uses the Newtonsoft Json.NET serializer available via NuGet  
public class SlackClientOld
{
    private readonly Uri _uri;
    private readonly Encoding _encoding = new UTF8Encoding();

    public SlackClientOld(string urlWithAccessToken)
    {
        _uri = new Uri(urlWithAccessToken);
    }

    //Post a message using simple strings  
    //public void PostMessage(string text, string username = null, string channel = null)
    public void PostMessage(string text, string username = null, string channel = null)
    {
        Payload payload = new Payload()
        {
            Channel = channel,
            Username = username,
            Text = text
        };

        PostMessageP(payload);
    }



    //Post a message using a Payload object  
    public void PostMessageP(Payload payload)
    {
        string payloadJson = JsonConvert.SerializeObject(payload);

        using (WebClient client = new WebClient())
        {
            NameValueCollection data = new NameValueCollection();
            data["payload"] = payloadJson;

            var response = client.UploadValues(_uri, "POST", data);

            //The response text is usually "ok"  
            string responseText = _encoding.GetString(response);
        }
    }

    
}

//This class serializes into the Json payload required by Slack Incoming WebHooks  
public class Payload
{
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
}


public class SendSlackAttachement
{
    //SendSlackMessage("https://hooks.slack.com/services/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", "Customer Inquiry No. " + this.txtInquiryNumber.EditValue.ToString() + " | " + this.lkeCustomers.EditValue.ToString() + 
    //   " | " + txtCustomerName.EditValue + " is updated !","WMS");

    
    //var slackClient = new SlackClient("https://hooks.slack.com/services/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");


    //var slackMessage = new SlackMessage
    //{
    //    Channel = "#random",
    //    Text = "This is the test message with attachment",
    //    IconEmoji = Emoji.Ghost,
    //    Username = "nerdfury"
    //};


    //slackMessage.Markdown = false;
    //            var slackAttachment = new SlackAttachment
    //            {
    //                //Fallback = "New open task [Urgent]: <http://url_to_task|Test out Slack message attachments>",
    //                Text = "New open task *[Urgent]*: <http://url_to_task|Test out Slack message attachments>",
    //                Color = "#D00000",
    //                Fields =
    //                        new List<SlackField>
    //                            {
    //                            new SlackField
    //                                {
    //                                    Title = "Notes",
    //                                    Value = "This is much *easier* than I thought it would be."
    //                                }
    //                            }
    //            };
    //slackMessage.Attachments = new List<SlackAttachment> { slackAttachment };

    //            slackClient.Post(slackMessage);
}
