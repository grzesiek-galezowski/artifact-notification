using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtifactNotification;
using ArtifactNotification.Domain;
using NSubstitute;
using NUnit.Framework;
using Ports;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification
{
  public class ApplicationUseCasesSpecification
  {
    [Test]
    public void ShouldPassRequestForFiltersChangeToPathContext()
    {
      //GIVEN
      var pathContext = Substitute.For<PathOperationsContext>();
      var useCases = new ApplicationUseCases(Any.Instance<DiagnosticMessages>(), pathContext, Any.Instance<ApplicationEventsPresenter>());
      var filters = Any.String();
      
      //WHEN
      useCases.ChangeFilters(filters);

      //THEN
      pathContext.Received(1).ChangeFilters(filters);
    }

    [Test]
    public void ShouldReportErrorWhenChangingFiltersEndsWithException()
    {
      //GIVEN
      var pathContext = Substitute.For<PathOperationsContext>();
      var diagnosticMessages = Substitute.For<DiagnosticMessages>();
      var useCases = new ApplicationUseCases(diagnosticMessages, pathContext, Any.Instance<ApplicationEventsPresenter>());
      var filters = Any.String();
      var e = Any.Exception();

      pathContext.When(c => c.ChangeFilters(filters)).Throw(e);

      //WHEN
      useCases.ChangeFilters(filters);

      //THEN
      diagnosticMessages.Received(1).NotifyOnError(e);
    }

    //TODO exception case
  }
}
