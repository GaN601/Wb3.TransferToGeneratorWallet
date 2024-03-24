using System.Numerics;
using Nethereum.Contracts.Standards.ERC20.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;

namespace GaN.Web3.Action.Rcl.Service;

public class TransferService
{
    public async Task<TransactionReceipt> ExecCoinBaseTransferAsync(Nethereum.Web3.Web3 signatureWeb3, string toAddress,
        decimal amount)
    {
        return await signatureWeb3.Eth.GetEtherTransferService()
            .TransferEtherAndWaitForReceiptAsync(toAddress, amount);
    }

    public async Task<TransactionReceipt> ExecErc20TransferAsync(Nethereum.Web3.Web3 signatureWeb3, string tokenAddress,
        string toAddress, BigInteger amount
    )
    {
        var firstTx = new TransferFunction
        {
            To = toAddress,
            AmountToSend = amount,
        };
        var handler = signatureWeb3.Eth.GetContractTransactionHandler<TransferFunction>();
        return await handler.SendRequestAndWaitForReceiptAsync(tokenAddress, firstTx);
    }
}