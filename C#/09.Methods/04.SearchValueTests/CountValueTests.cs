using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CountValueTests
{
    [TestMethod]
    public void CountValue_IsArrayNull()
    {
        var actual = SearchNumberInArray.CountValue(null, 4);
        Assert.AreEqual(0, actual);
    }
    
    [TestMethod]
    public void CountValue_FullArray()
    {
        var actual = SearchNumberInArray.CountValue(new int[] {1,1,1,1}, 1);
        Assert.AreEqual(4, actual);
    }
    
    [TestMethod]
    public void CountValue_EmptyArray()
    {
        var actual = SearchNumberInArray.CountValue(new int[] {}, 1);
        Assert.AreEqual(0, actual);
    }
    
    [TestMethod]
    public void CountValue_IsCounting()
    {
        var actual = SearchNumberInArray.CountValue(new int[] {0}, 0);
        Assert.AreEqual(1, actual);
    }

}

