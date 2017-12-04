using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Summary description for Class1
/// </summary>


public class SearchPackage
{
    public string SearchPackage1()
    { return "SearchPackage, SearchPackage1\n"; }

    //
    // TODO: Add constructor logic here
    //
}

public class ViewPackage
{
    public string ViewPackage1()
    { return "ViewPackage,ViewPackage1\n"; }
}
public class facade
{
    SearchPackage a = new SearchPackage();
    ViewPackage b = new ViewPackage();
    public void BuyPackage()
    {
        Console.WriteLine("BuyPackage\n" + a.SearchPackage1() + b.ViewPackage1());
    }
}