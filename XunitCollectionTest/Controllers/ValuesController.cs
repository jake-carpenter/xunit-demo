using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace XunitCollectionTest.Controllers
{
    public static class Connection
    {
        public static string String = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;";
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase, IDisposable
    {
        private readonly SqlConnection _conn;

        public ValuesController()
        {
            _conn = new SqlConnection(Connection.String);
        }

        public void Dispose()
        {
            _conn.Dispose();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return _conn.QueryFirst<string>(
                "SELECT Value FROM dbo.Todo WHERE Id = @id"
                , new { id });
        }
    }
}
