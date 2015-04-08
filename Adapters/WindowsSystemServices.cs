using System.Diagnostics;
using System.Windows;
using ArtifactNotification.Domain;
using Ports;

namespace ArtifactNotification.Adapters
{
  public class WindowsSystemServices : SystemServices
  {
    private bool _fileExists;

    public void AddToClipboard(ChangedPath fullPath) //bug refactor to value object
    {
      var objData = new DataObject();
      objData.SetData(DataFormats.FileDrop, new[] {fullPath}, false);
      Clipboard.SetDataObject(objData, true);
    }

    public void StartExplorer(ChangedPath fullPath)
    {
      Process.Start("explorer.exe", "/select," + fullPath + "\"");
    }

    public bool PathExists(ChangedPath fullPath)
    {
      _fileExists = fullPath.ToFileInfo().Exists;
      if (!_fileExists)
      {
        MessageBox.Show(fullPath + " does not exist");
        MessageBox.Show(fullPath + " does not exist");
      }
      return _fileExists;
    }
  }
}