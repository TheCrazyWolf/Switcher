using System.Net.NetworkInformation;

namespace Switcher.Models.Network;

public class NetworkAdapter : NetworkInterface
{
    private readonly NetworkInterface _networkInterface;

    public NetworkAdapter(NetworkInterface networkInterface)
    {
        _networkInterface = networkInterface;
    }

    public override string Id => _networkInterface.Id;
    public override string Name => _networkInterface.Name;
    public override string Description => _networkInterface.Description;
    public override OperationalStatus OperationalStatus => _networkInterface.OperationalStatus;
    public override long Speed => _networkInterface.Speed;
    public override NetworkInterfaceType NetworkInterfaceType => _networkInterface.NetworkInterfaceType;
    public override bool SupportsMulticast => _networkInterface.SupportsMulticast;
    public override bool IsReceiveOnly  => _networkInterface.IsReceiveOnly;
}