namespace PROXY_PATTERN;




public class ExpensiveToLoad
{
    public virtual List<object> List { get; protected set; }

    protected ExpensiveToLoad()
    {
        Helper.Log("ExpensiveToLoad Contructor called.");
    }

    public static ExpensiveToLoad Create()
    {
        return new VirtualExpensiveToLoad();
    }
}


//Without lazy
public class VirtualExpensiveToLoad : ExpensiveToLoad
{
    public override List<object> List
    {
        get
        {
            if (base.List == null || base.List.Any() == false)
            {
                base.List = Helper.GetLargeData();
            }
            return base.List;
        }
        protected set => base.List = value;
    }
}

// With lazy
public class VirtualLazyExpensiveToLoad : ExpensiveToLoad
{
    private Lazy<List<object>> _lazy;

    public override List<object> List { get { return _lazy.Value; } }

    public VirtualLazyExpensiveToLoad()
    {
        Helper.Log("VirtualLazyExpensiveToLoad Contructor called.");

        _lazy = new Lazy<List<object>>(() => Helper.GetLargeData());
    }
}