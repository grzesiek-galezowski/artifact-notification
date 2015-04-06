using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ArtifactNotification
{
  public class WindowsSystemServices : SystemServices
  {
    public void AddToClipboard(string fullPath) //bug refactor to value object
    {
      var objData = new DataObject();
      objData.SetData(DataFormats.FileDrop, new[] {fullPath}, false);
      Clipboard.SetDataObject(objData, true);
    }

    public void StartExplorer(FileInfo fullPath)
    {
      Process.Start("explorer.exe", "/select," + fullPath + "\"");
    }

    public bool PathExists(FileInfo fullPath)
    {
      if (!fullPath.Exists)
      {
        MessageBox.Show(fullPath + " does not exist");
        MessageBox.Show(fullPath + " does not exist");
      }
      return fullPath.Exists;
    }
  }
}