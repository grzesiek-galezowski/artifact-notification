using Ports;
using Ports.Interfaces;

namespace Domain
{
  public class PathNotDetectedState : PathState
  {
    private readonly DiagnosticMessages _diagnosticMessages;

    public PathNotDetectedState(DiagnosticMessages diagnosticMessages)
    {
      _diagnosticMessages = diagnosticMessages;
    }

    public void OpenFolder()
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }

    public void SaveToClipboard()
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }
  }
}