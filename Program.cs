// See https://aka.ms/new-console-template for more information
using PROXY_PATTERN;

Console.WriteLine("PROXY PATTERN");



VirtualProxyTest();


await RemoteProxyTest("",new());





// Virtual Proxy
static void VirtualProxyTest()
{
    var expensiveToLoad = ExpensiveToLoad.Create();

    Console.WriteLine("Created.");

    var list = expensiveToLoad.List;

    Console.WriteLine(list.Count);

    expensiveToLoad = new VirtualLazyExpensiveToLoad();

    Console.WriteLine("Created.");

    list = expensiveToLoad.List;

    Console.WriteLine(list.Count);
}

// Remote Proxy Generated With NSwag
static async Task RemoteProxyTest(string baseUrl,HttpClient httpClient)
{
    RemoteProxy remoteProxy = new(baseUrl, httpClient);
    var response = await remoteProxy.OnDutyPharmaciesAsync();
}