namespace ArtifactNotification
{
  public interface PathStates
  {
    PathDetectedState PathDetectedState { get; }
    PathNotDetectedState PathNotDetectedState { get; }
  }

  public class ConcretePathStates : PathStates
  {
    private readonly PathNotDetectedState _pathNotDetectedState;
    private readonly PathDetectedState _pathDetectedState;

    public ConcretePathStates()
    {
      _pathNotDetectedState = new PathNotDetectedState();
      _pathDetectedState = new PathDetectedState();
    }

    public PathDetectedState PathDetectedState
    {
      get { return _pathDetectedState; }
    }

    public PathNotDetectedState PathNotDetectedState
    {
      get { return _pathNotDetectedState; }
    }
  }
}