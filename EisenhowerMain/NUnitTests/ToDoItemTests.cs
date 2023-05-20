using EisenhowerMain;

namespace NUnitTests;

[TestFixture]
public class ToDoItemTests
{
    [Test]
    public void GetTitleFunction_ShouldReturn_EqualTitle()
    {
        //Arrange
        string expectedTitle = "task title";
        TodoItem todoItem = new TodoItem(expectedTitle, DateTime.Now);

        //Act
        string actualTitle = todoItem.GetTitle();

        //Assert
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
    }

    [Test]
    public void GetDeadlineFunction_ShouldReturn_EqualDeadline()
    {
        //Arrange
        DateTime expectedDeadline = DateTime.Now;
        TodoItem todoItem = new TodoItem("2137", expectedDeadline);

        //Act
        DateTime actualDeadline = todoItem.GetDeadline();

        //Assert
        Assert.That(actualDeadline, Is.EqualTo(expectedDeadline));
    }

    [Test]
    public void MarkFunction_ShouldReturn_True()
    {
        //Arrange
        TodoItem todoItem = new TodoItem("Rzeczy", DateTime.Now);

        //Act
        todoItem.Mark();

        //Assert
        Assert.That(todoItem.GetStatus, Is.True);
    }

    [Test]
    public void UnmarkFunction_ShouldReturn_False()
    {
        //Arrange
        TodoItem todoItem = new TodoItem("JP2", DateTime.Now);

        //Act
        todoItem.Unmark();

        //Assert
        Assert.That(todoItem.GetStatus, Is.False);
    }

    [Test]
    public void ToStringFunctionOfDoneItem_ShouldReturn_ProperlyFormattedString()
    {
        //Arrange
        string title = "Done Item";
        DateTime dateTime = DateTime.Now;
        string formattedDate = dateTime.ToString("d-M");
        string doneStatus = "{x}";
        string expected = $"{doneStatus} {formattedDate} {title}";

        TodoItem todoItemDone = new TodoItem(title, dateTime);

        //Act
        todoItemDone.Mark();
        string actual = todoItemDone.ToString();

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void ToStringFunctionOfUoneItem_ShouldReturn_ProperlyFormattedString()
    {
        //Arrange
        string title = "Undone Item";
        DateTime dateTime = DateTime.Now;
        string formattedDate = dateTime.ToString("d-M");
        string doneStatus = "{ }";
        string expected = $"{doneStatus} {formattedDate} {title}";

        TodoItem todoItemDone = new TodoItem(title, dateTime);

        //Act
        todoItemDone.Unmark();
        string actual = todoItemDone.ToString();

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}