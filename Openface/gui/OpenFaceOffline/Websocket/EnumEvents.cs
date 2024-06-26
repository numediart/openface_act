
namespace OpenFaceOffline.Websocket
{
    public class EnumEvents:Enumeration<EnumEvents>
    {
        private static int _nextValue = 1;
        private static int
            GetNextValue() // allow to have dynamic value for enum value if need to add more enum or change the order  as using in most cases the name of the enum instead of the value so the value is not that important
        {
            return _nextValue++;
        }
        
        public static readonly EnumEvents ClientConnected = new EnumEvents(GetNextValue(), "ClientConnected");
        public static readonly EnumEvents EmitActionUnit = new EnumEvents(GetNextValue(), "EmitActionUnit");
        public static readonly EnumEvents EmitAudioData= new EnumEvents(GetNextValue(), "EmitAudioData");
        public static readonly EnumEvents OnRoomId = new EnumEvents(GetNextValue(), "OnRoomId");
        
        public EnumEvents(int value, string name) : base(value, name)
        {
        }
    }
}