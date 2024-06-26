

using OpenFaceOffline.Websocket;

namespace OpenFaceOffline.DataFormat
{
    public abstract class AbstractWebsocketPayload
    {
        public abstract string EventName { get; set; }
        public abstract object Data { get; set; }

        public string ToJsonString(WebsocketPayload websocketPayload)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new {EventName = EventName, Data = Data});
        }
    }
}