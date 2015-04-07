﻿using ArtifactNotification;
using ArtifactNotificationSpecification.Drivers;
using NUnit.Framework;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.Specification
{
    public class AppSpecification
    {
      [Test]
      public void ShouldDisplayInformationAndUpdateLastPathChangedInfoOnPathChangeEvent()
      {
        //GIVEN
        var context = new ArtifactNotificationDriver();
        context.StartApplication().ClearRecordedEvents();
        var changedPathDir = Any.String();
        var changedPathFile = Any.String();
        var changedPath = new ChangedPath(changedPathDir, changedPathFile);

        //WHEN
        context.FileSystem.ReportChangedPath(changedPathDir, changedPathFile);

        //THEN
        context.DiagnosticBubble.ShouldDisplayMessageThatThereWasChangeTo(changedPath);
        context.LastDetectedPathChange.ShouldBeUpdatedTo(changedPath);
      }

      [Test]
      public void ShouldNotUpdateAnythingWhenChangeIsDetectedForFileThatDoesNotMatchFilter()
      {
        //GIVEN
        var context = new ArtifactNotificationDriver();
        context.StartApplication().ConfigureFilters("*.txt").ClearRecordedEvents();
        var anyDir = Any.String();
        var nonTextFileName = Any.StringNotContaining(".txt");
        
        //WHEN
        context.FileSystem.ReportChangedPath(anyDir, nonTextFileName);

        //THEN
        context.DiagnosticBubble.ShouldNotDisplayAnything();
        context.LastDetectedPathChange.ShouldNotBeUpdated();
      }


      //TODO handle all GUI options in both states
      //TODO scenario where path was reported but does not exist anymore
    }
}
