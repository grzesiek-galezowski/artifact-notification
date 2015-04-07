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

    public ConcretePathStates(SystemServices systemServices)
    {
      _systemServices = systemServices;
    }

    public PathDetectedState PathDetectedState(ChangedPath fullPath)
    {
      return new PathDetectedState(fullPath, _systemServices);
    }

    public PathNotDetectedState PathNotDetectedState()
    {
      return new PathNotDetectedState();
    }
  }
}