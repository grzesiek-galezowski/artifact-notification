using System;
using System.IO;

namespace ArtifactNotification
{
  public class ChangedPath : IEquatable<ChangedPath>
  {
    public bool Equals(ChangedPath other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(_fullPath, other._fullPath);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((ChangedPath) obj);
    }

    public override int GetHashCode()
    {
      return _fullPath.GetHashCode();
    }

    public static bool operator ==(ChangedPath left, ChangedPath right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(ChangedPath left, ChangedPath right)
    {
      return !Equals(left, right);
    }

    private readonly string _fullPath;

    public ChangedPath(string changedPathDir, string changedPathFile)
    {
      _fullPath = Path.Combine(changedPathDir, changedPathFile);
    }

    public ChangedPath(string fullPath)
    {
      _fullPath = fullPath;
    }

    public FileInfo ToFileInfo()
    {
      return new FileInfo(_fullPath);
    }

    public override string ToString()
    {
      return _fullPath;
    }
  }
}