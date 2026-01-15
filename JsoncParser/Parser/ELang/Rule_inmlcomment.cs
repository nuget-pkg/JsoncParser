namespace Global.Parser.ELang {

  using System;
  using System.Collections.Generic;

  sealed public class Rule_inmlcomment:Rule
  {
    private Rule_inmlcomment(String spelling, List<Rule> rules) :
    base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_inmlcomment Parse(ParserContext context)
    {
      context.Push("inmlcomment");

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
                  rule = Terminal_NumericValue.Parse(context, "%x01-29", "[\\x01-\\x29]", 1);
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
                  rule = Terminal_NumericValue.Parse(context, "%x2B-FFFFFFFF", "[\\x2B-\\uFFFFFFFF]", 1);
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
                  int g2 = context.index;
                  List<ParserAlternative> as3 = new List<ParserAlternative>();
                  parsed = false;
                  {
                    int s3 = context.index;
                    ParserAlternative a3 = new ParserAlternative(s3);
                    parsed = true;
                    if (parsed)
                    {
                      bool f3 = true;
                      int c3 = 0;
                      for (int i3 = 0; i3 < 1 && f3; i3++)
                      {
                        rule = Terminal_NumericValue.Parse(context, "%x2A", "[\\x2A]", 1);
                        if ((f3 = rule != null))
                        {
                          a3.Add(rule, context.index);
                          c3++;
                        }
                      }
                      parsed = c3 == 1;
                    }
                    if (parsed)
                    {
                      bool f3 = true;
                      int c3 = 0;
                      for (int i3 = 0; i3 < 1 && f3; i3++)
                      {
                        int g3 = context.index;
                        List<ParserAlternative> as4 = new List<ParserAlternative>();
                        parsed = false;
                        {
                          int s4 = context.index;
                          ParserAlternative a4 = new ParserAlternative(s4);
                          parsed = true;
                          if (parsed)
                          {
                            bool f4 = true;
                            int c4 = 0;
                            for (int i4 = 0; i4 < 1 && f4; i4++)
                            {
                              rule = Terminal_NumericValue.Parse(context, "%x01-2E", "[\\x01-\\x2E]", 1);
                              if ((f4 = rule != null))
                              {
                                a4.Add(rule, context.index);
                                c4++;
                              }
                            }
                            parsed = c4 == 1;
                          }
                          if (parsed)
                          {
                            as4.Add(a4);
                          }
                          context.index = s4;
                        }
                        {
                          int s4 = context.index;
                          ParserAlternative a4 = new ParserAlternative(s4);
                          parsed = true;
                          if (parsed)
                          {
                            bool f4 = true;
                            int c4 = 0;
                            for (int i4 = 0; i4 < 1 && f4; i4++)
                            {
                              rule = Terminal_NumericValue.Parse(context, "%x30-FFFFFFFF", "[\\x30-\\uFFFFFFFF]", 1);
                              if ((f4 = rule != null))
                              {
                                a4.Add(rule, context.index);
                                c4++;
                              }
                            }
                            parsed = c4 == 1;
                          }
                          if (parsed)
                          {
                            as4.Add(a4);
                          }
                          context.index = s4;
                        }

                        b = ParserAlternative.GetBest(as4);

                        parsed = b != null;

                        if (parsed)
                        {
                          a3.Add(b.rules, b.end);
                          context.index = b.end;
                        }
                        f3 = context.index > g3;
                        if (parsed) c3++;
                      }
                      parsed = c3 == 1;
                    }
                    if (parsed)
                    {
                      as3.Add(a3);
                    }
                    context.index = s3;
                  }

                  b = ParserAlternative.GetBest(as3);

                  parsed = b != null;

                  if (parsed)
                  {
                    a2.Add(b.rules, b.end);
                    context.index = b.end;
                  }
                  f2 = context.index > g2;
                  if (parsed) c2++;
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
          rule = new Rule_inmlcomment(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
          context.index = s0;
      }

      context.Pop("inmlcomment", parsed);

      return (Rule_inmlcomment)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
