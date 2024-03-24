using Nethereum.JsonRpc.Client;
using Nethereum.Web3.Accounts;

namespace GaN.Web3.Action.Rcl.Factory;

public class Web3Factory
{
    /// <summary>
    /// TODO FIXME interceptor impact request, throw Cas exception
    /// </summary>
    /// <param name="account"></param>
    /// <param name="rpc"></param>
    /// <param name="interceptor"></param>
    /// <returns></returns>
    public static Nethereum.Web3.Web3 Build(Account account, String rpc, RequestInterceptor? interceptor = default)
    {
        var web3 = new Nethereum.Web3.Web3(account, rpc)
        {
            Client =
            {
                OverridingRequestInterceptor = interceptor
            }
        };

        return web3;
    }
}