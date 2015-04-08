namespace ArtifactNotification
{
  public interface PathStates
  {
    PathDetectedState PathDetectedState(ChangedPath fullPath);
    PathNotDetectedState PathNotDetectedState();
  }

  public class ConcretePathStates : PathStates
  {
    private readonly SystemServices _systemServices;
    private readonly DiagnosticMessages _diagnosticMessages;

    public ConcretePathStates(SystemServices systemServices, DiagnosticMessages diagnosticMessages)
    {
      _systemServices = systemServices;
      _diagnosticMessages = diagnosticMessages;
    }

    public PathDetectedState PathDetectedState(ChangedPath fullPath)
    {
      return new PathDetectedState(fullPath, _systemServices);
    }

    public PathNotDetectedState PathNotDetectedState()
    {
      return new PathNotDetectedState(_diagnosticMessages);
    }
  }
}