using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddictSample.PlatformServices
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
