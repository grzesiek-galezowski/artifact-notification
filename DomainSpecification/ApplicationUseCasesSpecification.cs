using Domain;
using NSubstitute;
using NUnit.Framework;
using Ports;
using Ports.Interfaces;
using TddEbook.TddToolkit;

namespace DomainSpecification
{
  public class ApplicationUseCasesSpecification
  {
    [Test]
    public void ShouldPassRequestForCopyFileToClipboardToPathContext()
    {
      //GIVEN
      var diagnosticMessages = Any.Instance<DiagnosticMessages>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);

      //WHEN
      useCases.CopyFileToClipboard();

      //THEN
      pathContext.Received(1).CopyFileToClipboard();
    }

    [Test]
    public void ShouldLogDiagnosticMessageWhenCopyingFileToClipboardEndsWithException()
    {
      //GIVEN
      var exception = Any.Exception();
      var diagnosticMessages = Substitute.For<DiagnosticMessages>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);

      pathContext.When(m => m.CopyFileToClipboard()).Throw(exception);

      //WHEN
      useCases.CopyFileToClipboard();

      //THEN
      diagnosticMessages.Received(1).NotifyOnError(exception);
    }

    [Test]
    public void ShouldPassRequestForInitializationToPathContext()
    {
      //GIVEN
      var diagnosticMessages = Any.Instance<DiagnosticMessages>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);

      //WHEN
      useCases.Initialize();

      //THEN
      pathContext.Received(1).Initialize();
    }

    [Test]
    public void ShouldSavePathUsingContextWhenNotifiedOnPathChange()
    {
      //GIVEN
      var diagnosticMessages = Any.Instance<DiagnosticMessages>();
      var path = Any.Instance<ChangedPath>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);

      //WHEN
      useCases.OnChanged(path);

      //THEN
      pathContext.Received(1).Save(path);
    }


    [Test]
    public void ShouldLogDiagnosticMessageWhenSavingPathEndsWithException()
    {
      //GIVEN
      var exception = Any.Exception();
      var diagnosticMessages = Substitute.For<DiagnosticMessages>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);
      var path = Any.Instance<ChangedPath>();

      pathContext.When(m => m.Save(path)).Throw(exception);

      //WHEN
      useCases.OnChanged(path);

      //THEN
      diagnosticMessages.Received(1).NotifyOnError(exception);
    }



    [Test]
    public void ShouldPassRequestForOpeningFolderToClipboardToPathContext()
    {
      //GIVEN
      var diagnosticMessages = Any.Instance<DiagnosticMessages>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);

      //WHEN
      useCases.OpenFolder();

      //THEN
      pathContext.Received(1).OpenFolder();
    }

    [Test]
    public void ShouldLogDiagnosticMessageWhenOpeningFolderEndsWithException()
    {
      //GIVEN
      var exception = Any.Exception();
      var diagnosticMessages = Substitute.For<DiagnosticMessages>();
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext);

      pathContext.When(m => m.OpenFolder()).Throw(exception);

      //WHEN
      useCases.OpenFolder();

      //THEN
      diagnosticMessages.Received(1).NotifyOnError(exception);
    }
  }
}
