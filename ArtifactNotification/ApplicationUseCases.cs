using System;
using System.IO;
using System.Windows;

namespace ArtifactNotification
{
  public class ApplicationUseCases : UseCases
  {
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly PathOperationsContext _pathContext;
    private readonly ApplicationEventsPresenter _presenter;

    public ApplicationUseCases(DiagnosticMessages diagnosticMessages, PathOperationsContext pathContext, ApplicationEventsPresenter presenter)
    {
      _diagnosticMessages = diagnosticMessages;
      _pathContext = pathContext;
      _presenter = presenter;
    }

    public void OnChanged(object source, FileSystemEventArgs e)
    {
      try
      {
        _pathContext.Save(new ChangedPath(e.FullPath), _presenter);
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
      }
    }

    public void CopyFileToClipboard(object sender, RoutedEventArgs e)
    {
      try
      {
        _pathContext.CopyFileToClipboard(_presenter);
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
      }
    }

    public void ChangeFilters(string filters)
    {
      try
      {
        _pathContext.ChangeFilters(filters);
      }
      catch (Exception e)
      {
        _diagnosticMessages.NotifyOnError(e);
      }
    }

    public void OpenFolder(object sender, RoutedEventArgs e)
    {
      try
      {
        _pathContext.OpenFolder();
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
      }
    }
  }
}