using EisenhowerMain;

namespace NUnitTests;

[TestFixture]
public class ToDoMatrixTests
{
    [Test]
    public void GetQuartersFunction_ShouldReturn_DictionaryWithFourQuarters()
    {
        //Arrange
        var expectedDictionary = new Dictionary<string, TodoQuarter>();
        expectedDictionary.Add("IU", new TodoQuarter());
        expectedDictionary.Add("IN", new TodoQuarter());
        expectedDictionary.Add("NU", new TodoQuarter());
        expectedDictionary.Add("NN", new TodoQuarter());

        var matrix = new TodoMatrix();

        //Act
        var actualDictionary = matrix.GetQuarters();

        //Assert
        Assert.That(actualDictionary, Is.EqualTo(expectedDictionary));
    }

    [Test]
    public void GetQuarterFunction_ShouldReturn_QuarterWithSpecifiedStatus()
    {
        //Arrange
        var matrix = new TodoMatrix();

        string statusIU = "IU";
        string statusIN = "IN";
        string statusNU = "NU";
        string statusNN = "NN";

        TodoQuarter expectedQuarterIU = new TodoQuarter();
        TodoQuarter expectedQuarterIN = new TodoQuarter();
        TodoQuarter expectedQuarterNU = new TodoQuarter();
        TodoQuarter expectedQuarterNN = new TodoQuarter();

        //Act
        var actualQuarterIU = matrix.GetQuarter(statusIU);
        var actualQuarterIN = matrix.GetQuarter(statusIN);
        var actualQuarterNU = matrix.GetQuarter(statusNU);
        var actualQuarterNN = matrix.GetQuarter(statusNN);

        //Assert
        Assert.That(actualQuarterIU, Is.EqualTo(expectedQuarterIU));
        Assert.That(actualQuarterIN, Is.EqualTo(expectedQuarterIN));
        Assert.That(actualQuarterNU, Is.EqualTo(expectedQuarterNU));
        Assert.That(actualQuarterNN, Is.EqualTo(expectedQuarterNN));
    }

    [Test]
    public void AddItemFunction_ShouldReturn_QuarterWithItem()
    {
        //Arrange
        var matrix = new TodoMatrix();
        
        string title = "Test";
        DateTime dateTime = DateTime.Now.AddDays(1);
        string QuarterStatus = "IU";

        TodoQuarter expectedQuarter = new TodoQuarter();
        expectedQuarter.AddItem(title,dateTime);
        
        //Act
        matrix.AddItem(title,dateTime,true);
        TodoQuarter actualQuarter = matrix.GetQuarter(QuarterStatus);
        
        //Assert
        Assert.That(actualQuarter, Is.EqualTo(expectedQuarter));
    }

}