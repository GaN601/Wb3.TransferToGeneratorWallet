using Nethereum.JsonRpc.Client;
using RateLimiter;

namespace GaN.Web3.Action.Rcl.Interceptor;

public class RequestRateLimiterInterceptor(TimeSpan timeSpan, int limit = 2) : RequestInterceptor
{
    private readonly TimeLimiter _limiter = TimeLimiter.GetFromMaxCountByInterval(limit, timeSpan);

    public override async Task<object> InterceptSendRequestAsync<T>(
        Func<RpcRequest, string, Task<T>> interceptedSendRequestAsync, RpcRequest request, string? route = null)
    {
        // await _limiter;
        return base.InterceptSendRequestAsync(interceptedSendRequestAsync, request, route);
    }
}