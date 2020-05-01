using System;
using System.Collections.Generic;
using System.Linq;

namespace AppLib.Patterns.Cqs.Validation
{
  public class PremiseValidator
  {
    public PremiseValidator For(object the_property)
    {
      property = the_property;

      return this;
    }

    public PremiseValidator Must<S>(Func<object, bool> predicate) where S : IResponseMessage, new()
    {
      if (!predicate(property))
      {
        responseBuilder.AddMessage<S>();
      }

      return this;
    }

    public IEnumerable<IResponseMessage> GetFailures()
    {
      return responseBuilder.Build();
    }

    private readonly ResponseMessagesBuilder responseBuilder = new ResponseMessagesBuilder();

    private object property;
  }

  public static class BasicPremises
  {
    public static PremiseValidator TextIsNotEmpty<S>(this PremiseValidator context) where S : IResponseMessage, new()
    {
      return context.Must<S>(value => !string.IsNullOrWhiteSpace(value as string));
    }

    public static PremiseValidator TextIsWithin<S>(this PremiseValidator context, int lower, int upper = 99999999) where S : IResponseMessage, new()
    {
      return context.Must<S>(value =>
      {
        var count = (value as string).Count();

        return count >= lower && count <= upper;
      });
    }

    public static PremiseValidator TextIsAlphabetic<S>(this PremiseValidator context) where S : IResponseMessage, new()
    {
      return context.Must<S>(value => value == null || (value as string).All(char.IsLetter));
    }

    public static PremiseValidator TextIsNumeric<S>(this PremiseValidator context) where S : IResponseMessage, new()
    {
      return context.Must<S>(value => value == null || (value as string).All(char.IsNumber));
    }

    public static PremiseValidator TextIsAlphaNumeric<S>(this PremiseValidator context) where S : IResponseMessage, new()
    {
      return context.Must<S>(value => value != null ? (value as string).Replace(" ", "").All(char.IsLetterOrDigit) : true);
    }
  }
}