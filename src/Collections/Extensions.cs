using System;
using System.Collections.Generic;
using System.Linq;
using AppLib.Primitives;

namespace AppLib.Collections
{
  public static class Extensions
  {
    public static void Do<S>(this IEnumerable<S> source, Action<S> action)
    {
      foreach (var entry in source)
      {
        action(entry);
      }
    }

    public static IEnumerable<T> ToEnumerable<T>(this T source)
    {
      Guard.IsNotNull(source, nameof(source));

      yield return source;
    }

    public static IOrderedEnumerable<T> Order<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector, bool ascending)
    {
      if (ascending)
      {
        return source.OrderBy(selector);
      }
      else
      {
        return source.OrderByDescending(selector);
      }
    }

    public static IEnumerable<IPositionedElement> Insert(this IEnumerable<IPositionedElement> index
                                                 , int insertAt)
    {
      Guard.IsNotNull(index, "index");
      Guard.IsNotNull(insertAt, "insert_at");
      Guard.EnforcePredicate(insertAt >= 1, "insert_at.postion out of range. An index starts at 1.");
      Guard.EnforcePredicate(insertAt <= index.Count() + 1, "insert_at.postion out of range. Can not insert an element which would result in the index not being contiguous.");

      // Note - insisting on the index being contiguous allow insert 
      //        to simply update the position of all elements that need 
      //        to be moved by one.  If we allowed gaps then we would 
      //        have to check if we are still in a contiguous group.  While
      //        that would not to painful to implement I have not identified a
      //        need for that at the moment so in order to keep the implementation 
      //        as simple as possible this has not been added.
      index
          .Where(e => e.Position >= insertAt)
          .Do(e => e.Position++)
          ;

      return index;
    }

    public static IEnumerable<IPositionedElement> Remove(this IEnumerable<IPositionedElement> index
                                                 , int removeAt)
    {
      Guard.IsNotNull(index, "index");
      Guard.IsNotNull(removeAt, "remove_at");
      Guard.EnforcePredicate(removeAt >= 1, "remove_at.postion out of range. An index starts at 1.");
      Guard.EnforcePredicate(removeAt <= index.Count() + 1, "remove_at.postion out of range. Can not insert an element which would result in the index not being contiguous.");

      // Note - insisting on the index being contiguous allow insert 
      //        to simply update the position of all elements that need 
      //        to be moved by one.  If we allowed gaps then we would 
      //        have to check if we are still in a contiguous group.  While
      //        that would not to painful to implement I have not identified a
      //        need for that at the moment so in order to keep the implementation 
      //        as simple as possible this has not been added.
      index
          .Where(e => e.Position > removeAt)
          .Do(e => e.Position--);

      return index;
    }

    public static IEnumerable<IPositionedElement> Move(this IEnumerable<IPositionedElement> index, int from, int to)
    {

      Guard.IsNotNull(index, "index");
      Guard.EnforcePredicate(to >= 1, "destination is out of range. An index starts at 1.");
      Guard.EnforcePredicate(to <= index.Count() + 1, "To Out of range. Can not insert an element which would result in the index not being contiguous.");


      // move all elements that ordered beneath the element to be moved up one
      index
          .Where(e => e.Position > from)
          .Do(e => e.Position--);

      // move all elements that are ordered beneath where then element is to be moved to 
      // down one place including the element that is currently in the place where the 
      // element is to be moved to.
      index
          .Where(e => e.Position >= to)
          .Do(e => e.Position++);

      return index;
    }
  }
}
