// See https://aka.ms/new-console-template for more information
using PROXY_PATTERN;

Console.WriteLine("PROXY PATTERN");



VirtualProxyTest();





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