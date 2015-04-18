using System;
using System.IO;
using System.Windows;
using Ports;

namespace Domain
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

    public void OnChanged(ChangedPath changedPath)
    {
      try
      {
        _pathContext.Save(changedPath);
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
        _pathContext.CopyFileToClipboard();
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
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