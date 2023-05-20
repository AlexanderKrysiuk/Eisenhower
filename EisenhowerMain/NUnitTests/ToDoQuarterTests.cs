using EisenhowerMain;

namespace NUnitTests;

public class ToDoQuarterTests
{
    [Test]
    public void AddItemFunction_ShouldReturn_ListWithAddedItem()
    {
        //Arrange
        string title = "Test";
        DateTime dateTime = DateTime.Now;
        
        var actualQuarter = new TodoQuarter();
        var expectedList = new List<TodoItem>{new(title,dateTime)};

        //Act
        actualQuarter.AddItem(title,dateTime);
        var actualList = actualQuarter.GetItems();

        //Assert
        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void RemoveItemFunction_ShouldReturn_EmptyListAfterRemovingItem()
    {
        string title = "Test";
        DateTime dateTime = DateTime.Now;
        var actualQuarter = new TodoQuarter();
        actualQuarter.AddItem(title,dateTime);
        var expectedList = new List<TodoItem>();
        
        //Act
        actualQuarter.RemoveItem(0);
        var actualList = actualQuarter.GetItems();
        
        //Assert
        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void ArchiveAllFunction_ShouldReturn_ListWithOnlyUnmarkedItems()
    {
        //Arrange
        string title = "Test";
        DateTime dateTime = DateTime.Now;
        
        var actualQuarter = new TodoQuarter();
        actualQuarter.AddItem(title,dateTime);
        actualQuarter.AddItem(title,dateTime.AddDays(1));
        actualQuarter.GetItem(1).Mark();
        
        var expectedList = new List<TodoItem>() {new(title, dateTime)};
        
        //Act
        actualQuarter.ArchiveItems();
        var actualList = actualQuarter.GetItems();
        
        //Assert
        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void GetItemFunction_ShouldReturn_EqualTodoItem()
    {
        string title = "Test";
        DateTime dateTime = DateTime.Now;

        var actualQuarter = new TodoQuarter();
        actualQuarter.AddItem(title,dateTime);
        
        var expectedItem = new TodoItem(title,dateTime);
        
        //Act
        var actualItem = actualQuarter.GetItem(0);
        
        //Assert
        Assert.That(actualItem, Is.EqualTo(expectedItem));
    }

    [Test]
    public void GetItemsFunction_ShouldReturn_ListWithAddedItems()
    {
        //Arrange
        string title = "Test";
        DateTime dateTime = DateTime.Now;

        var actualQuarter = new TodoQuarter();
        actualQuarter.AddItem(title,dateTime);

        var expectedList = new List<TodoItem>{ new(title, dateTime) };
        
        //Act
        var actualList = actualQuarter.GetItems();
        
        //Assert
        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void ToStringFunction_ShouldReturn_EqualStrings()
    {
        //Arrange
        string title = "Test";
        DateTime dateTime = DateTime.Now;
        string formattedDateTime = dateTime.ToString("d-M");
        string doneStatus = "{ }";

        var actualQuarter = new TodoQuarter();
        actualQuarter.AddItem(title,dateTime);

        string expectedString =  $"{doneStatus} {formattedDateTime} {title}";
        expectedString.TrimEnd();
        
        //Act
        string actualString = actualQuarter.ToString();
        
        //Assert
        Assert.That(actualString, Is.EqualTo(expectedString));
    }
}