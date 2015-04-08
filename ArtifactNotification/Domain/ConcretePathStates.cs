using Ports;

namespace ArtifactNotification.Domain
{
  public interface PathStates
  {
    PathDetectedState ForDetectedChangeTo(ChangedPath fullPath);
    PathNotDetectedState PathNotDetectedState();
  }

  public class ConcretePathStates : PathStates
  {
    private readonly SystemServices _systemServices;
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly ApplicationEventsPresenter _applicationEventsPresenter;

    public ConcretePathStates(SystemServices systemServices, DiagnosticMessages diagnosticMessages, ApplicationEventsPresenter applicationEventsPresenter)
    {
      _systemServices = systemServices;
      _diagnosticMessages = diagnosticMessages;
      _applicationEventsPresenter = applicationEventsPresenter;
    }

    public PathDetectedState ForDetectedChangeTo(ChangedPath fullPath)
    {
      return new PathDetectedState(fullPath, _systemServices, _applicationEventsPresenter);
    }

    public PathNotDetectedState PathNotDetectedState()
    {
      return new PathNotDetectedState(_diagnosticMessages);
    }
  }
}