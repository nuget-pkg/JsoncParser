namespace Global.Parser.ELang {

  using System;
  using System.Collections.Generic;

  public class Displayer:Visitor
  {

    public Object Visit(Rule_elang_text rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_begin_array rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_begin_vector rule)
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

    public Object Visit(Rule_end_vector rule)
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

    public Object Visit(Rule_linecomment rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_comment rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_inslcomment rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_inmlcomment rule)
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

    public Object Visit(Rule_nil rule)
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

    public Object Visit(Rule_member_name rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_array rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_vector rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_quote rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_unquote rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_deref rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_metadata rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_as_is rule)
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

    public Object Visit(Rule_string1 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_string2 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_double_quotation_mark rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_single_quotation_mark rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_escape rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_char1 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_unescaped1 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_char2 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_unescaped2 rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_lisp_symbol rule)
    {
      return VisitRules(rule.rules);
    }

    public Object Visit(Rule_lisp_char rule)
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
