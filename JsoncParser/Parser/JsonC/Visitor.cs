namespace Global.Parser.JsonC {

  using System;

  public interface Visitor
  {
    Object Visit(Rule_json_text rule);
    Object Visit(Rule_begin_array rule);
    Object Visit(Rule_begin_object rule);
    Object Visit(Rule_end_array rule);
    Object Visit(Rule_end_object rule);
    Object Visit(Rule_name_separator rule);
    Object Visit(Rule_value_separator rule);
    Object Visit(Rule_ws rule);
    Object Visit(Rule_linecomment rule);
    Object Visit(Rule_comment rule);
    Object Visit(Rule_inslcomment rule);
    Object Visit(Rule_inmlcomment rule);
    Object Visit(Rule_value rule);
    Object Visit(Rule_false rule);
    Object Visit(Rule_null rule);
    Object Visit(Rule_true rule);
    Object Visit(Rule_object rule);
    Object Visit(Rule_member rule);
    Object Visit(Rule_member_name rule);
    Object Visit(Rule_array rule);
    Object Visit(Rule_number rule);
    Object Visit(Rule_decimal_point rule);
    Object Visit(Rule_digit rule);
    Object Visit(Rule_digit1_9 rule);
    Object Visit(Rule_hexdig rule);
    Object Visit(Rule_e rule);
    Object Visit(Rule_exp rule);
    Object Visit(Rule_frac rule);
    Object Visit(Rule_int rule);
    Object Visit(Rule_minus rule);
    Object Visit(Rule_plus rule);
    Object Visit(Rule_zero rule);
    Object Visit(Rule_string rule);
    Object Visit(Rule_string1 rule);
    Object Visit(Rule_string2 rule);
    Object Visit(Rule_double_quotation_mark rule);
    Object Visit(Rule_single_quotation_mark rule);
    Object Visit(Rule_escape rule);
    Object Visit(Rule_char1 rule);
    Object Visit(Rule_unescaped1 rule);
    Object Visit(Rule_char2 rule);
    Object Visit(Rule_unescaped2 rule);
    Object Visit(Rule_symbol rule);

    Object Visit(Terminal_StringValue value);
    Object Visit(Terminal_NumericValue value);
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
