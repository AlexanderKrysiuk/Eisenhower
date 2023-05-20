using EisenhowerMain;

namespace NUnitTests;

[TestFixture]
public class ToDoItemTests
{
    [Test]
    public void GetTitle_ShouldReturn_Title()
    {
        //Arrange
        string expectedTitle = "task title";
        TodoItem todoItem = new TodoItem(expectedTitle, DateTime.Now);

        //Act
        string actualTitle = todoItem.Get_title();

        //Assert
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
    }

    [Test]
    public void GetDeadline_ShouldReturn_Deadline()
    {
        //Arrange
        DateTime expectedDeadline = DateTime.Now;
        TodoItem todoItem = new TodoItem("2137", expectedDeadline);

        //Act
        DateTime actualDeadline = todoItem.Get_deadline();

        //Assert
        Assert.That(actualDeadline, Is.EqualTo(expectedDeadline));
    }

    [Test]
    public void MarkedItem_ShouldReturn_True()
    {
        //Arrange
        TodoItem todoItem = new TodoItem("Rzeczy", DateTime.Now);

        //Act
        todoItem.Mark();

        //Assert
        Assert.That(todoItem.Get_Status, Is.True);
    }

    [Test]
    public void UnmarkedItem_ShouldReturn_False()
    {
        //Arrange
        TodoItem todoItem = new TodoItem("JP2", DateTime.Now);

        //Act
        todoItem.Unmark();

        //Assert
        Assert.That(todoItem.Get_Status, Is.EqualTo(false));
    }

    [Test]
    public void ToString_ShouldReturn_FormateDstring()
    {
        //Arrange
        string title = "Smocze Jaja";
        DateTime dateTime = DateTime.Now;
        string doneStatus = "{x}";
        string undoneStatus = "{ }";
        string formattedDate = dateTime.ToString("d-M");
        string expectedDoneItemString = $"{doneStatus} {formattedDate} {title}";
        string expectedUndoneItemString = $"{undoneStatus} {formattedDate} {title}";
        
        TodoItem todoItemDone = new TodoItem(title, dateTime);
        TodoItem todoItemUndone = new TodoItem(title, dateTime);
        
        //Act
        todoItemDone.Mark();
        string actualDoneItemString = todoItemDone.ToString();
        string actualUndoneItemString = todoItemUndone.ToString();
        
        //Assert
        Assert.That(actualDoneItemString, Is.EqualTo(expectedDoneItemString));
        Assert.That(actualUndoneItemString, Is.EqualTo(expectedUndoneItemString));

    }

}