using GaN.Web3.Action.Rcl.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GaN.Web3.Action.Rcl.Expand;

public static class DiExpand
{
    public static IServiceCollection AddCustomDi(this IServiceCollection collection)
    {
        return collection.AddSingleton<TransferService>();
    }
}