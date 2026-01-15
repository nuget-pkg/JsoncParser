namespace Global.Parser.ELang {

  using System;
  using System.Collections.Generic;

  sealed public class Rule_value:Rule
  {
    private Rule_value(String spelling, List<Rule> rules) :
    base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_value Parse(ParserContext context)
    {
      context.Push("value");

      Rule rule;
      bool parsed = true;
      ParserAlternative b;
      int s0 = context.index;
      ParserAlternative a0 = new ParserAlternative(s0);

      List<ParserAlternative> as1 = new List<ParserAlternative>();
      parsed = false;
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_false.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_true.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_null.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_nil.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_object.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_array.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_number.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_string.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_lisp_symbol.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_vector.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_quote.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_unquote.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_deref.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_metadata.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Rule_as_is.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }

      b = ParserAlternative.GetBest(as1);

      parsed = b != null;

      if (parsed)
      {
        a0.Add(b.rules, b.end);
        context.index = b.end;
      }

      rule = null;
      if (parsed)
      {
          rule = new Rule_value(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
          context.index = s0;
      }

      context.Pop("value", parsed);

      return (Rule_value)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
