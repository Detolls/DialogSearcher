using DialogSearcher.WebAPI.Services;

namespace DialogSearcher.Tests;

[TestFixture]
public class MessengerServiceTests
{
    private MessengerService _messengerService;

    private static readonly object[] searchDialogByClientIdsTestData =
    {
        // case 1
        new object[]
        {
            new Guid[]
            {
                new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151")
            },
            Guid.Empty
        },
        
        // case 2
        new object[]
        {
            new Guid[]
            {
                new Guid("50454d55-a73c-4cbc-be25-3c5729dcb82b")
            },
            Guid.Empty
        },
        
        // case 3
        new object[]
        {
            new Guid[]
            {
                new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"),
                new Guid("7de3299b-2796-4982-a85b-2d6d1326396e")
            },
            Guid.Empty
        },
        
        // case 4
        new object[]
        {
            new Guid[]
            {
                new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"),
                new Guid("7de3299b-2796-4982-a85b-2d6d1326396e"),
                new Guid("0a58955e-342f-4095-88c6-1109d0f70583")
            },
            Guid.Empty
        },
        
        // case 5
        new object[]
        {
            new Guid[]
            {
                new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151"),
                new Guid("50454d55-a73c-4cbc-be25-3c5729dcb82b")
            },
            Guid.Empty
        },
        
        // case 6
        new object[]
        {
            new Guid[]
            {
                new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151"),
                new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"),
            },
            new Guid("19f6f751-7f8d-41fa-8261-709028650592")
        },
        
        // case 7
        new object[]
        {
            new Guid[]
            {
                new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151"),
                new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"),
                new Guid("7de3299b-2796-4982-a85b-2d6d1326396e")
            },
            new Guid("fcd6b112-1834-4420-bee6-70c9776f6378")
        },
        
        // case 8
        new object[]
        {
            new Guid[]
            {
                new Guid("7de3299b-2796-4982-a85b-2d6d1326396e"),
                new Guid("0a58955e-342f-4095-88c6-1109d0f70583"),
                new Guid("50454d55-a73c-4cbc-be25-3c5729dcb82b")
            },
            new Guid("83ebeb2b-c315-48a2-b6e5-f0324de57a9f")
        },
    };
    
    [SetUp]
    public void Setup()
    {
        _messengerService = new MessengerService();
    }

    [Test]
    [TestCaseSource("searchDialogByClientIdsTestData")]
    public void SearchDialogByClientIds_Test(Guid[] clientIds, Guid expectedResult)
    {
        Guid actualResult = default;
        Assert.DoesNotThrow(() =>
        {
            actualResult = _messengerService.SearchDialogByClientIds(clientIds);
        });
        Assert.AreEqual(expectedResult, actualResult);
    }
}