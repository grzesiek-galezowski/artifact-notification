using System;
using NSubstitute;
using NUnit.Framework;
using Ports;
using TddEbook.TddToolkit;

namespace PortsSpecification
{
  public class LazyMainWindowSpecification
  {
    [Test]
    public void ShouldIgnoreAllWindowCallsWhenNoMainWindowIsSetToProxyTo()
    {
      //GIVEN
      var window = new LazyMainWindow();
      
      //WHEN - THEN
      
      Assert.DoesNotThrow(() =>
      {
        window.ShowBalloonTipInfo(Any.String(), Any.String());
        window.ShowError(Any.Exception());
        window.ShowWarning(Any.String());
        window.UpdateLastDetectedChangedPath(Any.Instance<ChangedPath>());
        window.UpdateLastPathCopiedToClipboard(Any.Instance<ChangedPath>());
        window.UpdateMonitoredPath(Any.String());
      });
    }

    [Test]
    public void ShouldPassBaloonTipRequestToRegisteredInnerInstance()
    {
      var message = Any.String();
      var title = Any.String();

      ShouldBePassedToRegisteredInnerInstance(w => { w.ShowBalloonTipInfo(title, message); });
    }

    [Test]
    public void ShouldPassShowingErrorToRegisteredInnerInstance()
    {
      var exception = Any.Exception();

      ShouldBePassedToRegisteredInnerInstance(w => { w.ShowError(exception); });
    }


    [Test]
    public void ShouldPassShowingWarningToRegisteredInnerInstance()
    {
      var message = Any.String();

      ShouldBePassedToRegisteredInnerInstance(w => { w.ShowWarning(message); });
    }

    [Test]
    public void ShouldPassUpdatingLastDetectedChangedPathToRegisteredInnerInstance()
    {
      var changedPath = Any.Instance<ChangedPath>();

      ShouldBePassedToRegisteredInnerInstance(w => { w.UpdateLastDetectedChangedPath(changedPath); });
    }


    [Test]
    public void ShouldPassUpdatingLastPathCopiedToClipboardToRegisteredInnerInstance()
    {
      var changedPath = Any.Instance<ChangedPath>();

      ShouldBePassedToRegisteredInnerInstance(w => { w.UpdateLastPathCopiedToClipboard(changedPath); });
    }

    [Test]
    public void ShouldPassUpdatingMonitoredPathToRegisteredInnerInstance()
    {
      var monitoredPath = Any.String();

      ShouldBePassedToRegisteredInnerInstance(w => { w.UpdateMonitoredPath(monitoredPath); });
    }


    private static void ShouldBePassedToRegisteredInnerInstance(Action<GuiMainWindow> invocation)
    {

      //GIVEN
      var window = new LazyMainWindow();
      var innerInstance = Substitute.For<GuiMainWindow>();
      ;
      window.ForwardAllInvocationsTo(innerInstance);

      //WHEN
      invocation(window);

      //THEN
      invocation(innerInstance.Received(1));
    }
  }
}
