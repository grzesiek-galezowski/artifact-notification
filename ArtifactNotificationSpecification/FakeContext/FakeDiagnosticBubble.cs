using NSubstitute;
using Ports;
using Ports.Interfaces;

namespace ArtifactNotificationSpecification.FakeContext
{
  public class FakeDiagnosticBubble
  {
    private readonly DiagnosticMessages _diagnosticMessages;

    public FakeDiagnosticBubble(DiagnosticMessages diagnosticMessages)
    {
      _diagnosticMessages = diagnosticMessages;
    }

    public void ShouldDisplayMessageThatApplicationIsStarted()
    {
      _diagnosticMessages.Received(1).NotifyApplicationStarted();
    }

    public void ShouldDisplayMessageThatThereWasChangeTo(ChangedPath changedPath)
    {
      _diagnosticMessages.Received(1).NotifyMonitoredPathChanged(changedPath);
    }

    public void ShouldNotDisplayAnything()
    {
      _diagnosticMessages.Received(0).NotifyMonitoredPathChanged(Arg.Any<ChangedPath>());
    }
  }
}