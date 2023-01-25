using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace jmantillaS7
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnnection();
    }
}
