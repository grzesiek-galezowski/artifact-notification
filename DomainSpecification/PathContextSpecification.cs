using Domain;
using NSubstitute;
using NUnit.Framework;
using Ports;
using TddEbook.TddToolkit;

namespace DomainSpecification
{
  public class PathContextSpecification
  {
    [Test]
    public void ShouldUpdateMonitoredPathAndNotifyApplicationStartedWhenInitialized()
    {
      //GIVEN
      var messages = Substitute.For<DiagnosticMessages>();
      var watchers = Substitute.For<FileSystemWatchers>();
      var presenter = Substitute.For<ApplicationEventsPresenter>();
      var states = Any.Instance<PathStates>();
      string description = Any.String();
      
      var context = new PathContext(messages, watchers, presenter, states);

      watchers.Description().Returns(description);
      
      //WHEN
      context.Initialize();

      //THEN
      Received.InOrder(() =>
      {
        presenter.UpdateMonitoredPath(watchers.Description());
        messages.NotifyApplicationStarted();
      });
    }
  }
}
