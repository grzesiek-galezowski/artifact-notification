﻿using ArtifactNotification;
using NUnit.Framework;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification
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
