#region File Header & Copyright Notice
//Copyright 2015 Motorola Solutions, Inc.
//All Rights Reserved.
//Motorola Solutions Confidential Restricted
#endregion

using ArtifactNotification;
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
