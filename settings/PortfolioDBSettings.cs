
using System.Collections.Generic;

namespace GeneralDB.Settings;

public class GeneralDBSettings
{
    public string? connectionString { get; set; }
    public string? DatabaseName { get; set; }
    public Dictionary<string,string>? collectionName { get; set; }

}
