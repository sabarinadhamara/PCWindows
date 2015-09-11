using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;

namespace PCWINDOWS.ComponentProperties
{
    [Table]
public class comptype
{
    [Column(IsDbGenerated = true, IsPrimaryKey = true)]
    public int srno
    {
        get;
        set;
    }
    [Column]
    public string descp
    {
        get;
        set;
    }
    
}

     
}
