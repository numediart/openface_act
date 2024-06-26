#nullable enable
using OpenFaceOffline.Websocket;

namespace OpenFaceOffline.DataFormat
{
    public class WebsocketPayload:AbstractWebsocketPayload
    {
        public sealed override string EventName { get; set; }
        public sealed override object? Data { get; set; }
        
        public WebsocketPayload(string eventName, object message)
        {
            this.EventName = eventName;
            this.Data = message;
        }
        
        public new string ToJsonString(WebsocketPayload websocketPayload)
        {
      
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { EventName = EventName, Data = Data});
        }
    }
}