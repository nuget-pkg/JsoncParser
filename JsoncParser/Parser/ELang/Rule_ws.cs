namespace Global.Parser.ELang {

  using System;
  using System.Collections.Generic;

  sealed public class Rule_ws:Rule
  {
    private Rule_ws(String spelling, List<Rule> rules) :
    base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_ws Parse(ParserContext context)
    {
      context.Push("ws");

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
          while (f1)
          {
            int g1 = context.index;
            List<ParserAlternative> as2 = new List<ParserAlternative>();
            parsed = false;
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Terminal_NumericValue.Parse(context, "%x20", "[\\x20]", 1);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Terminal_NumericValue.Parse(context, "%x09", "[\\x09]", 1);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Terminal_NumericValue.Parse(context, "%x0A", "[\\x0A]", 1);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Terminal_NumericValue.Parse(context, "%x0D", "[\\x0D]", 1);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Rule_linecomment.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Rule_comment.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }

            b = ParserAlternative.GetBest(as2);

            parsed = b != null;

            if (parsed)
            {
              a1.Add(b.rules, b.end);
              context.index = b.end;
            }
            f1 = context.index > g1;
            if (parsed) c1++;
          }
          parsed = true;
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
          rule = new Rule_ws(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
          context.index = s0;
      }

      context.Pop("ws", parsed);

      return (Rule_ws)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
