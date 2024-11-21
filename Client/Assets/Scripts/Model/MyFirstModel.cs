using Cysharp.Net.Http;
using Cysharp.Threading.Tasks;
using Grpc.Net.Client;
using MagicOnion.Client;
using Shared.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyFirstModel : BaseModel
{
    // Start is called before the first frame update
    async void Start()
    {
        int result = await Sum(100, 323);

        Debug.Log(result);
    }

    public async UniTask<int> Sum(int x, int y)
    {
        using var handler = new YetAnotherHttpHandler() { Http2Only = true };
        var channel = GrpcChannel.ForAddress(
            ServerUrl, new GrpcChannelOptions() { HttpHandler = handler });
        var client = MagicOnionClient.Create<IMyFirstService>(channel);
        var result = await client.SumAsync(x, y);
        return result;
    }
}
