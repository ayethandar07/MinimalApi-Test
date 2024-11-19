using Microsoft.EntityFrameworkCore;
using MinimalApiTest.Model;

namespace MinimalApiTest;

class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

}