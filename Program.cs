// See https://aka.ms/new-console-template for more information
using PROXY_PATTERN;

Console.WriteLine("PROXY PATTERN");


// VirtualProxyTest();


// await RemoteProxyTest("",new());


// SmartProxyTest();



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

// Remote Proxy (Generated With NSwag)
static async Task RemoteProxyTest(string baseUrl,HttpClient httpClient)
{
    RemoteProxy remoteProxy = new(baseUrl, httpClient);
    var response = await remoteProxy.OnDutyPharmaciesAsync();
}

// Smart Proxy
static void SmartProxyTest()
{
    string workingDirectory = Environment.CurrentDirectory;
    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
    string filePath = Path.Combine(projectDirectory, "info.txt");
    DefaultFile defaultFile_a = new();
    SmartProxyFile smartFile_a = new();
    FileStream defaultStream = null;
    FileStream smartStream = null;
    try
    {
        defaultStream = defaultFile_a.OpenStream(filePath);
        defaultStream = defaultFile_a.OpenStream(filePath);
    }
    catch (System.IO.IOException ex)
    {
        Console.WriteLine(ex);
        defaultStream.Close();
    }


    try
    {
        smartStream = smartFile_a.OpenStream(filePath);
        smartStream = smartFile_a.OpenStream(filePath);
    }
    catch (System.IO.IOException ex)
    {
        Console.WriteLine(ex);
    }
    finally
    {
        smartStream.Close();
    }
}