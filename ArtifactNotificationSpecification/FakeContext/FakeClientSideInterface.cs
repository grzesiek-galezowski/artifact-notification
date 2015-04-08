using System.Windows;
using ArtifactNotification;
using NSubstitute;

namespace ArtifactNotificationSpecification.FakeContext
{
  public class FakeClientSideInterface
  {
    private readonly UseCases _useCases;
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly SystemServices _systemServices;

    public FakeClientSideInterface(UseCases useCases, DiagnosticMessages diagnosticMessages, SystemServices systemServices)
    {
      _useCases = useCases;
      _diagnosticMessages = diagnosticMessages;
      _systemServices = systemServices;
    }

    public void OpenFolder()
    {
      _useCases.OpenFolder(this, new RoutedEventArgs());
    }

    public void ShouldNotifyThatNoActionWillTakePlace()
    {
      _diagnosticMessages.Received(1).WarnNothingWillHappen();
    }

    public void CopyToClipboard()
    {
      _useCases.CopyFileToClipboard(this, new RoutedEventArgs());
    }

    public void ShouldOpenPathView(ArtifactNotification.ChangedPath path)
    {
      _systemServices.Received(1).StartExplorer(path);
    }

    public void ShouldNotStartExplorer()
    {
      _systemServices.Received(0).StartExplorer(Arg.Any<ChangedPath>());
    }
  }
}