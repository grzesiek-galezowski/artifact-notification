using Ports;

namespace Domain
{
  public interface PathStates
  {
    PathDetectedState ForDetectedChangeTo(ChangedPath fullPath);
    PathNotDetectedState PathNotDetectedState();
  }
}