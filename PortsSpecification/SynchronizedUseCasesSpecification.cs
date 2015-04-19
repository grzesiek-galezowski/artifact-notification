using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NSubstitute;
using NUnit.Framework;
using Ports;
using Ports.Interfaces;
using TddEbook.TddToolkit;

namespace PortsSpecification
{
  public class SynchronizedUseCasesSpecification
  {
    [Test]
    public void ShouldSynchronizeCallsToInnerInstanceWithMonitor()
    {
      //GIVEN
      var useCases = Substitute.For<UseCases>();
      var proxy = new SynchronizedUseCases(useCases);
      var sender = Any.Object();
      var events = Any.Instance<RoutedEventArgs>();
      var path = Any.Instance<ChangedPath>();

      proxy.AssertSynchronizes(useCases, cases => cases.CopyFileToClipboard(), Blocking.MonitorOn(proxy._syncRoot));
      proxy.AssertSynchronizes(useCases, cases => cases.Initialize(), Blocking.MonitorOn(proxy._syncRoot));
      proxy.AssertSynchronizes(useCases, cases => cases.OpenFolder(), Blocking.MonitorOn(proxy._syncRoot));
      proxy.AssertSynchronizes(useCases, cases => cases.OnChanged(path), Blocking.MonitorOn(proxy._syncRoot));
    }
  }
}
