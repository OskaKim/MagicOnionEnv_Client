using MagicOnion;

namespace OskaKim.Definitions.Sample
{
    public static class ServerDefinitions
    {
        public static GrpcChannelx GetChannelX()
        {
            return GrpcChannelx.ForAddress("http://192.168.10.110:5001");
        }
    }
}
