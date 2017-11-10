/* DataAccess Pattern */

This Layer is to isolate the data connection from the application.

/*
Singleton Implementation
*/
public static class SingletonDBContext
{
    private static DataModelContainer _context;

    public static DataModelContainer GetContext()
    {
        if (_context == null)
        {
            _context = new DataModelContainer();
        }

        return _context;
    }
}

/*
Factory Implementation
*/
public static IPackage CreatePackageInstace()
{
    var package = new PackageEntity() { };

    return package;
}

public static IPackage CreatePackageServiceInstace(IPackage package, int serviceType)
{
    if (serviceType == (int)ServiceType.HonneyMoon)
    {
        package = new HoneyMoonPackage(package);
    }
    else if (serviceType == (int)ServiceType.BachelorPartyHoliday)
    {
        package = new BachelorPartyPackage(package);
    }
    if (serviceType == (int)ServiceType.BirthDayParty)
    {
        package = new BirthDayPartyPackage(package);
    }

    return package;
}