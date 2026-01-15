namespace Global.Parser.StrictJson {

  using System;
  using System.Collections.Generic;

  public class Displayer:Visitor
  {

    public Object Visit(Rule_json_text rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_begin_array rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_begin_object rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_end_array rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_end_object rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_name_separator rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_value_separator rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_ws rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_value rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_false rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_null rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_true rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_object rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_member rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_array rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_number rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_decimal_point rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_digit rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_digit1_9 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_hexdig rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_e rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_exp rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_frac rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_int rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_minus rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_plus rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_zero rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_string rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_char rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_escape rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_quotation_mark rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_unescaped rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Terminal_StringValue value)
    {
      Console.Write(value.spelling);
      return null;
    }

    public Object Visit(Terminal_NumericValue value)
    {
      Console.Write(value.spelling);
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
