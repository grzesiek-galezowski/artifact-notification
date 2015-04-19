using System;
using System.Collections.Generic;
using System.Linq;
using Minimatch;
using Ports;
using Ports.Interfaces;

namespace Domain
{
  public class FilteringObserver : PathChangesObserver
  {
    private readonly PathChangesObserver _applicationUseCases;
    private readonly List<Minimatcher> _globs;

    public FilteringObserver(PathChangesObserver applicationUseCases, string filtersAsPipeSeparatedString)
    {
      var filters = ToFilterArray(filtersAsPipeSeparatedString);

      _applicationUseCases = applicationUseCases;
      _globs = filters.Select(AsMinimatcher).ToList();
    }

    private static string[] ToFilterArray(string filtersAsPipeSeparatedString)
    {
      return filtersAsPipeSeparatedString.Split(new [] {'|'}, StringSplitOptions.RemoveEmptyEntries);
    }

    private static Minimatcher AsMinimatcher(string f)
    {
      return new Minimatcher(f, new Options()
      {
        AllowWindowsPaths = true
      });
    }

    public void OnChanged(ChangedPath changedPath)
    {
      if (_globs.Any(Matches(changedPath)))
      {
        _applicationUseCases.OnChanged(changedPath);
      }
      else
      {
        Console.WriteLine("None of the " + _globs.Count + " globs matched " + changedPath);
        //bug change this to logging
      }
    }

    private static Func<Minimatcher, bool> Matches(ChangedPath changedPath)
    {
      return g => g.IsMatch(changedPath.ToString());
    }

    public const string DoNotFilter = "**";
  }
}