using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Data
{
    public static class SulsDbSettings
    {
        public const string connectionString =
                        @"Server=.\SQLEXPRESS;Database=SulsDb;Trusted_Connection=True;Integrated Security=True;";
    }
}
