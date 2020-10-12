namespace TestProj.Data
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();

    }
}
