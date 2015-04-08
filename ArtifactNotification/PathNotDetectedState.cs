namespace ArtifactNotification
{
  public class PathNotDetectedState : PathState
  {
    private readonly DiagnosticMessages _diagnosticMessages;

    public PathNotDetectedState(DiagnosticMessages diagnosticMessages)
    {
      _diagnosticMessages = diagnosticMessages;
    }

    public void OpenFolder(PathContext pathContext)
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }

    public void SaveToClipboard(PathContext pathContext, ApplicationEventsPresenter presenter)
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }
  }
}