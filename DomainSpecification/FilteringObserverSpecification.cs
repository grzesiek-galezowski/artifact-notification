using Domain;
using NSubstitute;
using NUnit.Framework;
using Ports;
using Ports.Interfaces;
using TddEbook.TddToolkit;

namespace DomainSpecification
{
  public class FilteringObserverSpecification
  {
    [TestCase("*", "", 1)]
    [TestCase("*.txt", ".txt", 1)]
    [TestCase("*.txt|*.pdf", ".txt", 1)]
    [TestCase("*.txt|*.pdf", ".pdf", 1)]
    [TestCase("*.txt|*.pdf", "", 0)]
    public void ShouldAllowAllPathsWhenPassedBlob(string blob, string extension, int expectedInnerObserverCallCount)
    {
      //GIVEN
      var innerObserver = Substitute.For<PathChangesObserver>();
      var filter = new FilteringObserver(innerObserver, blob);
      var changedPath = new ChangedPath(Any.String() + extension);
      
      //WHEN
      filter.OnChanged(changedPath);

      //THEN
      innerObserver.Received(expectedInnerObserverCallCount).OnChanged(changedPath);
    }

    [Test]
    public void ShouldNotIssueNotificationWhenNoneOfThePatternsIsMatchedByInput()
    {
      //GIVEN
      var nonMatchablePattern = "*.lolokimono";
      var innerObserver = Substitute.For<PathChangesObserver>();
      var filter = new FilteringObserver(innerObserver, nonMatchablePattern);
      var changedPath = new ChangedPath(Any.String());

      //WHEN
      filter.OnChanged(changedPath);

      //THEN
      innerObserver.Received(0).OnChanged(changedPath);
    }


  }
}