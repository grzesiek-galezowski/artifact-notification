using NUnit.Framework;
using Ports;
using TddEbook.TddToolkit;

namespace PortsSpecification
{
  public class ChangedPathSpecification
  {
    [Test]
    public void ShouldBehaveLikeValue()
    {
      XAssert.IsValue<ChangedPath>();
    }
  }
}
