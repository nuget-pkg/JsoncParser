namespace Global.Parser.JsonC {

  using System;
  using System.Collections.Generic;

  public class XmlDisplayer:Visitor
  {
    private bool terminal = true;

    public Object Visit(Rule_json_text rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<json-text>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</json-text>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_begin_array rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<begin-array>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</begin-array>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_begin_object rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<begin-object>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</begin-object>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_end_array rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<end-array>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</end-array>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_end_object rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<end-object>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</end-object>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_name_separator rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<name-separator>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</name-separator>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_value_separator rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<value-separator>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</value-separator>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_ws rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<ws>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</ws>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_linecomment rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<linecomment>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</linecomment>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_comment rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<comment>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</comment>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_inslcomment rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<inslcomment>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</inslcomment>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_inmlcomment rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<inmlcomment>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</inmlcomment>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_value rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<value>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</value>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_false rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<false>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</false>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_null rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<null>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</null>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_true rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<true>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</true>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_object rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<object>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</object>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_member rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<member>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</member>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_member_name rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<member-name>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</member-name>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_array rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<array>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</array>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_number rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<number>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</number>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_decimal_point rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<decimal-point>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</decimal-point>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_digit rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<digit>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</digit>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_digit1_9 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<digit1-9>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</digit1-9>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_hexdig rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<hexdig>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</hexdig>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_e rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<e>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</e>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_exp rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<exp>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</exp>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_frac rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<frac>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</frac>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_int rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<int>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</int>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_minus rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<minus>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</minus>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_plus rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<plus>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</plus>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_zero rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<zero>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</zero>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_string rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<string>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</string>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_string1 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<string1>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</string1>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_string2 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<string2>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</string2>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_double_quotation_mark rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<double-quotation-mark>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</double-quotation-mark>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_single_quotation_mark rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<single-quotation-mark>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</single-quotation-mark>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_escape rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<escape>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</escape>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_char1 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<char1>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</char1>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_unescaped1 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<unescaped1>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</unescaped1>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_char2 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<char2>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</char2>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_unescaped2 rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<unescaped2>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</unescaped2>");
      terminal = false;
      return null;
    }

    public Object Visit(Rule_symbol rule)
    {
      if (!terminal) System.Console.WriteLine();
      Console.Write("<symbol>");
      terminal = false;
      VisitRules(rule.rules);
      if (!terminal) System.Console.WriteLine();
      Console.Write("</symbol>");
      terminal = false;
      return null;
    }

    public Object Visit(Terminal_StringValue value)
    {
      Console.Write(value.spelling);
      terminal = true;
      return null;
    }

    public Object Visit(Terminal_NumericValue value)
    {
      Console.Write(value.spelling);
      terminal = true;
      return null;
    }

    private Object VisitRules(List<Rule> rules)
    {
      foreach (Rule rule in rules)
        rule.Accept(this);
      return null;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
