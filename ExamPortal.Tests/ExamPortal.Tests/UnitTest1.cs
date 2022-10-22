using ExamPortal.Extensions;
using Xunit.Abstractions;

namespace ExamPortal.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;
    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var connectionFactory = new MsSqlDbConnectionFactory("Server=192.168.42.100;Database=Wesco Engineering Services;User Id=sa;Password=RevoTech@77!;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
    [Fact]
    public void Test1()
    {
    }
}