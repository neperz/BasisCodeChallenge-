﻿using System.Data.Common;

namespace Basis.CodeChallenge.Infra.Context;

public class DapperContext
{
    private readonly DbConnection _conn;

    public DapperContext(DbConnection conn)
    {
        _conn = conn;
    }

    public DbConnection DapperConnection
    {
        get
        {
            return _conn;
        }
    }
}

