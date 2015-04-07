using ArtifactNotification;
using NSubstitute;

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

    public void ShouldDisplayMessageThatThereWasChangeTo(ArtifactNotification.ChangedPath changedPath)
    {
      _diagnosticMessages.Received(1).NotifyMonitoredPathChanged(changedPath);
    }
  }
}