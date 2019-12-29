using System;

using Cogito.Text.Json.Schema.Validation;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Text.Json.Schema.Tests.Validation
{

    public partial class JSchemaValidatorBuilderTestSuiteTests
    {

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__additionalItems_as_schema__additional_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6W10sImFkZGl0aW9uYWxJdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__additionalItems_as_schema__additional_items_do_not_match_schema_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W10sImFkZGl0aW9uYWxJdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzLCJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__items_is_schema__no_additionalItems_2__all_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6e30sImFkZGl0aW9uYWxJdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__array_of_items_with_no_additionalItems_3__no_additional_items_present()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__array_of_items_with_no_additionalItems_3__additional_items_are_not_permitted_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__additionalItems_as_false_without_items_4__items_defaults_to_empty_schema_so_everything_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__additionalItems_as_false_without_items_4__ignores_non_arrays_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalItems")]
        public void Test_draft3__additionalItems__additionalItems_are_allowed_by_default_5__only_the_first_items_are_validated()
        {
            var s = ParseSchema("eyJpdGVtcyI6W119", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsImZvbyIsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__an_additional_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6ImJvb20ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvb2JhcmJheiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__patternProperties_are_not_additional_properties_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsInZyb29tIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__matching_the_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyLDoXJtw6FueW9zIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__not_matching_the_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyLDqWxtw6lueSI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_valid_property_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_invalid_property_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6MTJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_valid_property_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_invalid_property_is_invalid_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("additionalProperties")]
        public void Test_draft3__additionalProperties__additionalProperties_are_allowed_by_default_5__additional_properties_are_allowed()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("default")]
        public void Test_draft3__default__invalid_type_for_default__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("default")]
        public void Test_draft3__default__invalid_type_for_default__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("default")]
        public void Test_draft3__default__invalid_string_value_for_default_2__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOiJnb29kIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("default")]
        public void Test_draft3__default__invalid_string_value_for_default_2__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__nondependant_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__with_dependency_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__ignores_arrays_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WyJiYXIiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__ignores_strings_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__dependencies__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjoiZm9vIn19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_2__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_2__nondependants_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_2__with_dependencies_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_2__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_2__missing_other_dependency_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_2__missing_both_dependencies_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJxdXV4IjoxfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_subschema_3__valid()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_subschema_3__wrong_type_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_subschema_3__wrong_type_other_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("dependencies")]
        public void Test_draft3__dependencies__multiple_dependencies_subschema_3__wrong_type_both_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoicXV1eCJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__disallow__allowed()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6ImludGVnZXIifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__disallow__disallowed_2()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6ImludGVnZXIifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_2__valid()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_2__mismatch_2()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_2__other_mismatch_3()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_subschema_3__match()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJzdHJpbmciLHsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_subschema_3__other_match_2()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJzdHJpbmciLHsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_subschema_3__mismatch_3()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJzdHJpbmciLHsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("disallow")]
        public void Test_draft3__disallow__multiple_disallow_subschema_3__other_mismatch_4()
        {
            var s = ParseSchema("eyJkaXNhbGxvdyI6WyJzdHJpbmciLHsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_int__int_by_int()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_int__int_by_int_fail_2()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Nw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_int__ignores_non_numbers_3()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_number_2__zero_is_divisible_by_anything__except_0_()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6MS41fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_number_2__4_5_is_divisible_by_1_5_2()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6MS41fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("NC41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_number_2__35_is_not_divisible_by_1_5_3()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6MS41fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_small_number_3__0_0075_is_divisible_by_0_0001()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6MC4wMDAxfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MC4wMDc1");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("divisibleBy")]
        public void Test_draft3__divisibleBy__by_small_number_3__0_00751_is_not_divisible_by_0_0001_2()
        {
            var s = ParseSchema("eyJkaXZpc2libGVCeSI6MC4wMDAxfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MC4wMDc1MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__simple_enum_validation__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__simple_enum_validation__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("NA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__heterogeneous_enum_validation_2__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__heterogeneous_enum_validation_2__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__heterogeneous_enum_validation_2__objects_are_deep_compared_3()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__enums_in_properties_3__both_properties_are_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdLCJyZXF1aXJlZCI6dHJ1ZX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28iLCJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__enums_in_properties_3__missing_optional_property_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdLCJyZXF1aXJlZCI6dHJ1ZX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__enums_in_properties_3__missing_required_property_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdLCJyZXF1aXJlZCI6dHJ1ZX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("enum")]
        public void Test_draft3__enum__enums_in_properties_3__missing_all_properties_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdLCJyZXF1aXJlZCI6dHJ1ZX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__extends__extends()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOnsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6InN0cmluZyIsInJlcXVpcmVkIjp0cnVlfX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__extends__mismatch_extends_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOnsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6InN0cmluZyIsInJlcXVpcmVkIjp0cnVlfX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__extends__mismatch_extended_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOnsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6InN0cmluZyIsInJlcXVpcmVkIjp0cnVlfX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__extends__wrong_type_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOnsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6InN0cmluZyIsInJlcXVpcmVkIjp0cnVlfX19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__multiple_extends_2__valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOlt7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmciLCJyZXF1aXJlZCI6dHJ1ZX19fSx7InByb3BlcnRpZXMiOnsiYmF6Ijp7InR5cGUiOiJudWxsIiwicmVxdWlyZWQiOnRydWV9fX1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyLCJiYXoiOm51bGx9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__multiple_extends_2__mismatch_first_extends_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOlt7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmciLCJyZXF1aXJlZCI6dHJ1ZX19fSx7InByb3BlcnRpZXMiOnsiYmF6Ijp7InR5cGUiOiJudWxsIiwicmVxdWlyZWQiOnRydWV9fX1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjIsImJheiI6bnVsbH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__multiple_extends_2__mismatch_second_extends_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOlt7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmciLCJyZXF1aXJlZCI6dHJ1ZX19fSx7InByb3BlcnRpZXMiOnsiYmF6Ijp7InR5cGUiOiJudWxsIiwicmVxdWlyZWQiOnRydWV9fX1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__multiple_extends_2__mismatch_both_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciIsInJlcXVpcmVkIjp0cnVlfX0sImV4dGVuZHMiOlt7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmciLCJyZXF1aXJlZCI6dHJ1ZX19fSx7InByb3BlcnRpZXMiOnsiYmF6Ijp7InR5cGUiOiJudWxsIiwicmVxdWlyZWQiOnRydWV9fX1dfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__extends_simple_types_3__valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoyMCwiZXh0ZW5kcyI6eyJtYXhpbXVtIjozMH19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MjU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("extends")]
        public void Test_draft3__extends__extends_simple_types_3__mismatch_extends_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoyMCwiZXh0ZW5kcyI6eyJtYXhpbXVtIjozMH19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("items")]
        public void Test_draft3__items__a_schema_given_for_items__valid_items()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("items")]
        public void Test_draft3__items__a_schema_given_for_items__wrong_type_of_items_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsIngiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("items")]
        public void Test_draft3__items__a_schema_given_for_items__ignores_non_arrays_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("items")]
        public void Test_draft3__items__an_array_of_schemas_for_items_2__correct_types()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("items")]
        public void Test_draft3__items__an_array_of_schemas_for_items_2__wrong_types_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WyJmb28iLDFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maximum")]
        public void Test_draft3__maximum__maximum_validation__below_the_maximum_is_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maximum")]
        public void Test_draft3__maximum__maximum_validation__above_the_maximum_is_invalid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maximum")]
        public void Test_draft3__maximum__maximum_validation__ignores_non_numbers_3()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maximum")]
        public void Test_draft3__maximum__exclusiveMaximum_validation_2__below_the_maximum_is_still_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Mi4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maximum")]
        public void Test_draft3__maximum__exclusiveMaximum_validation_2__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxItems")]
        public void Test_draft3__maxItems__maxItems_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxItems")]
        public void Test_draft3__maxItems__maxItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxItems")]
        public void Test_draft3__maxItems__maxItems_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxItems")]
        public void Test_draft3__maxItems__maxItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxLength")]
        public void Test_draft3__maxLength__maxLength_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxLength")]
        public void Test_draft3__maxLength__maxLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxLength")]
        public void Test_draft3__maxLength__maxLength_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxLength")]
        public void Test_draft3__maxLength__maxLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("maxLength")]
        public void Test_draft3__maxLength__maxLength_validation__two_supplementary_Unicode_code_points_is_long_enough_5()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IvCfkqnwn5KpIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minimum")]
        public void Test_draft3__minimum__minimum_validation__above_the_minimum_is_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minimum")]
        public void Test_draft3__minimum__minimum_validation__below_the_minimum_is_invalid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minimum")]
        public void Test_draft3__minimum__minimum_validation__ignores_non_numbers_3()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minimum")]
        public void Test_draft3__minimum__exclusiveMinimum_validation_2__above_the_minimum_is_still_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minimum")]
        public void Test_draft3__minimum__exclusiveMinimum_validation_2__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minItems")]
        public void Test_draft3__minItems__minItems_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minItems")]
        public void Test_draft3__minItems__minItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minItems")]
        public void Test_draft3__minItems__minItems_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minItems")]
        public void Test_draft3__minItems__minItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minLength")]
        public void Test_draft3__minLength__minLength_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minLength")]
        public void Test_draft3__minLength__minLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minLength")]
        public void Test_draft3__minLength__minLength_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minLength")]
        public void Test_draft3__minLength__minLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("minLength")]
        public void Test_draft3__minLength__minLength_validation__one_supplementary_Unicode_code_point_is_not_long_enough_5()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IvCfkqki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("pattern")]
        public void Test_draft3__pattern__pattern_validation__a_matching_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImFhYSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("pattern")]
        public void Test_draft3__pattern__pattern_validation__a_non_matching_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("pattern")]
        public void Test_draft3__pattern__pattern_validation__ignores_non_strings_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("pattern")]
        public void Test_draft3__pattern__pattern_is_not_anchored_2__matches_a_substring()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiYSsifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Inh4YWF5eSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_valid_matches_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImZvb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_invalid_match_is_invalid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_invalid_matches_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb29vIjoiYmF6In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhIjoyMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_simultaneous_match_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhYWFhIjoxOH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__multiple_matches_is_valid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhIjoyMSwiYWFhYSI6MTh9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_one_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhIjoiYmFyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_the_other_is_invalid_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_both_is_invalid_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhYWEiOiJmb28iLCJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__non_recognized_members_are_ignored()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhbnN3ZXIgMSI6IjQyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__recognized_members_are_accounted_for_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhMzFiIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhX3hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("patternProperties")]
        public void Test_draft3__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive__2_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJhX1hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__object_properties_validation__both_properties_present_and_valid_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6ImJheiJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__object_properties_validation__one_property_invalid_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6e319");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__object_properties_validation__both_properties_invalid_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOltdLCJiYXIiOnt9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__object_properties_validation__doesn_t_invalidate_other_properties_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJxdXV4IjpbXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__object_properties_validation__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__object_properties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__property_validates_property()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__property_invalidates_property_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsMyw0XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_property_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_validates_nonproperty_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmeG8iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_nonproperty_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmeG8iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_ignores_property_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_validates_others_7()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJxdXV4IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("properties")]
        public void Test_draft3__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_invalidates_others_8()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJxdXV4IjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__root_pointer_ref__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__root_pointer_ref__recursive_match_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOnsiZm9vIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__root_pointer_ref__mismatch_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__root_pointer_ref__recursive_mismatch_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOnsiYmFyIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__relative_pointer_ref_to_object_2__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__relative_pointer_ref_to_object_2__mismatch_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__relative_pointer_ref_to_array_3__match_array()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__relative_pointer_ref_to_array_3__mismatch_array_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__escaped_pointer_ref_4__slash_invalid()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJzbGFzaCI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__escaped_pointer_ref_4__tilda_invalid_2()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__escaped_pointer_ref_4__percent_invalid_3()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoiYW9ldSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__escaped_pointer_ref_4__slash_valid_4()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJzbGFzaCI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__escaped_pointer_ref_4__tilda_valid_5()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__escaped_pointer_ref_4__percent_valid_6()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoxMjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__nested_refs_5__nested_ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("NQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__nested_refs_5__nested_ref_invalid_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__ref_overrides_any_sibling_keywords_6__remote_ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__ref_overrides_any_sibling_keywords_6__remote_ref_valid__maxItems_ignored_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsM119");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__ref_overrides_any_sibling_keywords_6__ref_invalid_3()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJzdHJpbmcifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__remote_ref__containing_refs_itself_7__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wMy9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("ref")]
        public void Test_draft3__ref__remote_ref__containing_refs_itself_7__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wMy9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJpdGVtcyI6eyJ0eXBlIjoxfX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__remote_ref__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__remote_ref__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__fragment_within_remote_ref_2__remote_fragment_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__fragment_within_remote_ref_2__remote_fragment_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__ref_within_remote_ref_3__ref_within_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__ref_within_remote_ref_3__ref_within_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__change_resolution_scope_4__changed_scope_ref_valid()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC8iLCJpdGVtcyI6eyJpZCI6ImZvbGRlci8iLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W1sxXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("refRemote")]
        public void Test_draft3__refRemote__change_resolution_scope_4__changed_scope_ref_invalid_2()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC8iLCJpdGVtcyI6eyJpZCI6ImZvbGRlci8iLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W1siYSJdXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("required")]
        public void Test_draft3__required__required_validation__present_required_property_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJyZXF1aXJlZCI6dHJ1ZX0sImJhciI6e319fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("required")]
        public void Test_draft3__required__required_validation__non_present_required_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJyZXF1aXJlZCI6dHJ1ZX0sImJhciI6e319fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJiYXIiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("required")]
        public void Test_draft3__required__required_default_validation_2__not_required_by_default()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e319fQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("required")]
        public void Test_draft3__required__required_explicitly_false_validation_3__not_required_if_required_is_false()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJyZXF1aXJlZCI6ZmFsc2V9fX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__an_integer_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__a_float_is_not_an_integer_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__a_string_is_not_an_integer_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__a_string_is_still_not_an_integer__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__an_object_is_not_an_integer_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__an_array_is_not_an_integer_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__a_boolean_is_not_an_integer_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__integer_type_matches_integers__null_is_not_an_integer_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__an_integer_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__a_float_is_a_number_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__a_string_is_not_a_number_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__a_string_is_still_not_a_number__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__an_object_is_not_a_number_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__an_array_is_not_a_number_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__a_boolean_is_not_a_number_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__number_type_matches_numbers_2__null_is_not_a_number_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__1_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__a_float_is_not_a_string_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__a_string_is_a_string_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__a_string_is_still_a_string__even_if_it_looks_like_a_number_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__an_object_is_not_a_string_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__an_array_is_not_a_string_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__a_boolean_is_not_a_string_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__string_type_matches_strings_3__null_is_not_a_string_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__an_integer_is_not_an_object()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__a_float_is_not_an_object_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__a_string_is_not_an_object_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__an_object_is_an_object_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__an_array_is_not_an_object_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__a_boolean_is_not_an_object_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__object_type_matches_objects_4__null_is_not_an_object_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__an_integer_is_not_an_array()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__a_float_is_not_an_array_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__a_string_is_not_an_array_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__an_object_is_not_an_array_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__an_array_is_an_array_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__a_boolean_is_not_an_array_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__array_type_matches_arrays_5__null_is_not_an_array_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__an_integer_is_not_a_boolean()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__a_float_is_not_a_boolean_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__a_string_is_not_a_boolean_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__an_object_is_not_a_boolean_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__an_array_is_not_a_boolean_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__a_boolean_is_a_boolean_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__boolean_type_matches_booleans_6__null_is_not_a_boolean_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__an_integer_is_not_null()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__a_float_is_not_null_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__a_string_is_not_null_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__an_object_is_not_null_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__an_array_is_not_null_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__a_boolean_is_not_null_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__null_type_matches_only_the_null_object_7__null_is_null_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_integers()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_float_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_string_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_object_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_array_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_boolean_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__any_type_matches_any_type_8__any_type_includes_null_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYW55In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__an_integer_is_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__a_string_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__a_float_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__an_object_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__an_array_is_invalid_5()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__a_boolean_is_invalid_6()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__multiple_types_can_be_specified_in_an_array_9__null_is_invalid_7()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__an_integer_is_invalid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__a_string_is_invalid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__a_float_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__an_object_is_valid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__an_array_is_valid_5()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__a_boolean_is_invalid_6()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_can_include_schemas_10__null_is_invalid_7()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImFycmF5Iix7InR5cGUiOiJvYmplY3QifV19", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__when_types_includes_a_schema_it_should_fully_validate_the_schema_11__an_integer_is_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLHsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6Im51bGwifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__when_types_includes_a_schema_it_should_fully_validate_the_schema_11__an_object_is_valid_only_if_it_is_fully_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLHsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6Im51bGwifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOm51bGx9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__when_types_includes_a_schema_it_should_fully_validate_the_schema_11__an_object_is_invalid_otherwise_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLHsicHJvcGVydGllcyI6eyJmb28iOnsidHlwZSI6Im51bGwifX19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_from_separate_schemas_are_merged_12__an_integer_is_invalid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbeyJ0eXBlIjpbInN0cmluZyJdfSx7InR5cGUiOlsiYXJyYXkiLCJudWxsIl19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_from_separate_schemas_are_merged_12__a_string_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbeyJ0eXBlIjpbInN0cmluZyJdfSx7InR5cGUiOlsiYXJyYXkiLCJudWxsIl19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("type")]
        public void Test_draft3__type__types_from_separate_schemas_are_merged_12__an_array_is_valid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbeyJ0eXBlIjpbInN0cmluZyJdfSx7InR5cGUiOlsiYXJyYXkiLCJudWxsIl19XX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__unique_array_of_integers_is_valid()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__non_unique_array_of_integers_is_invalid_2()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__numbers_are_unique_if_mathematically_unequal_3()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEuMCwxLjAsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__unique_array_of_objects_is_valid_4()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXoifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__non_unique_array_of_objects_is_invalid_5()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXIifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__unique_array_of_nested_objects_is_valid_6()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6ZmFsc2V9fX1d");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__non_unique_array_of_nested_objects_is_invalid_7()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6dHJ1ZX19fV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__unique_array_of_arrays_is_valid_8()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJiYXIiXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__non_unique_array_of_arrays_is_invalid_9()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJmb28iXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__1_and_true_are_unique_10()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzEsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__0_and_false_are_unique_11()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("WzAsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__unique_heterogeneous_types_are_valid_12()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3")]
        [TestCategory("uniqueItems")]
        public void Test_draft3__uniqueItems__uniqueItems_validation__non_unique_heterogeneous_types_are_invalid_13()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwse30sMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__integer__a_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTIzNDU2Nzg5MTAxMTEyMTMxNDE1MTYxNzE4MTkyMDIxMjIyMzI0MjUyNjI3MjgyOTMwMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__number_2__a_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__integer_3__a_negative_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("LTEyMzQ1Njc4OTEwMTExMjEzMTQxNTE2MTcxODE5MjAyMTIyMjMyNDI1MjYyNzI4MjkzMDMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__number_4__a_negative_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("LTk4MjQ5MjgzNzQ5MjM0OTIzNDk4MjkzMTcxODIzOTQ4NzI5MzQ4NzEwMjk4MzAxOTI4MzMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__string_5__a_bignum_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__integer_comparison_6__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjoxODQ0Njc0NDA3MzcwOTU1MTYxNX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MTg0NDY3NDQwNzM3MDk1NTE2MDA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__float_comparison_with_high_precision_7__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjo5LjcyNzgzNzk4MTg3OTg3MTJFKzI2LCJleGNsdXNpdmVNYXhpbXVtIjp0cnVlfQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("OS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__integer_comparison_8__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjotMTg0NDY3NDQwNzM3MDk1NTE2MTV9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("LTE4NDQ2NzQ0MDczNzA5NTUxNjAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("bignum")]
        public void Test_draft3_optional__bignum__float_comparison_with_high_precision_on_negative_numbers_9__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjotOS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNiwiZXhjbHVzaXZlTWluaW11bSI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("LTkuNzI3ODM3OTgxODc5ODcxMkUrMjY=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_regular_expressions__a_valid_regular_expression()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IihbYWJjXSkrXFxzKyQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_regular_expressions__a_regular_expression_with_unclosed_parens_is_invalid_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Il4oYWJjXSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_date_time_strings_2__a_valid_date_time_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDYuMjgzMTg1WiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_date_time_strings_2__an_invalid_date_time_string_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjA2LzE5LzE5NjMgMDg6MzA6MDYgUFNUIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_date_time_strings_2__case_insensitive_T_and_Z_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTl0MDg6MzA6MDYuMjgzMTg1eiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_date_time_strings_2__only_RFC3339_not_all_of_ISO_8601_are_valid_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjIwMTMtMzUwVDAxOjAxOjAxIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_date_strings_3__a_valid_date_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_date_strings_3__an_invalid_date_string_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjA2LzE5LzE5NjMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_time_strings_4__a_valid_time_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ0aW1lIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjA4OjMwOjA2Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_time_strings_4__an_invalid_time_string_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ0aW1lIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ijg6MzAgQU0i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_URIs_5__a_valid_URI()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9iYXo9cXV4I3F1dXgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_URIs_5__an_invalid_protocol_relative_URI_Reference_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ii8vZm9vLmJhci8/YmF6PXF1eCNxdXV4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_URIs_5__an_invalid_URI_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWxlc2hhcmUi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_URIs_5__an_invalid_URI_though_valid_URI_reference_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_e_mail_addresses_6__a_valid_e_mail_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImpvZS5ibG9nZ3NAZXhhbXBsZS5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_e_mail_addresses_6__an_invalid_e_mail_address_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjI5NjIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IP_addresses_7__a_valid_IP_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcC1hZGRyZXNzIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjE5Mi4xNjguMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IP_addresses_7__an_IP_address_with_too_many_components_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcC1hZGRyZXNzIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjEyNy4wLjAuMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IP_addresses_7__an_IP_address_with_out_of_range_values_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcC1hZGRyZXNzIn0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjI1Ni4yNTYuMjU2LjI1NiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IPv6_addresses_8__a_valid_IPv6_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ijo6MSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IPv6_addresses_8__an_IPv6_address_with_out_of_range_values_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjEyMzQ1Ojoi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IPv6_addresses_8__an_IPv6_address_with_too_many_components_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IjE6MToxOjE6MToxOjE6MToxOjE6MToxOjE6MToxOjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_IPv6_addresses_8__an_IPv6_address_containing_illegal_characters_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ijo6bGFwdG9wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_host_names_9__a_valid_host_name()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0LW5hbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ind3dy5leGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_host_names_9__a_host_name_starting_with_an_illegal_character_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0LW5hbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Ii1hLWhvc3QtbmFtZS10aGF0LXN0YXJ0cy13aXRoLS0i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_host_names_9__a_host_name_containing_illegal_characters_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0LW5hbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Im5vdF9hX3ZhbGlkX2hvc3RfbmFtZSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_host_names_9__a_host_name_with_a_component_too_long_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0LW5hbWUifQ==", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImEtdnZ2dnZ2dnZ2dnZ2dnZ2dmVlZWVlZWVlZWVlZWVlZWVycnJycnJycnJycnJycnJyeXl5eXl5eXl5eXl5eXl5eS1sb25nLWhvc3QtbmFtZS1jb21wb25lbnQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_CSS_colors_10__a_valid_CSS_color_name()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJjb2xvciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImZ1Y2hzaWEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_CSS_colors_10__a_valid_six_digit_CSS_color_code_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJjb2xvciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IiNDQzg4OTki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_CSS_colors_10__a_valid_three_digit_CSS_color_code_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJjb2xvciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IiNDODki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_CSS_colors_10__an_invalid_CSS_color_code_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJjb2xvciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IiMwMDMzMjUyMCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_CSS_colors_10__an_invalid_CSS_color_name_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJjb2xvciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("InB1Y2Ui");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("format")]
        public void Test_draft3_optional__format__validation_of_CSS_colors_10__a_CSS_color_name_containing_invalid_characters_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJjb2xvciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("ImxpZ2h0X2dyYXlpc2hfcmVkLXZpb2xldCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("jsregex")]
        public void Test_draft3_optional__jsregex__ECMA_262_regex_dialect_recognition______is_a_valid_regex()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("IlteXSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("jsregex")]
        public void Test_draft3_optional__jsregex__ECMA_262_regex_dialect_recognition__ECMA_262_has_no_support_for_lookbehind_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("Iig/PD1mb28pYmFyIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft3_optional")]
        [TestCategory("zeroTerminatedFloats")]
        public void Test_draft3_optional__zeroTerminatedFloats__some_languages_do_not_distinguish_between_different_types_of_numeric_value__a_float_is_not_an_integer_even_without_fractional_part()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-03/schema#"));
            var t = ParseElement("MS4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__additionalItems_as_schema__additional_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9XSwiYWRkaXRpb25hbEl0ZW1zIjp7InR5cGUiOiJpbnRlZ2VyIn19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W251bGwsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__additionalItems_as_schema__additional_items_do_not_match_schema_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9XSwiYWRkaXRpb25hbEl0ZW1zIjp7InR5cGUiOiJpbnRlZ2VyIn19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W251bGwsMiwzLCJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__items_is_schema__no_additionalItems_2__all_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6e30sImFkZGl0aW9uYWxJdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__array_of_items_with_no_additionalItems_3__fewer_number_of_items_present()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__array_of_items_with_no_additionalItems_3__equal_number_of_items_present_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__array_of_items_with_no_additionalItems_3__additional_items_are_not_permitted_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__additionalItems_as_false_without_items_4__items_defaults_to_empty_schema_so_everything_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__additionalItems_as_false_without_items_4__ignores_non_arrays_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalItems")]
        public void Test_draft4__additionalItems__additionalItems_are_allowed_by_default_5__only_the_first_item_is_validated()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsImZvbyIsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__an_additional_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6ImJvb20ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvb2JhcmJheiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__patternProperties_are_not_additional_properties_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsInZyb29tIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__matching_the_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyLDoXJtw6FueW9zIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__not_matching_the_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyLDqWxtw6lueSI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_valid_property_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_invalid_property_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6MTJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_valid_property_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_invalid_property_is_invalid_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("additionalProperties")]
        public void Test_draft4__additionalProperties__additionalProperties_are_allowed_by_default_5__additional_properties_are_allowed()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf__allOf()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf__mismatch_second_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf__mismatch_first_3()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf__wrong_type_4()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_with_base_schema_2__valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyLCJiYXoiOm51bGx9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_with_base_schema_2__mismatch_base_schema_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmF6IjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_with_base_schema_2__mismatch_first_allOf_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjIsImJheiI6bnVsbH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_with_base_schema_2__mismatch_second_allOf_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_with_base_schema_2__mismatch_both_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_simple_types_3__valid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sibWF4aW11bSI6MzB9LHsibWluaW11bSI6MjB9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MjU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("allOf")]
        public void Test_draft4__allOf__allOf_simple_types_3__mismatch_one_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sibWF4aW11bSI6MzB9LHsibWluaW11bSI6MjB9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf__first_anyOf_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf__second_anyOf_valid_2()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf__both_anyOf_valid_3()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf__neither_anyOf_valid_4()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_with_base_schema_2__mismatch_base_schema()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_with_base_schema_2__one_anyOf_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_with_base_schema_2__both_anyOf_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_complex_types_3__first_anyOf_valid__complex_()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_complex_types_3__second_anyOf_valid__complex__2()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_complex_types_3__both_anyOf_valid__complex__3()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("anyOf")]
        public void Test_draft4__anyOf__anyOf_complex_types_3__neither_anyOf_valid__complex__4()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("default")]
        public void Test_draft4__default__invalid_type_for_default__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("default")]
        public void Test_draft4__default__invalid_type_for_default__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("default")]
        public void Test_draft4__default__invalid_string_value_for_default_2__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOiJnb29kIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("default")]
        public void Test_draft4__default__invalid_string_value_for_default_2__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("definitions")]
        public void Test_draft4__definitions__valid_definition__valid_definition_schema()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNC9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJkZWZpbml0aW9ucyI6eyJmb28iOnsidHlwZSI6ImludGVnZXIifX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("definitions")]
        public void Test_draft4__definitions__invalid_definition_2__invalid_definition_schema()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNC9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJkZWZpbml0aW9ucyI6eyJmb28iOnsidHlwZSI6MX19fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__nondependant_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__with_dependency_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__ignores_arrays_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WyJiYXIiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__ignores_strings_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__dependencies__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_2__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_2__nondependants_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_2__with_dependencies_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_2__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_2__missing_other_dependency_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_2__missing_both_dependencies_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJxdXV4IjoxfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_subschema_3__valid()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_subschema_3__no_dependency_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_subschema_3__wrong_type_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_subschema_3__wrong_type_other_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("dependencies")]
        public void Test_draft4__dependencies__multiple_dependencies_subschema_3__wrong_type_both_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoicXV1eCJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__simple_enum_validation__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__simple_enum_validation__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("NA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__heterogeneous_enum_validation_2__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__heterogeneous_enum_validation_2__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__heterogeneous_enum_validation_2__objects_are_deep_compared_3()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__enums_in_properties_3__both_properties_are_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28iLCJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__enums_in_properties_3__missing_optional_property_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__enums_in_properties_3__missing_required_property_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("enum")]
        public void Test_draft4__enum__enums_in_properties_3__missing_all_properties_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__a_schema_given_for_items__valid_items()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__a_schema_given_for_items__wrong_type_of_items_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsIngiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__a_schema_given_for_items__ignores_non_arrays_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__a_schema_given_for_items__JavaScript_pseudo_array_is_valid_4()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyIwIjoiaW52YWxpZCIsImxlbmd0aCI6MX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__an_array_of_schemas_for_items_2__correct_types()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__an_array_of_schemas_for_items_2__wrong_types_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WyJmb28iLDFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__an_array_of_schemas_for_items_2__incomplete_array_of_items_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__an_array_of_schemas_for_items_2__array_with_additional_items_4()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__an_array_of_schemas_for_items_2__empty_array_5()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("items")]
        public void Test_draft4__items__an_array_of_schemas_for_items_2__JavaScript_pseudo_array_is_valid_6()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyIwIjoiaW52YWxpZCIsIjEiOiJ2YWxpZCIsImxlbmd0aCI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__below_the_maximum_is_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__above_the_maximum_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__explicit_false_exclusivity__2__below_the_maximum_is_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__explicit_false_exclusivity__2__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__explicit_false_exclusivity__2__above_the_maximum_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__maximum_validation__explicit_false_exclusivity__2__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__exclusiveMaximum_validation_3__below_the_maximum_is_still_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maximum")]
        public void Test_draft4__maximum__exclusiveMaximum_validation_3__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjAsImV4Y2x1c2l2ZU1heGltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxItems")]
        public void Test_draft4__maxItems__maxItems_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxItems")]
        public void Test_draft4__maxItems__maxItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxItems")]
        public void Test_draft4__maxItems__maxItems_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxItems")]
        public void Test_draft4__maxItems__maxItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxLength")]
        public void Test_draft4__maxLength__maxLength_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxLength")]
        public void Test_draft4__maxLength__maxLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxLength")]
        public void Test_draft4__maxLength__maxLength_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxLength")]
        public void Test_draft4__maxLength__maxLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxLength")]
        public void Test_draft4__maxLength__maxLength_validation__two_supplementary_Unicode_code_points_is_long_enough_5()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IvCfkqnwn5KpIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxProperties")]
        public void Test_draft4__maxProperties__maxProperties_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxProperties")]
        public void Test_draft4__maxProperties__maxProperties_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxProperties")]
        public void Test_draft4__maxProperties__maxProperties_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwiYmF6IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxProperties")]
        public void Test_draft4__maxProperties__maxProperties_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxProperties")]
        public void Test_draft4__maxProperties__maxProperties_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("maxProperties")]
        public void Test_draft4__maxProperties__maxProperties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__above_the_minimum_is_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__below_the_minimum_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__explicit_false_exclusivity__2__above_the_minimum_is_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__explicit_false_exclusivity__2__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__explicit_false_exclusivity__2__below_the_minimum_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__minimum_validation__explicit_false_exclusivity__2__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__exclusiveMinimum_validation_3__above_the_minimum_is_still_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minimum")]
        public void Test_draft4__minimum__exclusiveMinimum_validation_3__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjEsImV4Y2x1c2l2ZU1pbmltdW0iOnRydWV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minItems")]
        public void Test_draft4__minItems__minItems_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minItems")]
        public void Test_draft4__minItems__minItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minItems")]
        public void Test_draft4__minItems__minItems_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minItems")]
        public void Test_draft4__minItems__minItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minLength")]
        public void Test_draft4__minLength__minLength_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minLength")]
        public void Test_draft4__minLength__minLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minLength")]
        public void Test_draft4__minLength__minLength_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minLength")]
        public void Test_draft4__minLength__minLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minLength")]
        public void Test_draft4__minLength__minLength_validation__one_supplementary_Unicode_code_point_is_not_long_enough_5()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IvCfkqki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minProperties")]
        public void Test_draft4__minProperties__minProperties_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minProperties")]
        public void Test_draft4__minProperties__minProperties_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minProperties")]
        public void Test_draft4__minProperties__minProperties_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minProperties")]
        public void Test_draft4__minProperties__minProperties_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minProperties")]
        public void Test_draft4__minProperties__minProperties_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("minProperties")]
        public void Test_draft4__minProperties__minProperties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_int__int_by_int()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_int__int_by_int_fail_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Nw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_int__ignores_non_numbers_3()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_number_2__zero_is_multiple_of_anything()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_number_2__4_5_is_multiple_of_1_5_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("NC41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_number_2__35_is_not_multiple_of_1_5_3()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_small_number_3__0_0075_is_multiple_of_0_0001()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjowLjAwMDF9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MC4wMDc1");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("multipleOf")]
        public void Test_draft4__multipleOf__by_small_number_3__0_00751_is_not_multiple_of_0_0001_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjowLjAwMDF9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MC4wMDc1MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not__allowed()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6ImludGVnZXIifX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not__disallowed_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6ImludGVnZXIifX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not_multiple_types_2__valid()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not_multiple_types_2__mismatch_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not_multiple_types_2__other_mismatch_3()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not_more_complex_schema_3__match()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not_more_complex_schema_3__other_match_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__not_more_complex_schema_3__mismatch_3()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__forbidden_property_4__property_present()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJub3QiOnt9fX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("not")]
        public void Test_draft4__not__forbidden_property_4__property_absent_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJub3QiOnt9fX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjEsImJheiI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf__first_oneOf_valid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf__second_oneOf_valid_2()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mi41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf__both_oneOf_valid_3()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf__neither_oneOf_valid_4()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_with_base_schema_2__mismatch_base_schema()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_with_base_schema_2__one_oneOf_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_with_base_schema_2__both_oneOf_valid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_complex_types_3__first_oneOf_valid__complex_()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_complex_types_3__second_oneOf_valid__complex__2()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_complex_types_3__both_oneOf_valid__complex__3()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("oneOf")]
        public void Test_draft4__oneOf__oneOf_complex_types_3__neither_oneOf_valid__complex__4()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("pattern")]
        public void Test_draft4__pattern__pattern_validation__a_matching_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImFhYSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("pattern")]
        public void Test_draft4__pattern__pattern_validation__a_non_matching_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("pattern")]
        public void Test_draft4__pattern__pattern_validation__ignores_non_strings_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("pattern")]
        public void Test_draft4__pattern__pattern_is_not_anchored_2__matches_a_substring()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiYSsifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Inh4YWF5eSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_valid_matches_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImZvb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_invalid_match_is_invalid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_invalid_matches_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb29vIjoiYmF6In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_strings_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhIjoyMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_simultaneous_match_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhYWFhIjoxOH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__multiple_matches_is_valid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhIjoyMSwiYWFhYSI6MTh9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_one_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhIjoiYmFyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_the_other_is_invalid_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_both_is_invalid_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhYWEiOiJmb28iLCJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__non_recognized_members_are_ignored()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhbnN3ZXIgMSI6IjQyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__recognized_members_are_accounted_for_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhMzFiIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhX3hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("patternProperties")]
        public void Test_draft4__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive__2_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJhX1hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__object_properties_validation__both_properties_present_and_valid_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6ImJheiJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__object_properties_validation__one_property_invalid_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6e319");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__object_properties_validation__both_properties_invalid_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOltdLCJiYXIiOnt9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__object_properties_validation__doesn_t_invalidate_other_properties_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJxdXV4IjpbXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__object_properties_validation__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__object_properties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__property_validates_property()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__property_invalidates_property_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsMyw0XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_property_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_validates_nonproperty_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmeG8iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_nonproperty_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmeG8iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_ignores_property_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_validates_others_7()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJxdXV4IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("properties")]
        public void Test_draft4__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_invalidates_others_8()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJxdXV4IjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__root_pointer_ref__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__root_pointer_ref__recursive_match_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOnsiZm9vIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__root_pointer_ref__mismatch_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__root_pointer_ref__recursive_mismatch_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOnsiYmFyIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__relative_pointer_ref_to_object_2__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__relative_pointer_ref_to_object_2__mismatch_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__relative_pointer_ref_to_array_3__match_array()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__relative_pointer_ref_to_array_3__mismatch_array_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__escaped_pointer_ref_4__slash_invalid()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJzbGFzaCI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__escaped_pointer_ref_4__tilda_invalid_2()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__escaped_pointer_ref_4__percent_invalid_3()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoiYW9ldSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__escaped_pointer_ref_4__slash_valid_4()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJzbGFzaCI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__escaped_pointer_ref_4__tilda_valid_5()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__escaped_pointer_ref_4__percent_valid_6()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoxMjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__nested_refs_5__nested_ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("NQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__nested_refs_5__nested_ref_invalid_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__ref_overrides_any_sibling_keywords_6__ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__ref_overrides_any_sibling_keywords_6__ref_valid__maxItems_ignored_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsM119");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__ref_overrides_any_sibling_keywords_6__ref_invalid_3()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOiJzdHJpbmcifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__remote_ref__containing_refs_itself_7__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNC9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJtaW5MZW5ndGgiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__remote_ref__containing_refs_itself_7__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNC9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJtaW5MZW5ndGgiOi0xfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__property_named__ref_that_is_not_a_reference_8__property_named__ref_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7IiRyZWYiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyIkcmVmIjoiYSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__property_named__ref_that_is_not_a_reference_8__property_named__ref_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7IiRyZWYiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyIkcmVmIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__Recursive_references_between_schemas_9__valid_tree()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC90cmVlIiwiZGVzY3JpcHRpb24iOiJ0cmVlIG9mIG5vZGVzIiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibWV0YSI6eyJ0eXBlIjoic3RyaW5nIn0sIm5vZGVzIjp7InR5cGUiOiJhcnJheSIsIml0ZW1zIjp7IiRyZWYiOiJub2RlIn19fSwicmVxdWlyZWQiOlsibWV0YSIsIm5vZGVzIl0sImRlZmluaXRpb25zIjp7Im5vZGUiOnsiaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvbm9kZSIsImRlc2NyaXB0aW9uIjoibm9kZSIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7InZhbHVlIjp7InR5cGUiOiJudW1iZXIifSwic3VidHJlZSI6eyIkcmVmIjoidHJlZSJ9fSwicmVxdWlyZWQiOlsidmFsdWUiXX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJtZXRhIjoicm9vdCIsIm5vZGVzIjpbeyJ2YWx1ZSI6MSwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOjEuMX0seyJ2YWx1ZSI6MS4yfV19fSx7InZhbHVlIjoyLCJzdWJ0cmVlIjp7Im1ldGEiOiJjaGlsZCIsIm5vZGVzIjpbeyJ2YWx1ZSI6Mi4xfSx7InZhbHVlIjoyLjJ9XX19XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("ref")]
        public void Test_draft4__ref__Recursive_references_between_schemas_9__invalid_tree_2()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC90cmVlIiwiZGVzY3JpcHRpb24iOiJ0cmVlIG9mIG5vZGVzIiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibWV0YSI6eyJ0eXBlIjoic3RyaW5nIn0sIm5vZGVzIjp7InR5cGUiOiJhcnJheSIsIml0ZW1zIjp7IiRyZWYiOiJub2RlIn19fSwicmVxdWlyZWQiOlsibWV0YSIsIm5vZGVzIl0sImRlZmluaXRpb25zIjp7Im5vZGUiOnsiaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvbm9kZSIsImRlc2NyaXB0aW9uIjoibm9kZSIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7InZhbHVlIjp7InR5cGUiOiJudW1iZXIifSwic3VidHJlZSI6eyIkcmVmIjoidHJlZSJ9fSwicmVxdWlyZWQiOlsidmFsdWUiXX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJtZXRhIjoicm9vdCIsIm5vZGVzIjpbeyJ2YWx1ZSI6MSwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOiJzdHJpbmcgaXMgaW52YWxpZCJ9LHsidmFsdWUiOjEuMn1dfX0seyJ2YWx1ZSI6Miwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOjIuMX0seyJ2YWx1ZSI6Mi4yfV19fV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__remote_ref__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__remote_ref__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__fragment_within_remote_ref_2__remote_fragment_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__fragment_within_remote_ref_2__remote_fragment_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__ref_within_remote_ref_3__ref_within_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__ref_within_remote_ref_3__ref_within_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__base_URI_change_4__base_URI_change_ref_valid()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC8iLCJpdGVtcyI6eyJpZCI6ImZvbGRlci8iLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W1sxXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__base_URI_change_4__base_URI_change_ref_invalid_2()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC8iLCJpdGVtcyI6eyJpZCI6ImZvbGRlci8iLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W1siYSJdXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__base_URI_change___change_folder_5__number_is_valid()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9zY29wZV9jaGFuZ2VfZGVmczEuanNvbiIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Imxpc3QiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYmF6In19LCJkZWZpbml0aW9ucyI6eyJiYXoiOnsiaWQiOiJmb2xkZXIvIiwidHlwZSI6ImFycmF5IiwiaXRlbXMiOnsiJHJlZiI6ImZvbGRlckludGVnZXIuanNvbiJ9fX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJsaXN0IjpbMV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__base_URI_change___change_folder_5__string_is_invalid_2()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9zY29wZV9jaGFuZ2VfZGVmczEuanNvbiIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Imxpc3QiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYmF6In19LCJkZWZpbml0aW9ucyI6eyJiYXoiOnsiaWQiOiJmb2xkZXIvIiwidHlwZSI6ImFycmF5IiwiaXRlbXMiOnsiJHJlZiI6ImZvbGRlckludGVnZXIuanNvbiJ9fX19", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJsaXN0IjpbImEiXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__base_URI_change___change_folder_in_subschema_6__number_is_valid()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9zY29wZV9jaGFuZ2VfZGVmczIuanNvbiIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Imxpc3QiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYmF6L2RlZmluaXRpb25zL2JhciJ9fSwiZGVmaW5pdGlvbnMiOnsiYmF6Ijp7ImlkIjoiZm9sZGVyLyIsImRlZmluaXRpb25zIjp7ImJhciI6eyJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJsaXN0IjpbMV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__base_URI_change___change_folder_in_subschema_6__string_is_invalid_2()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9zY29wZV9jaGFuZ2VfZGVmczIuanNvbiIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Imxpc3QiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYmF6L2RlZmluaXRpb25zL2JhciJ9fSwiZGVmaW5pdGlvbnMiOnsiYmF6Ijp7ImlkIjoiZm9sZGVyLyIsImRlZmluaXRpb25zIjp7ImJhciI6eyJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fX19fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJsaXN0IjpbImEiXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__root_ref_in_remote_ref_7__string_is_valid()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9vYmplY3QiLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJuYW1lIjp7IiRyZWYiOiJuYW1lLmpzb24jL2RlZmluaXRpb25zL29yTnVsbCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJuYW1lIjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__root_ref_in_remote_ref_7__null_is_valid_2()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9vYmplY3QiLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJuYW1lIjp7IiRyZWYiOiJuYW1lLmpzb24jL2RlZmluaXRpb25zL29yTnVsbCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJuYW1lIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("refRemote")]
        public void Test_draft4__refRemote__root_ref_in_remote_ref_7__object_is_invalid_3()
        {
            var s = ParseSchema("eyJpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9vYmplY3QiLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJuYW1lIjp7IiRyZWYiOiJuYW1lLmpzb24jL2RlZmluaXRpb25zL29yTnVsbCJ9fX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJuYW1lIjp7Im5hbWUiOm51bGx9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("required")]
        public void Test_draft4__required__required_validation__present_required_property_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("required")]
        public void Test_draft4__required__required_validation__non_present_required_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("eyJiYXIiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("required")]
        public void Test_draft4__required__required_validation__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("required")]
        public void Test_draft4__required__required_validation__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("required")]
        public void Test_draft4__required__required_validation__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("required")]
        public void Test_draft4__required__required_default_validation_2__not_required_by_default()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e319fQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__an_integer_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__a_float_is_not_an_integer_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__a_string_is_not_an_integer_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__a_string_is_still_not_an_integer__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__an_object_is_not_an_integer_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__an_array_is_not_an_integer_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__a_boolean_is_not_an_integer_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__integer_type_matches_integers__null_is_not_an_integer_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__an_integer_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__a_float_is_a_number_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__a_string_is_not_a_number_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__a_string_is_still_not_a_number__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__an_object_is_not_a_number_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__an_array_is_not_a_number_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__a_boolean_is_not_a_number_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__number_type_matches_numbers_2__null_is_not_a_number_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__1_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__a_float_is_not_a_string_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__a_string_is_a_string_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__a_string_is_still_a_string__even_if_it_looks_like_a_number_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__an_object_is_not_a_string_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__an_array_is_not_a_string_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__a_boolean_is_not_a_string_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__string_type_matches_strings_3__null_is_not_a_string_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__an_integer_is_not_an_object()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__a_float_is_not_an_object_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__a_string_is_not_an_object_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__an_object_is_an_object_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__an_array_is_not_an_object_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__a_boolean_is_not_an_object_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__object_type_matches_objects_4__null_is_not_an_object_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__an_integer_is_not_an_array()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__a_float_is_not_an_array_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__a_string_is_not_an_array_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__an_object_is_not_an_array_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__an_array_is_an_array_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__a_boolean_is_not_an_array_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__array_type_matches_arrays_5__null_is_not_an_array_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__an_integer_is_not_a_boolean()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__a_float_is_not_a_boolean_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__a_string_is_not_a_boolean_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__an_object_is_not_a_boolean_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__an_array_is_not_a_boolean_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__a_boolean_is_a_boolean_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__boolean_type_matches_booleans_6__null_is_not_a_boolean_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__an_integer_is_not_null()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__a_float_is_not_null_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__a_string_is_not_null_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__an_object_is_not_null_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__an_array_is_not_null_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__a_boolean_is_not_null_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__null_type_matches_only_the_null_object_7__null_is_null_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__an_integer_is_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__a_string_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__a_float_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__an_object_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__an_array_is_invalid_5()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__a_boolean_is_invalid_6()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("type")]
        public void Test_draft4__type__multiple_types_can_be_specified_in_an_array_8__null_is_invalid_7()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__unique_array_of_integers_is_valid()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__non_unique_array_of_integers_is_invalid_2()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__numbers_are_unique_if_mathematically_unequal_3()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEuMCwxLjAsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__unique_array_of_objects_is_valid_4()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXoifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__non_unique_array_of_objects_is_invalid_5()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXIifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__unique_array_of_nested_objects_is_valid_6()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6ZmFsc2V9fX1d");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__non_unique_array_of_nested_objects_is_invalid_7()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6dHJ1ZX19fV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__unique_array_of_arrays_is_valid_8()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJiYXIiXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__non_unique_array_of_arrays_is_invalid_9()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJmb28iXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__1_and_true_are_unique_10()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzEsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__0_and_false_are_unique_11()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("WzAsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__unique_heterogeneous_types_are_valid_12()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4")]
        [TestCategory("uniqueItems")]
        public void Test_draft4__uniqueItems__uniqueItems_validation__non_unique_heterogeneous_types_are_invalid_13()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwse30sMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__integer__a_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTIzNDU2Nzg5MTAxMTEyMTMxNDE1MTYxNzE4MTkyMDIxMjIyMzI0MjUyNjI3MjgyOTMwMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__number_2__a_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__integer_3__a_negative_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("LTEyMzQ1Njc4OTEwMTExMjEzMTQxNTE2MTcxODE5MjAyMTIyMjMyNDI1MjYyNzI4MjkzMDMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__number_4__a_negative_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("LTk4MjQ5MjgzNzQ5MjM0OTIzNDk4MjkzMTcxODIzOTQ4NzI5MzQ4NzEwMjk4MzAxOTI4MzMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__string_5__a_bignum_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__integer_comparison_6__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjoxODQ0Njc0NDA3MzcwOTU1MTYxNX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MTg0NDY3NDQwNzM3MDk1NTE2MDA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__float_comparison_with_high_precision_7__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjo5LjcyNzgzNzk4MTg3OTg3MTJFKzI2LCJleGNsdXNpdmVNYXhpbXVtIjp0cnVlfQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("OS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__integer_comparison_8__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjotMTg0NDY3NDQwNzM3MDk1NTE2MTV9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("LTE4NDQ2NzQ0MDczNzA5NTUxNjAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("bignum")]
        public void Test_draft4_optional__bignum__float_comparison_with_high_precision_on_negative_numbers_9__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjotOS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNiwiZXhjbHVzaXZlTWluaW11bSI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("LTkuNzI3ODM3OTgxODc5ODcxMkUrMjY=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("ecmascript-regex")]
        public void Test_draft4_optional__ecmascript_regex__ECMA_262_regex_non_compliance__ECMA_262_has_no_support_for__Z_anchor_from__NET()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Il5cXFMofCgufFxcbikqXFxTKVxcWiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__a_valid_date_time_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDYuMjgzMTg1WiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__a_valid_date_time_string_without_second_fraction_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDZaIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__a_valid_date_time_string_with_plus_offset_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5MzctMDEtMDFUMDU6NDA6MjcuODctMDY6MDAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__a_valid_date_time_string_with_minus_offset_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5OTAtMTItMzFUMTc6NTk6NTAuMTIzLTA2OjAwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__a_invalid_day_in_date_time_string_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5OTAtMDItMzFUMTU6NTk6NjAuMTIzLTA4OjAwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__an_invalid_offset_in_date_time_string_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5OTAtMTItMzFUMTU6NTk6NjAtMjQ6MDAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__an_invalid_date_time_string_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjA2LzE5LzE5NjMgMDg6MzA6MDYgUFNUIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__case_insensitive_T_and_Z_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTl0MDg6MzA6MDYuMjgzMTg1eiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_date_time_strings__only_RFC3339_not_all_of_ISO_8601_are_valid_9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjIwMTMtMzUwVDAxOjAxOjAxIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_with_anchor_tag()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9iYXo9cXV4I3F1dXgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_with_anchor_tag_and_parantheses_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uY29tL2JsYWhfKHdpa2lwZWRpYSlfYmxhaCNjaXRlLTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_with_URL_encoded_stuff_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9xPVRlc3QlMjBVUkwtZW5jb2RlZCUyMHN0dWZmIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_puny_coded_URL__4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly94bi0tbncyYS54bi0tajZ3MTkzZy8i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_with_many_special_characters_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly8tLn5fISQmJygpKissOz06JTQwOjgwJTJmOjo6Ojo6QGV4YW1wbGUuY29tIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_based_on_IPv4_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly8yMjMuMjU1LjI1NS4yNTQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_with_ftp_scheme_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImZ0cDovL2Z0cC5pcy5jby56YS9yZmMvcmZjMTgwOC50eHQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL_for_a_simple_text_file_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly93d3cuaWV0Zi5vcmcvcmZjL3JmYzIzOTYudHh0Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URL__9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImxkYXA6Ly9bMjAwMTpkYjg6OjddL2M9R0I/b2JqZWN0Q2xhc3M/b25lIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_mailto_URI_10()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Im1haWx0bzpKb2huLkRvZUBleGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_newsgroup_URI_11()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Im5ld3M6Y29tcC5pbmZvc3lzdGVtcy53d3cuc2VydmVycy51bml4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_tel_URI_12()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("InRlbDorMS04MTYtNTU1LTEyMTIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__a_valid_URN_13()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOmRvY2Jvb2s6ZHRkOnhtbDo0LjEuMiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__an_invalid_protocol_relative_URI_Reference_14()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ii8vZm9vLmJhci8/YmF6PXF1eCNxdXV4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__an_invalid_relative_URI_Reference_15()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ii9hYmMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__an_invalid_URI_16()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWxlc2hhcmUi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__an_invalid_URI_though_valid_URI_reference_17()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__an_invalid_URI_with_spaces_18()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Imh0dHA6Ly8gc2hvdWxkZmFpbC5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_URIs_2__an_invalid_URI_with_spaces_and_missing_scheme_19()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjovLyBzaG91bGQgZmFpbCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_e_mail_addresses_3__a_valid_e_mail_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImpvZS5ibG9nZ3NAZXhhbXBsZS5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_e_mail_addresses_3__an_invalid_e_mail_address_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjI5NjIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IP_addresses_4__a_valid_IP_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE5Mi4xNjguMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IP_addresses_4__an_IP_address_with_too_many_components_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjEyNy4wLjAuMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IP_addresses_4__an_IP_address_with_out_of_range_values_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjI1Ni4yNTYuMjU2LjI1NiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IP_addresses_4__an_IP_address_without_4_components_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjEyNy4wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IP_addresses_4__an_IP_address_as_an_integer_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjB4N2YwMDAwMDEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IPv6_addresses_5__a_valid_IPv6_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ijo6MSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IPv6_addresses_5__an_IPv6_address_with_out_of_range_values_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjEyMzQ1Ojoi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IPv6_addresses_5__an_IPv6_address_with_too_many_components_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("IjE6MToxOjE6MToxOjE6MToxOjE6MToxOjE6MToxOjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_IPv6_addresses_5__an_IPv6_address_containing_illegal_characters_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ijo6bGFwdG9wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_host_names_6__a_valid_host_name()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ind3dy5leGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_host_names_6__a_host_name_starting_with_an_illegal_character_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Ii1hLWhvc3QtbmFtZS10aGF0LXN0YXJ0cy13aXRoLS0i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_host_names_6__a_host_name_containing_illegal_characters_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("Im5vdF9hX3ZhbGlkX2hvc3RfbmFtZSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("format")]
        public void Test_draft4_optional__format__validation_of_host_names_6__a_host_name_with_a_component_too_long_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("ImEtdnZ2dnZ2dnZ2dnZ2dnZ2dmVlZWVlZWVlZWVlZWVlZWVycnJycnJycnJycnJycnJyeXl5eXl5eXl5eXl5eXl5eS1sb25nLWhvc3QtbmFtZS1jb21wb25lbnQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft4_optional")]
        [TestCategory("zeroTerminatedFloats")]
        public void Test_draft4_optional__zeroTerminatedFloats__some_languages_do_not_distinguish_between_different_types_of_numeric_value__a_float_is_not_an_integer_even_without_fractional_part()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-04/schema#"));
            var t = ParseElement("MS4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__additionalItems_as_schema__additional_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9XSwiYWRkaXRpb25hbEl0ZW1zIjp7InR5cGUiOiJpbnRlZ2VyIn19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W251bGwsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__additionalItems_as_schema__additional_items_do_not_match_schema_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9XSwiYWRkaXRpb25hbEl0ZW1zIjp7InR5cGUiOiJpbnRlZ2VyIn19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W251bGwsMiwzLCJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__items_is_schema__no_additionalItems_2__all_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6e30sImFkZGl0aW9uYWxJdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__array_of_items_with_no_additionalItems_3__fewer_number_of_items_present()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__array_of_items_with_no_additionalItems_3__equal_number_of_items_present_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__array_of_items_with_no_additionalItems_3__additional_items_are_not_permitted_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__additionalItems_as_false_without_items_4__items_defaults_to_empty_schema_so_everything_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__additionalItems_as_false_without_items_4__ignores_non_arrays_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalItems")]
        public void Test_draft6__additionalItems__additionalItems_are_allowed_by_default_5__only_the_first_item_is_validated()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyIsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__an_additional_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6ImJvb20ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhcmJheiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__patternProperties_are_not_additional_properties_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsInZyb29tIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__matching_the_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyLDoXJtw6FueW9zIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__not_matching_the_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyLDqWxtw6lueSI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_valid_property_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_invalid_property_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6MTJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_valid_property_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_invalid_property_is_invalid_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("additionalProperties")]
        public void Test_draft6__additionalProperties__additionalProperties_are_allowed_by_default_5__additional_properties_are_allowed()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf__allOf()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf__mismatch_second_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf__mismatch_first_3()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf__wrong_type_4()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_base_schema_2__valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyLCJiYXoiOm51bGx9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_base_schema_2__mismatch_base_schema_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmF6IjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_base_schema_2__mismatch_first_allOf_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjIsImJheiI6bnVsbH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_base_schema_2__mismatch_second_allOf_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_base_schema_2__mismatch_both_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_simple_types_3__valid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sibWF4aW11bSI6MzB9LHsibWluaW11bSI6MjB9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MjU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_simple_types_3__mismatch_one_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sibWF4aW11bSI6MzB9LHsibWluaW11bSI6MjB9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_boolean_schemas__all_true_4__any_value_is_valid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3RydWUsdHJ1ZV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_boolean_schemas__some_false_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("allOf")]
        public void Test_draft6__allOf__allOf_with_boolean_schemas__all_false_6__any_value_is_invalid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W2ZhbHNlLGZhbHNlXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf__first_anyOf_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf__second_anyOf_valid_2()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mi41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf__both_anyOf_valid_3()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf__neither_anyOf_valid_4()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_with_base_schema_2__mismatch_base_schema()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_with_base_schema_2__one_anyOf_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_with_base_schema_2__both_anyOf_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_with_boolean_schemas__all_true_3__any_value_is_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3RydWUsdHJ1ZV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_with_boolean_schemas__some_true_4__any_value_is_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_with_boolean_schemas__all_false_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W2ZhbHNlLGZhbHNlXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_complex_types_6__first_anyOf_valid__complex_()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_complex_types_6__second_anyOf_valid__complex__2()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_complex_types_6__both_anyOf_valid__complex__3()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("anyOf")]
        public void Test_draft6__anyOf__anyOf_complex_types_6__neither_anyOf_valid__complex__4()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___number_is_valid()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___string_is_valid_2()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___boolean_true_is_valid_3()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___boolean_false_is_valid_4()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ZmFsc2U=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___null_is_valid_5()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___object_is_valid_6()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___empty_object_is_valid_7()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___array_is_valid_8()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__true___empty_array_is_valid_9()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__number_is_invalid()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__string_is_invalid_2()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__boolean_true_is_invalid_3()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__boolean_false_is_invalid_4()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ZmFsc2U=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__null_is_invalid_5()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__object_is_invalid_6()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__empty_object_is_invalid_7()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__array_is_invalid_8()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("boolean_schema")]
        public void Test_draft6__boolean_schema__boolean_schema__false__2__empty_array_is_invalid_9()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_validation__same_value_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_validation__another_value_is_invalid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("NQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_validation__another_type_is_invalid_3()
        {
            var s = ParseSchema("eyJjb25zdCI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_object_2__same_object_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_object_2__same_object_with_different_property_order_is_valid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXoiOiJiYXgiLCJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_object_2__another_object_is_invalid_3()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_object_2__another_type_is_invalid_4()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_array_3__same_array_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6W3siZm9vIjoiYmFyIn1dfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn1d");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_array_3__another_array_item_is_invalid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6W3siZm9vIjoiYmFyIn1dfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_array_3__array_with_additional_items_is_invalid_3()
        {
            var s = ParseSchema("eyJjb25zdCI6W3siZm9vIjoiYmFyIn1dfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_null_4__null_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6bnVsbH0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("const")]
        public void Test_draft6__const__const_with_null_4__not_null_is_invalid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6bnVsbH0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_validation__array_with_item_matching_schema__5__is_valid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzMsNCw1XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_validation__array_with_item_matching_schema__6__is_valid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzMsNCw2XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_validation__array_with_two_items_matching_schema__5__6__is_valid_3()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzMsNCw1LDZd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_validation__array_without_items_matching_schema_is_invalid_4()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzIsMyw0XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_validation__empty_array_is_invalid_5()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_validation__not_array_is_valid_6()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_const_keyword_2__array_with_item_5_is_valid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJjb25zdCI6NX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzMsNCw1XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_const_keyword_2__array_with_two_items_5_is_valid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJjb25zdCI6NX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzMsNCw1LDVd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_const_keyword_2__array_without_item_5_is_invalid_3()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJjb25zdCI6NX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_boolean_schema_true_3__any_non_empty_array_is_valid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_boolean_schema_true_3__empty_array_is_invalid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_boolean_schema_false_4__any_non_empty_array_is_invalid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("contains")]
        public void Test_draft6__contains__contains_keyword_with_boolean_schema_false_4__empty_array_is_invalid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("default")]
        public void Test_draft6__default__invalid_type_for_default__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("default")]
        public void Test_draft6__default__invalid_type_for_default__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("default")]
        public void Test_draft6__default__invalid_string_value_for_default_2__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOiJnb29kIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("default")]
        public void Test_draft6__default__invalid_string_value_for_default_2__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("definitions")]
        public void Test_draft6__definitions__valid_definition__valid_definition_schema()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNi9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJkZWZpbml0aW9ucyI6eyJmb28iOnsidHlwZSI6ImludGVnZXIifX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("definitions")]
        public void Test_draft6__definitions__invalid_definition_2__invalid_definition_schema()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNi9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJkZWZpbml0aW9ucyI6eyJmb28iOnsidHlwZSI6MX19fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__nondependant_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__with_dependency_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__ignores_arrays_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJiYXIiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__ignores_strings_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies_with_empty_array_2__empty_object()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies_with_empty_array_2__object_with_one_property_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_3__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_3__nondependants_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_3__with_dependencies_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_3__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_3__missing_other_dependency_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_3__missing_both_dependencies_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJxdXV4IjoxfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_subschema_4__valid()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_subschema_4__no_dependency_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_subschema_4__wrong_type_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_subschema_4__wrong_type_other_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__multiple_dependencies_subschema_4__wrong_type_both_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoicXV1eCJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies_with_boolean_subschemas_5__object_with_property_having_schema_true_is_valid()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies_with_boolean_subschemas_5__object_with_property_having_schema_false_is_invalid_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies_with_boolean_subschemas_5__object_with_both_properties_is_invalid_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("dependencies")]
        public void Test_draft6__dependencies__dependencies_with_boolean_subschemas_5__empty_object_is_valid_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__simple_enum_validation__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__simple_enum_validation__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("NA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__heterogeneous_enum_validation_2__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__heterogeneous_enum_validation_2__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__heterogeneous_enum_validation_2__objects_are_deep_compared_3()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__enums_in_properties_3__both_properties_are_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28iLCJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__enums_in_properties_3__missing_optional_property_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__enums_in_properties_3__missing_required_property_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("enum")]
        public void Test_draft6__enum__enums_in_properties_3__missing_all_properties_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft6__exclusiveMaximum__exclusiveMaximum_validation__below_the_exclusiveMaximum_is_valid()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mi4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft6__exclusiveMaximum__exclusiveMaximum_validation__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft6__exclusiveMaximum__exclusiveMaximum_validation__above_the_exclusiveMaximum_is_invalid_3()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft6__exclusiveMaximum__exclusiveMaximum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft6__exclusiveMinimum__exclusiveMinimum_validation__above_the_exclusiveMinimum_is_valid()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft6__exclusiveMinimum__exclusiveMinimum_validation__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft6__exclusiveMinimum__exclusiveMinimum_validation__below_the_exclusiveMinimum_is_invalid_3()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft6__exclusiveMinimum__exclusiveMinimum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__a_schema_given_for_items__valid_items()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__a_schema_given_for_items__wrong_type_of_items_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsIngiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__a_schema_given_for_items__ignores_non_arrays_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__a_schema_given_for_items__JavaScript_pseudo_array_is_valid_4()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyIwIjoiaW52YWxpZCIsImxlbmd0aCI6MX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__an_array_of_schemas_for_items_2__correct_types()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__an_array_of_schemas_for_items_2__wrong_types_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJmb28iLDFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__an_array_of_schemas_for_items_2__incomplete_array_of_items_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__an_array_of_schemas_for_items_2__array_with_additional_items_4()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__an_array_of_schemas_for_items_2__empty_array_5()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__an_array_of_schemas_for_items_2__JavaScript_pseudo_array_is_valid_6()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyIwIjoiaW52YWxpZCIsIjEiOiJ2YWxpZCIsImxlbmd0aCI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schema__true__3__any_array_is_valid()
        {
            var s = ParseSchema("eyJpdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schema__true__3__empty_array_is_valid_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schema__false__4__any_non_empty_array_is_invalid()
        {
            var s = ParseSchema("eyJpdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schema__false__4__empty_array_is_valid_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schemas_5__array_with_one_item_is_valid()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schemas_5__array_with_two_items_is_invalid_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("items")]
        public void Test_draft6__items__items_with_boolean_schemas_5__empty_array_is_valid_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maximum")]
        public void Test_draft6__maximum__maximum_validation__below_the_maximum_is_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maximum")]
        public void Test_draft6__maximum__maximum_validation__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maximum")]
        public void Test_draft6__maximum__maximum_validation__above_the_maximum_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maximum")]
        public void Test_draft6__maximum__maximum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxItems")]
        public void Test_draft6__maxItems__maxItems_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxItems")]
        public void Test_draft6__maxItems__maxItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxItems")]
        public void Test_draft6__maxItems__maxItems_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxItems")]
        public void Test_draft6__maxItems__maxItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxLength")]
        public void Test_draft6__maxLength__maxLength_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxLength")]
        public void Test_draft6__maxLength__maxLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxLength")]
        public void Test_draft6__maxLength__maxLength_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxLength")]
        public void Test_draft6__maxLength__maxLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxLength")]
        public void Test_draft6__maxLength__maxLength_validation__two_supplementary_Unicode_code_points_is_long_enough_5()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IvCfkqnwn5KpIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxProperties")]
        public void Test_draft6__maxProperties__maxProperties_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxProperties")]
        public void Test_draft6__maxProperties__maxProperties_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxProperties")]
        public void Test_draft6__maxProperties__maxProperties_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwiYmF6IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxProperties")]
        public void Test_draft6__maxProperties__maxProperties_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxProperties")]
        public void Test_draft6__maxProperties__maxProperties_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("maxProperties")]
        public void Test_draft6__maxProperties__maxProperties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minimum")]
        public void Test_draft6__minimum__minimum_validation__above_the_minimum_is_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minimum")]
        public void Test_draft6__minimum__minimum_validation__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minimum")]
        public void Test_draft6__minimum__minimum_validation__below_the_minimum_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minimum")]
        public void Test_draft6__minimum__minimum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minItems")]
        public void Test_draft6__minItems__minItems_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minItems")]
        public void Test_draft6__minItems__minItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minItems")]
        public void Test_draft6__minItems__minItems_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minItems")]
        public void Test_draft6__minItems__minItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minLength")]
        public void Test_draft6__minLength__minLength_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minLength")]
        public void Test_draft6__minLength__minLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minLength")]
        public void Test_draft6__minLength__minLength_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minLength")]
        public void Test_draft6__minLength__minLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minLength")]
        public void Test_draft6__minLength__minLength_validation__one_supplementary_Unicode_code_point_is_not_long_enough_5()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IvCfkqki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minProperties")]
        public void Test_draft6__minProperties__minProperties_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minProperties")]
        public void Test_draft6__minProperties__minProperties_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minProperties")]
        public void Test_draft6__minProperties__minProperties_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minProperties")]
        public void Test_draft6__minProperties__minProperties_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minProperties")]
        public void Test_draft6__minProperties__minProperties_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("minProperties")]
        public void Test_draft6__minProperties__minProperties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_int__int_by_int()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_int__int_by_int_fail_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Nw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_int__ignores_non_numbers_3()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_number_2__zero_is_multiple_of_anything()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_number_2__4_5_is_multiple_of_1_5_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("NC41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_number_2__35_is_not_multiple_of_1_5_3()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_small_number_3__0_0075_is_multiple_of_0_0001()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjowLjAwMDF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MC4wMDc1");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("multipleOf")]
        public void Test_draft6__multipleOf__by_small_number_3__0_00751_is_not_multiple_of_0_0001_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjowLjAwMDF9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MC4wMDc1MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not__allowed()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6ImludGVnZXIifX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not__disallowed_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6ImludGVnZXIifX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_multiple_types_2__valid()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_multiple_types_2__mismatch_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_multiple_types_2__other_mismatch_3()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_more_complex_schema_3__match()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_more_complex_schema_3__other_match_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_more_complex_schema_3__mismatch_3()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__forbidden_property_4__property_present()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJub3QiOnt9fX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__forbidden_property_4__property_absent_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJub3QiOnt9fX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjEsImJheiI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_with_boolean_schema_true_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJub3QiOnRydWV9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("not")]
        public void Test_draft6__not__not_with_boolean_schema_false_6__any_value_is_valid()
        {
            var s = ParseSchema("eyJub3QiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf__first_oneOf_valid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf__second_oneOf_valid_2()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mi41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf__both_oneOf_valid_3()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf__neither_oneOf_valid_4()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_base_schema_2__mismatch_base_schema()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_base_schema_2__one_oneOf_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_base_schema_2__both_oneOf_valid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_boolean_schemas__all_true_3__any_value_is_invalid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3RydWUsdHJ1ZSx0cnVlXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_boolean_schemas__one_true_4__any_value_is_valid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3RydWUsZmFsc2UsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_boolean_schemas__more_than_one_true_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3RydWUsdHJ1ZSxmYWxzZV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_with_boolean_schemas__all_false_6__any_value_is_invalid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W2ZhbHNlLGZhbHNlLGZhbHNlXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_complex_types_7__first_oneOf_valid__complex_()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_complex_types_7__second_oneOf_valid__complex__2()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_complex_types_7__both_oneOf_valid__complex__3()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("oneOf")]
        public void Test_draft6__oneOf__oneOf_complex_types_7__neither_oneOf_valid__complex__4()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("pattern")]
        public void Test_draft6__pattern__pattern_validation__a_matching_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImFhYSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("pattern")]
        public void Test_draft6__pattern__pattern_validation__a_non_matching_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("pattern")]
        public void Test_draft6__pattern__pattern_validation__ignores_non_strings_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("pattern")]
        public void Test_draft6__pattern__pattern_is_not_anchored_2__matches_a_substring()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiYSsifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Inh4YWF5eSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_valid_matches_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImZvb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_invalid_match_is_invalid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_invalid_matches_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb29vIjoiYmF6In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_strings_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhIjoyMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_simultaneous_match_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhYWFhIjoxOH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__multiple_matches_is_valid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhIjoyMSwiYWFhYSI6MTh9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_one_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhIjoiYmFyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_the_other_is_invalid_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_both_is_invalid_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhYWEiOiJmb28iLCJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__non_recognized_members_are_ignored()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhbnN3ZXIgMSI6IjQyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__recognized_members_are_accounted_for_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhMzFiIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhX3hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive__2_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJhX1hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_with_boolean_schemas_4__object_with_property_matching_schema_true_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_with_boolean_schemas_4__object_with_property_matching_schema_false_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_with_boolean_schemas_4__object_with_both_properties_is_invalid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("patternProperties")]
        public void Test_draft6__patternProperties__patternProperties_with_boolean_schemas_4__empty_object_is_valid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__object_properties_validation__both_properties_present_and_valid_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6ImJheiJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__object_properties_validation__one_property_invalid_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6e319");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__object_properties_validation__both_properties_invalid_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOltdLCJiYXIiOnt9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__object_properties_validation__doesn_t_invalidate_other_properties_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJxdXV4IjpbXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__object_properties_validation__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__object_properties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__property_validates_property()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__property_invalidates_property_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsMyw0XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_property_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_validates_nonproperty_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmeG8iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_nonproperty_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmeG8iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_ignores_property_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_validates_others_7()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJxdXV4IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_invalidates_others_8()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJxdXV4IjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties_with_boolean_schema_3__no_property_present_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties_with_boolean_schema_3__only__true__property_present_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties_with_boolean_schema_3__only__false__property_present_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("properties")]
        public void Test_draft6__properties__properties_with_boolean_schema_3__both_properties_present_is_invalid_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_validation__all_property_names_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmIjp7fSwiZm9vIjp7fX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_validation__some_property_names_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOnt9LCJmb29iYXIiOnt9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_validation__object_without_properties_is_valid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_with_boolean_schema_true_2__object_with_any_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp0cnVlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_with_boolean_schema_true_2__empty_object_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp0cnVlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_with_boolean_schema_false_3__object_with_any_properties_is_invalid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("propertyNames")]
        public void Test_draft6__propertyNames__propertyNames_with_boolean_schema_false_3__empty_object_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__root_pointer_ref__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__root_pointer_ref__recursive_match_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOnsiZm9vIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__root_pointer_ref__mismatch_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__root_pointer_ref__recursive_mismatch_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOnsiYmFyIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__relative_pointer_ref_to_object_2__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__relative_pointer_ref_to_object_2__mismatch_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__relative_pointer_ref_to_array_3__match_array()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__relative_pointer_ref_to_array_3__mismatch_array_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__escaped_pointer_ref_4__slash_invalid()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJzbGFzaCI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__escaped_pointer_ref_4__tilda_invalid_2()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__escaped_pointer_ref_4__percent_invalid_3()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoiYW9ldSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__escaped_pointer_ref_4__slash_valid_4()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJzbGFzaCI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__escaped_pointer_ref_4__tilda_valid_5()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__escaped_pointer_ref_4__percent_valid_6()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoxMjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__nested_refs_5__nested_ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("NQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__nested_refs_5__nested_ref_invalid_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__ref_overrides_any_sibling_keywords_6__ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__ref_overrides_any_sibling_keywords_6__ref_valid__maxItems_ignored_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsM119");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__ref_overrides_any_sibling_keywords_6__ref_invalid_3()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOiJzdHJpbmcifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__remote_ref__containing_refs_itself_7__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNi9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJtaW5MZW5ndGgiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__remote_ref__containing_refs_itself_7__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNi9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJtaW5MZW5ndGgiOi0xfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__property_named__ref_that_is_not_a_reference_8__property_named__ref_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7IiRyZWYiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyIkcmVmIjoiYSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__property_named__ref_that_is_not_a_reference_8__property_named__ref_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7IiRyZWYiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyIkcmVmIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref___ref_to_boolean_schema_true_9__any_value_is_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9ib29sIiwiZGVmaW5pdGlvbnMiOnsiYm9vbCI6dHJ1ZX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref___ref_to_boolean_schema_false_10__any_value_is_invalid()
        {
            var s = ParseSchema("eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9ib29sIiwiZGVmaW5pdGlvbnMiOnsiYm9vbCI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__Recursive_references_between_schemas_11__valid_tree()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvdHJlZSIsImRlc2NyaXB0aW9uIjoidHJlZSBvZiBub2RlcyIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Im1ldGEiOnsidHlwZSI6InN0cmluZyJ9LCJub2RlcyI6eyJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoibm9kZSJ9fX0sInJlcXVpcmVkIjpbIm1ldGEiLCJub2RlcyJdLCJkZWZpbml0aW9ucyI6eyJub2RlIjp7IiRpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9ub2RlIiwiZGVzY3JpcHRpb24iOiJub2RlIiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsidmFsdWUiOnsidHlwZSI6Im51bWJlciJ9LCJzdWJ0cmVlIjp7IiRyZWYiOiJ0cmVlIn19LCJyZXF1aXJlZCI6WyJ2YWx1ZSJdfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJtZXRhIjoicm9vdCIsIm5vZGVzIjpbeyJ2YWx1ZSI6MSwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOjEuMX0seyJ2YWx1ZSI6MS4yfV19fSx7InZhbHVlIjoyLCJzdWJ0cmVlIjp7Im1ldGEiOiJjaGlsZCIsIm5vZGVzIjpbeyJ2YWx1ZSI6Mi4xfSx7InZhbHVlIjoyLjJ9XX19XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("ref")]
        public void Test_draft6__ref__Recursive_references_between_schemas_11__invalid_tree_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvdHJlZSIsImRlc2NyaXB0aW9uIjoidHJlZSBvZiBub2RlcyIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Im1ldGEiOnsidHlwZSI6InN0cmluZyJ9LCJub2RlcyI6eyJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoibm9kZSJ9fX0sInJlcXVpcmVkIjpbIm1ldGEiLCJub2RlcyJdLCJkZWZpbml0aW9ucyI6eyJub2RlIjp7IiRpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9ub2RlIiwiZGVzY3JpcHRpb24iOiJub2RlIiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsidmFsdWUiOnsidHlwZSI6Im51bWJlciJ9LCJzdWJ0cmVlIjp7IiRyZWYiOiJ0cmVlIn19LCJyZXF1aXJlZCI6WyJ2YWx1ZSJdfX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJtZXRhIjoicm9vdCIsIm5vZGVzIjpbeyJ2YWx1ZSI6MSwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOiJzdHJpbmcgaXMgaW52YWxpZCJ9LHsidmFsdWUiOjEuMn1dfX0seyJ2YWx1ZSI6Miwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOjIuMX0seyJ2YWx1ZSI6Mi4yfV19fV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__remote_ref__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__remote_ref__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__fragment_within_remote_ref_2__remote_fragment_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__fragment_within_remote_ref_2__remote_fragment_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__ref_within_remote_ref_3__ref_within_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__ref_within_remote_ref_3__ref_within_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__base_URI_change_4__base_URI_change_ref_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvIiwiaXRlbXMiOnsiJGlkIjoiZm9sZGVyLyIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W1sxXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__base_URI_change_4__base_URI_change_ref_invalid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvIiwiaXRlbXMiOnsiJGlkIjoiZm9sZGVyLyIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W1siYSJdXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__base_URI_change___change_folder_5__number_is_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMxLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2JheiJ9fSwiZGVmaW5pdGlvbnMiOnsiYmF6Ijp7IiRpZCI6ImZvbGRlci8iLCJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJsaXN0IjpbMV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__base_URI_change___change_folder_5__string_is_invalid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMxLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2JheiJ9fSwiZGVmaW5pdGlvbnMiOnsiYmF6Ijp7IiRpZCI6ImZvbGRlci8iLCJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJsaXN0IjpbImEiXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__base_URI_change___change_folder_in_subschema_6__number_is_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMyLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2Jhei9kZWZpbml0aW9ucy9iYXIifX0sImRlZmluaXRpb25zIjp7ImJheiI6eyIkaWQiOiJmb2xkZXIvIiwiZGVmaW5pdGlvbnMiOnsiYmFyIjp7InR5cGUiOiJhcnJheSIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19fX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJsaXN0IjpbMV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__base_URI_change___change_folder_in_subschema_6__string_is_invalid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMyLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2Jhei9kZWZpbml0aW9ucy9iYXIifX0sImRlZmluaXRpb25zIjp7ImJheiI6eyIkaWQiOiJmb2xkZXIvIiwiZGVmaW5pdGlvbnMiOnsiYmFyIjp7InR5cGUiOiJhcnJheSIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19fX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJsaXN0IjpbImEiXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__root_ref_in_remote_ref_7__string_is_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvb2JqZWN0IiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibmFtZSI6eyIkcmVmIjoibmFtZS5qc29uIy9kZWZpbml0aW9ucy9vck51bGwifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJuYW1lIjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__root_ref_in_remote_ref_7__null_is_valid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvb2JqZWN0IiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibmFtZSI6eyIkcmVmIjoibmFtZS5qc29uIy9kZWZpbml0aW9ucy9vck51bGwifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJuYW1lIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("refRemote")]
        public void Test_draft6__refRemote__root_ref_in_remote_ref_7__object_is_invalid_3()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvb2JqZWN0IiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibmFtZSI6eyIkcmVmIjoibmFtZS5qc29uIy9kZWZpbml0aW9ucy9vck51bGwifX19", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJuYW1lIjp7Im5hbWUiOm51bGx9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_validation__present_required_property_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_validation__non_present_required_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("eyJiYXIiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_validation__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_validation__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_validation__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_default_validation_2__not_required_by_default()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e319fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("required")]
        public void Test_draft6__required__required_with_empty_array_3__property_not_required()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e319LCJyZXF1aXJlZCI6W119", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__an_integer_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__a_float_is_not_an_integer_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__a_string_is_not_an_integer_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__a_string_is_still_not_an_integer__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__an_object_is_not_an_integer_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__an_array_is_not_an_integer_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__a_boolean_is_not_an_integer_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__integer_type_matches_integers__null_is_not_an_integer_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__an_integer_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__a_float_is_a_number_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__a_string_is_not_a_number_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__a_string_is_still_not_a_number__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__an_object_is_not_a_number_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__an_array_is_not_a_number_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__a_boolean_is_not_a_number_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__number_type_matches_numbers_2__null_is_not_a_number_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__1_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__a_float_is_not_a_string_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__a_string_is_a_string_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__a_string_is_still_a_string__even_if_it_looks_like_a_number_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__an_object_is_not_a_string_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__an_array_is_not_a_string_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__a_boolean_is_not_a_string_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__string_type_matches_strings_3__null_is_not_a_string_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__an_integer_is_not_an_object()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__a_float_is_not_an_object_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__a_string_is_not_an_object_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__an_object_is_an_object_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__an_array_is_not_an_object_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__a_boolean_is_not_an_object_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__object_type_matches_objects_4__null_is_not_an_object_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__an_integer_is_not_an_array()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__a_float_is_not_an_array_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__a_string_is_not_an_array_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__an_object_is_not_an_array_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__an_array_is_an_array_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__a_boolean_is_not_an_array_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__array_type_matches_arrays_5__null_is_not_an_array_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__an_integer_is_not_a_boolean()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__a_float_is_not_a_boolean_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__a_string_is_not_a_boolean_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__an_object_is_not_a_boolean_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__an_array_is_not_a_boolean_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__a_boolean_is_a_boolean_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__boolean_type_matches_booleans_6__null_is_not_a_boolean_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__an_integer_is_not_null()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__a_float_is_not_null_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__a_string_is_not_null_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__an_object_is_not_null_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__an_array_is_not_null_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__a_boolean_is_not_null_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__null_type_matches_only_the_null_object_7__null_is_null_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__an_integer_is_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__a_string_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__a_float_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__an_object_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__an_array_is_invalid_5()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__a_boolean_is_invalid_6()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("type")]
        public void Test_draft6__type__multiple_types_can_be_specified_in_an_array_8__null_is_invalid_7()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__unique_array_of_integers_is_valid()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__non_unique_array_of_integers_is_invalid_2()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__numbers_are_unique_if_mathematically_unequal_3()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEuMCwxLjAsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__unique_array_of_objects_is_valid_4()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXoifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__non_unique_array_of_objects_is_invalid_5()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXIifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__unique_array_of_nested_objects_is_valid_6()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6ZmFsc2V9fX1d");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__non_unique_array_of_nested_objects_is_invalid_7()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6dHJ1ZX19fV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__unique_array_of_arrays_is_valid_8()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJiYXIiXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__non_unique_array_of_arrays_is_invalid_9()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJmb28iXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__1_and_true_are_unique_10()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzEsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__0_and_false_are_unique_11()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("WzAsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__unique_heterogeneous_types_are_valid_12()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6")]
        [TestCategory("uniqueItems")]
        public void Test_draft6__uniqueItems__uniqueItems_validation__non_unique_heterogeneous_types_are_invalid_13()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwse30sMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__integer__a_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTIzNDU2Nzg5MTAxMTEyMTMxNDE1MTYxNzE4MTkyMDIxMjIyMzI0MjUyNjI3MjgyOTMwMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__number_2__a_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__integer_3__a_negative_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("LTEyMzQ1Njc4OTEwMTExMjEzMTQxNTE2MTcxODE5MjAyMTIyMjMyNDI1MjYyNzI4MjkzMDMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__number_4__a_negative_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("LTk4MjQ5MjgzNzQ5MjM0OTIzNDk4MjkzMTcxODIzOTQ4NzI5MzQ4NzEwMjk4MzAxOTI4MzMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__string_5__a_bignum_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__integer_comparison_6__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjoxODQ0Njc0NDA3MzcwOTU1MTYxNX0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MTg0NDY3NDQwNzM3MDk1NTE2MDA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__float_comparison_with_high_precision_7__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjo5LjcyNzgzNzk4MTg3OTg3MTJFKzI2fQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("OS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__integer_comparison_8__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjotMTg0NDY3NDQwNzM3MDk1NTE2MTV9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("LTE4NDQ2NzQ0MDczNzA5NTUxNjAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("bignum")]
        public void Test_draft6_optional__bignum__float_comparison_with_high_precision_on_negative_numbers_9__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjotOS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("LTkuNzI3ODM3OTgxODc5ODcxMkUrMjY=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("ecmascript-regex")]
        public void Test_draft6_optional__ecmascript_regex__ECMA_262_regex_non_compliance__ECMA_262_has_no_support_for__Z_anchor_from__NET()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Il5cXFMofCgufFxcbikqXFxTKVxcWiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__a_valid_date_time_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDYuMjgzMTg1WiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__a_valid_date_time_string_without_second_fraction_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDZaIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__a_valid_date_time_string_with_plus_offset_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5MzctMDEtMDFUMDU6NDA6MjcuODctMDY6MDAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__a_valid_date_time_string_with_minus_offset_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5OTAtMTItMzFUMTc6NTk6NTAuMTIzLTA2OjAwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__a_invalid_day_in_date_time_string_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5OTAtMDItMzFUMTU6NTk6NjAuMTIzLTA4OjAwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__an_invalid_offset_in_date_time_string_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5OTAtMTItMzFUMTU6NTk6NjAtMjQ6MDAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__an_invalid_closing_Z_after_time_zone_offset_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDYuMjgxMjMrMDE6MDBaIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__an_invalid_date_time_string_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjA2LzE5LzE5NjMgMDg6MzA6MDYgUFNUIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__case_insensitive_T_and_Z_9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTl0MDg6MzA6MDYuMjgzMTg1eiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_date_time_strings__only_RFC3339_not_all_of_ISO_8601_are_valid_10()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjIwMTMtMzUwVDAxOjAxOjAxIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_with_anchor_tag()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9iYXo9cXV4I3F1dXgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_with_anchor_tag_and_parantheses_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uY29tL2JsYWhfKHdpa2lwZWRpYSlfYmxhaCNjaXRlLTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_with_URL_encoded_stuff_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9xPVRlc3QlMjBVUkwtZW5jb2RlZCUyMHN0dWZmIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_puny_coded_URL__4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly94bi0tbncyYS54bi0tajZ3MTkzZy8i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_with_many_special_characters_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly8tLn5fISQmJygpKissOz06JTQwOjgwJTJmOjo6Ojo6QGV4YW1wbGUuY29tIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_based_on_IPv4_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly8yMjMuMjU1LjI1NS4yNTQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_with_ftp_scheme_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImZ0cDovL2Z0cC5pcy5jby56YS9yZmMvcmZjMTgwOC50eHQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL_for_a_simple_text_file_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly93d3cuaWV0Zi5vcmcvcmZjL3JmYzIzOTYudHh0Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URL__9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImxkYXA6Ly9bMjAwMTpkYjg6OjddL2M9R0I/b2JqZWN0Q2xhc3M/b25lIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_mailto_URI_10()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Im1haWx0bzpKb2huLkRvZUBleGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_newsgroup_URI_11()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Im5ld3M6Y29tcC5pbmZvc3lzdGVtcy53d3cuc2VydmVycy51bml4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_tel_URI_12()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("InRlbDorMS04MTYtNTU1LTEyMTIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__a_valid_URN_13()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOmRvY2Jvb2s6ZHRkOnhtbDo0LjEuMiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__an_invalid_protocol_relative_URI_Reference_14()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii8vZm9vLmJhci8/YmF6PXF1eCNxdXV4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__an_invalid_relative_URI_Reference_15()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9hYmMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__an_invalid_URI_16()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWxlc2hhcmUi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__an_invalid_URI_though_valid_URI_reference_17()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__an_invalid_URI_with_spaces_18()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly8gc2hvdWxkZmFpbC5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URIs_2__an_invalid_URI_with_spaces_and_missing_scheme_19()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjovLyBzaG91bGQgZmFpbCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__a_valid_URI()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9iYXo9cXV4I3F1dXgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__a_valid_protocol_relative_URI_Reference_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii8vZm9vLmJhci8/YmF6PXF1eCNxdXV4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__a_valid_relative_URI_Reference_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9hYmMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__an_invalid_URI_Reference_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWxlc2hhcmUi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__a_valid_URI_Reference_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__a_valid_URI_fragment_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiNmcmFnbWVudCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_URI_References_3__an_invalid_URI_fragment_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiNmcmFnXFxtZW50Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__format__uri_template_4__a_valid_uri_template()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9leGFtcGxlLmNvbS9kaWN0aW9uYXJ5L3t0ZXJtOjF9L3t0ZXJtfSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__format__uri_template_4__an_invalid_uri_template_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9leGFtcGxlLmNvbS9kaWN0aW9uYXJ5L3t0ZXJtOjF9L3t0ZXJtIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__format__uri_template_4__a_valid_uri_template_without_variables_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Imh0dHA6Ly9leGFtcGxlLmNvbS9kaWN0aW9uYXJ5Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__format__uri_template_4__a_valid_relative_uri_template_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImRpY3Rpb25hcnkve3Rlcm06MX0ve3Rlcm19Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_e_mail_addresses_5__a_valid_e_mail_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImpvZS5ibG9nZ3NAZXhhbXBsZS5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_e_mail_addresses_5__an_invalid_e_mail_address_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjI5NjIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IP_addresses_6__a_valid_IP_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE5Mi4xNjguMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IP_addresses_6__an_IP_address_with_too_many_components_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjEyNy4wLjAuMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IP_addresses_6__an_IP_address_with_out_of_range_values_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjI1Ni4yNTYuMjU2LjI1NiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IP_addresses_6__an_IP_address_without_4_components_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjEyNy4wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IP_addresses_6__an_IP_address_as_an_integer_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjB4N2YwMDAwMDEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IPv6_addresses_7__a_valid_IPv6_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ijo6MSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IPv6_addresses_7__an_IPv6_address_with_out_of_range_values_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjEyMzQ1Ojoi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IPv6_addresses_7__an_IPv6_address_with_too_many_components_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjE6MToxOjE6MToxOjE6MToxOjE6MToxOjE6MToxOjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_IPv6_addresses_7__an_IPv6_address_containing_illegal_characters_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ijo6bGFwdG9wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_host_names_8__a_valid_host_name()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ind3dy5leGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_host_names_8__a_host_name_starting_with_an_illegal_character_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii1hLWhvc3QtbmFtZS10aGF0LXN0YXJ0cy13aXRoLS0i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_host_names_8__a_host_name_containing_illegal_characters_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Im5vdF9hX3ZhbGlkX2hvc3RfbmFtZSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_host_names_8__a_host_name_with_a_component_too_long_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEtdnZ2dnZ2dnZ2dnZ2dnZ2dmVlZWVlZWVlZWVlZWVlZWVycnJycnJycnJycnJycnJyeXl5eXl5eXl5eXl5eXl5eS1sb25nLWhvc3QtbmFtZS1jb21wb25lbnQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__a_valid_JSON_pointer()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vYmFyfjAvYmF6fjEvJWEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer____not_escaped__2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vYmFyfiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_with_empty_segment_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vL2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_with_the_last_empty_segment_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vYmFyLyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__1_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__2_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__3_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vMCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__4_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii8i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__5_9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9hfjFiIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__6_10()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9jJWQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__7_11()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9lXmYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__8_12()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9nfGgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__9_13()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9pXFxqIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__10_14()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9rXCJsIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__11_15()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii8gIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_as_stated_in_RFC_6901__12_16()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9tfjBuIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer_used_adding_to_the_last_array_position_17()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vLSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer____used_as_object_member_name__18()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9mb28vLS9iYXIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer__multiple_escaped_characters__19()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+MX4wfjB+MX4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer__escaped_with_fraction_part___1_20()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+MS4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__valid_JSON_pointer__escaped_with_fraction_part___2_21()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+MC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__URI_Fragment_Identifier___1_22()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__URI_Fragment_Identifier___2_23()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiMvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__URI_Fragment_Identifier___3_24()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IiNhIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__some_escaped__but_not_all___1_25()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+MH4i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__some_escaped__but_not_all___2_26()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+MC9+Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__wrong_escape_character___1_27()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+MiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__wrong_escape_character___2_28()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+LTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__multiple_characters_not_escaped__29()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("Ii9+fiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__isn_t_empty_nor_starts_with_____1_30()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__isn_t_empty_nor_starts_with_____2_31()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("IjAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("format")]
        public void Test_draft6_optional__format__validation_of_JSON_pointers__JSON_String_Representation__9__not_a_valid_JSON_pointer__isn_t_empty_nor_starts_with_____3_32()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("ImEvYSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft6_optional")]
        [TestCategory("zeroTerminatedFloats")]
        public void Test_draft6_optional__zeroTerminatedFloats__some_languages_do_not_distinguish_between_different_types_of_numeric_value__a_float_without_fractional_part_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-06/schema#"));
            var t = ParseElement("MS4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__additionalItems_as_schema__additional_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9XSwiYWRkaXRpb25hbEl0ZW1zIjp7InR5cGUiOiJpbnRlZ2VyIn19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W251bGwsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__additionalItems_as_schema__additional_items_do_not_match_schema_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9XSwiYWRkaXRpb25hbEl0ZW1zIjp7InR5cGUiOiJpbnRlZ2VyIn19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W251bGwsMiwzLCJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__items_is_schema__no_additionalItems_2__all_items_match_schema()
        {
            var s = ParseSchema("eyJpdGVtcyI6e30sImFkZGl0aW9uYWxJdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__array_of_items_with_no_additionalItems_3__fewer_number_of_items_present()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__array_of_items_with_no_additionalItems_3__equal_number_of_items_present_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__array_of_items_with_no_additionalItems_3__additional_items_are_not_permitted_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3t9LHt9LHt9XSwiYWRkaXRpb25hbEl0ZW1zIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__additionalItems_as_false_without_items_4__items_defaults_to_empty_schema_so_everything_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzLDQsNV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__additionalItems_as_false_without_items_4__ignores_non_arrays_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsSXRlbXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalItems")]
        public void Test_draft7__additionalItems__additionalItems_are_allowed_by_default_5__only_the_first_item_is_validated()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyIsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__an_additional_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6ImJvb20ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhcmJheiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_being_false_does_not_allow_other_properties__patternProperties_are_not_additional_properties_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJwYXR0ZXJuUHJvcGVydGllcyI6eyJediI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsInZyb29tIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__matching_the_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyLDoXJtw6FueW9zIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__non_ASCII_pattern_with_additionalProperties_2__not_matching_the_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJew6EiOnt9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyLDqWxtw6lueSI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__no_additional_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_valid_property_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_allows_a_schema_which_should_validate_3__an_additional_invalid_property_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6MTJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_valid_property_is_valid()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_can_exist_by_itself_4__an_additional_invalid_property_is_invalid_2()
        {
            var s = ParseSchema("eyJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiYm9vbGVhbiJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("additionalProperties")]
        public void Test_draft7__additionalProperties__additionalProperties_are_allowed_by_default_5__additional_properties_are_allowed()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6dHJ1ZX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf__allOf()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf__mismatch_second_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf__mismatch_first_3()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf__wrong_type_4()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_base_schema_2__valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyLCJiYXoiOm51bGx9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_base_schema_2__mismatch_base_schema_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmF6IjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_base_schema_2__mismatch_first_allOf_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjIsImJheiI6bnVsbH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_base_schema_2__mismatch_second_allOf_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_base_schema_2__mismatch_both_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fSwicmVxdWlyZWQiOlsiYmFyIl0sImFsbE9mIjpbeyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoic3RyaW5nIn19LCJyZXF1aXJlZCI6WyJmb28iXX0seyJwcm9wZXJ0aWVzIjp7ImJheiI6eyJ0eXBlIjoibnVsbCJ9fSwicmVxdWlyZWQiOlsiYmF6Il19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_simple_types_3__valid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sibWF4aW11bSI6MzB9LHsibWluaW11bSI6MjB9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MjU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_simple_types_3__mismatch_one_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3sibWF4aW11bSI6MzB9LHsibWluaW11bSI6MjB9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_boolean_schemas__all_true_4__any_value_is_valid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3RydWUsdHJ1ZV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_boolean_schemas__some_false_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("allOf")]
        public void Test_draft7__allOf__allOf_with_boolean_schemas__all_false_6__any_value_is_invalid()
        {
            var s = ParseSchema("eyJhbGxPZiI6W2ZhbHNlLGZhbHNlXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf__first_anyOf_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf__second_anyOf_valid_2()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mi41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf__both_anyOf_valid_3()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf__neither_anyOf_valid_4()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_with_base_schema_2__mismatch_base_schema()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_with_base_schema_2__one_anyOf_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_with_base_schema_2__both_anyOf_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwiYW55T2YiOlt7Im1heExlbmd0aCI6Mn0seyJtaW5MZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_with_boolean_schemas__all_true_3__any_value_is_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3RydWUsdHJ1ZV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_with_boolean_schemas__some_true_4__any_value_is_valid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_with_boolean_schemas__all_false_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJhbnlPZiI6W2ZhbHNlLGZhbHNlXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_complex_types_6__first_anyOf_valid__complex_()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_complex_types_6__second_anyOf_valid__complex__2()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_complex_types_6__both_anyOf_valid__complex__3()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("anyOf")]
        public void Test_draft7__anyOf__anyOf_complex_types_6__neither_anyOf_valid__complex__4()
        {
            var s = ParseSchema("eyJhbnlPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___number_is_valid()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___string_is_valid_2()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___boolean_true_is_valid_3()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___boolean_false_is_valid_4()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ZmFsc2U=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___null_is_valid_5()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___object_is_valid_6()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___empty_object_is_valid_7()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___array_is_valid_8()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__true___empty_array_is_valid_9()
        {
            var s = ParseSchema("dHJ1ZQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__number_is_invalid()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__string_is_invalid_2()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__boolean_true_is_invalid_3()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__boolean_false_is_invalid_4()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ZmFsc2U=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__null_is_invalid_5()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__object_is_invalid_6()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__empty_object_is_invalid_7()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__array_is_invalid_8()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("boolean_schema")]
        public void Test_draft7__boolean_schema__boolean_schema__false__2__empty_array_is_invalid_9()
        {
            var s = ParseSchema("ZmFsc2U=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_validation__same_value_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_validation__another_value_is_invalid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("NQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_validation__another_type_is_invalid_3()
        {
            var s = ParseSchema("eyJjb25zdCI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_object_2__same_object_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_object_2__same_object_with_different_property_order_is_valid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXoiOiJiYXgiLCJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_object_2__another_object_is_invalid_3()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_object_2__another_type_is_invalid_4()
        {
            var s = ParseSchema("eyJjb25zdCI6eyJmb28iOiJiYXIiLCJiYXoiOiJiYXgifX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_array_3__same_array_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6W3siZm9vIjoiYmFyIn1dfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn1d");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_array_3__another_array_item_is_invalid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6W3siZm9vIjoiYmFyIn1dfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_array_3__array_with_additional_items_is_invalid_3()
        {
            var s = ParseSchema("eyJjb25zdCI6W3siZm9vIjoiYmFyIn1dfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_null_4__null_is_valid()
        {
            var s = ParseSchema("eyJjb25zdCI6bnVsbH0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("const")]
        public void Test_draft7__const__const_with_null_4__not_null_is_invalid_2()
        {
            var s = ParseSchema("eyJjb25zdCI6bnVsbH0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_validation__array_with_item_matching_schema__5__is_valid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzMsNCw1XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_validation__array_with_item_matching_schema__6__is_valid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzMsNCw2XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_validation__array_with_two_items_matching_schema__5__6__is_valid_3()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzMsNCw1LDZd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_validation__array_without_items_matching_schema_is_invalid_4()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzIsMyw0XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_validation__empty_array_is_invalid_5()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_validation__not_array_is_valid_6()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJtaW5pbXVtIjo1fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_const_keyword_2__array_with_item_5_is_valid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJjb25zdCI6NX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzMsNCw1XQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_const_keyword_2__array_with_two_items_5_is_valid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJjb25zdCI6NX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzMsNCw1LDVd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_const_keyword_2__array_without_item_5_is_invalid_3()
        {
            var s = ParseSchema("eyJjb250YWlucyI6eyJjb25zdCI6NX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_boolean_schema_true_3__any_non_empty_array_is_valid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_boolean_schema_true_3__empty_array_is_invalid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_boolean_schema_false_4__any_non_empty_array_is_invalid()
        {
            var s = ParseSchema("eyJjb250YWlucyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("contains")]
        public void Test_draft7__contains__contains_keyword_with_boolean_schema_false_4__empty_array_is_invalid_2()
        {
            var s = ParseSchema("eyJjb250YWlucyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("default")]
        public void Test_draft7__default__invalid_type_for_default__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("default")]
        public void Test_draft7__default__invalid_type_for_default__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciIsImRlZmF1bHQiOltdfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("default")]
        public void Test_draft7__default__invalid_string_value_for_default_2__valid_when_property_is_specified()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOiJnb29kIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("default")]
        public void Test_draft7__default__invalid_string_value_for_default_2__still_valid_when_the_invalid_default_is_used_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImJhciI6eyJ0eXBlIjoic3RyaW5nIiwibWluTGVuZ3RoIjo0LCJkZWZhdWx0IjoiYmFkIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("definitions")]
        public void Test_draft7__definitions__valid_definition__valid_definition_schema()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNy9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJkZWZpbml0aW9ucyI6eyJmb28iOnsidHlwZSI6ImludGVnZXIifX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("definitions")]
        public void Test_draft7__definitions__invalid_definition_2__invalid_definition_schema()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNy9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJkZWZpbml0aW9ucyI6eyJmb28iOnsidHlwZSI6MX19fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__nondependant_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__with_dependency_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__ignores_arrays_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJiYXIiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__ignores_strings_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbImZvbyJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies_with_empty_array_2__empty_object()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies_with_empty_array_2__object_with_one_property_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjpbXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_3__neither()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_3__nondependants_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_3__with_dependencies_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwicXV1eCI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_3__missing_dependency_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_3__missing_other_dependency_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjEsInF1dXgiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_3__missing_both_dependencies_6()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsicXV1eCI6WyJmb28iLCJiYXIiXX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJxdXV4IjoxfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_subschema_4__valid()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_subschema_4__no_dependency_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_subschema_4__wrong_type_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_subschema_4__wrong_type_other_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__multiple_dependencies_subschema_4__wrong_type_both_5()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiYmFyIjp7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJpbnRlZ2VyIn0sImJhciI6eyJ0eXBlIjoiaW50ZWdlciJ9fX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJxdXV4IiwiYmFyIjoicXV1eCJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies_with_boolean_subschemas_5__object_with_property_having_schema_true_is_valid()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies_with_boolean_subschemas_5__object_with_property_having_schema_false_is_invalid_2()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies_with_boolean_subschemas_5__object_with_both_properties_is_invalid_3()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("dependencies")]
        public void Test_draft7__dependencies__dependencies_with_boolean_subschemas_5__empty_object_is_valid_4()
        {
            var s = ParseSchema("eyJkZXBlbmRlbmNpZXMiOnsiZm9vIjp0cnVlLCJiYXIiOmZhbHNlfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__simple_enum_validation__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__simple_enum_validation__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbMSwyLDNdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("NA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__heterogeneous_enum_validation_2__one_of_the_enum_is_valid()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__heterogeneous_enum_validation_2__something_else_is_invalid_2()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__heterogeneous_enum_validation_2__objects_are_deep_compared_3()
        {
            var s = ParseSchema("eyJlbnVtIjpbNiwiZm9vIixbXSx0cnVlLHsiZm9vIjoxMn1dfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__enums_in_properties_3__both_properties_are_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28iLCJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__enums_in_properties_3__missing_optional_property_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__enums_in_properties_3__missing_required_property_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJmb28ifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("enum")]
        public void Test_draft7__enum__enums_in_properties_3__missing_all_properties_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJmb28iOnsiZW51bSI6WyJmb28iXX0sImJhciI6eyJlbnVtIjpbImJhciJdfX0sInJlcXVpcmVkIjpbImJhciJdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft7__exclusiveMaximum__exclusiveMaximum_validation__below_the_exclusiveMaximum_is_valid()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mi4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft7__exclusiveMaximum__exclusiveMaximum_validation__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft7__exclusiveMaximum__exclusiveMaximum_validation__above_the_exclusiveMaximum_is_invalid_3()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMaximum")]
        public void Test_draft7__exclusiveMaximum__exclusiveMaximum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft7__exclusiveMinimum__exclusiveMinimum_validation__above_the_exclusiveMinimum_is_valid()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4y");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft7__exclusiveMinimum__exclusiveMinimum_validation__boundary_point_is_invalid_2()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft7__exclusiveMinimum__exclusiveMinimum_validation__below_the_exclusiveMinimum_is_invalid_3()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("exclusiveMinimum")]
        public void Test_draft7__exclusiveMinimum__exclusiveMinimum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__ignore_if_without_then_or_else__valid_when_valid_against_lone_if()
        {
            var s = ParseSchema("eyJpZiI6eyJjb25zdCI6MH19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__ignore_if_without_then_or_else__valid_when_invalid_against_lone_if_2()
        {
            var s = ParseSchema("eyJpZiI6eyJjb25zdCI6MH19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImhlbGxvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__ignore_then_without_if_2__valid_when_valid_against_lone_then()
        {
            var s = ParseSchema("eyJ0aGVuIjp7ImNvbnN0IjowfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__ignore_then_without_if_2__valid_when_invalid_against_lone_then_2()
        {
            var s = ParseSchema("eyJ0aGVuIjp7ImNvbnN0IjowfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImhlbGxvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__ignore_else_without_if_3__valid_when_valid_against_lone_else()
        {
            var s = ParseSchema("eyJlbHNlIjp7ImNvbnN0IjowfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__ignore_else_without_if_3__valid_when_invalid_against_lone_else_2()
        {
            var s = ParseSchema("eyJlbHNlIjp7ImNvbnN0IjowfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImhlbGxvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__if_and_then_without_else_4__valid_through_then()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__if_and_then_without_else_4__invalid_through_then_2()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTEwMA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__if_and_then_without_else_4__valid_when_if_test_fails_3()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__if_and_else_without_then_5__valid_when_if_test_passes()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwiZWxzZSI6eyJtdWx0aXBsZU9mIjoyfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__if_and_else_without_then_5__valid_through_else_2()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwiZWxzZSI6eyJtdWx0aXBsZU9mIjoyfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("NA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__if_and_else_without_then_5__invalid_through_else_3()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwiZWxzZSI6eyJtdWx0aXBsZU9mIjoyfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__validate_against_correct_branch__then_vs_else_6__valid_through_then()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9LCJlbHNlIjp7Im11bHRpcGxlT2YiOjJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__validate_against_correct_branch__then_vs_else_6__invalid_through_then_2()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9LCJlbHNlIjp7Im11bHRpcGxlT2YiOjJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTEwMA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__validate_against_correct_branch__then_vs_else_6__valid_through_else_3()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9LCJlbHNlIjp7Im11bHRpcGxlT2YiOjJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("NA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__validate_against_correct_branch__then_vs_else_6__invalid_through_else_4()
        {
            var s = ParseSchema("eyJpZiI6eyJleGNsdXNpdmVNYXhpbXVtIjowfSwidGhlbiI6eyJtaW5pbXVtIjotMTB9LCJlbHNlIjp7Im11bHRpcGxlT2YiOjJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__non_interference_across_combined_schemas_7__valid__but_woud_have_been_invalid_through_then()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3siaWYiOnsiZXhjbHVzaXZlTWF4aW11bSI6MH19LHsidGhlbiI6eyJtaW5pbXVtIjotMTB9fSx7ImVsc2UiOnsibXVsdGlwbGVPZiI6Mn19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTEwMA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("if-then-else")]
        public void Test_draft7__if_then_else__non_interference_across_combined_schemas_7__valid__but_would_have_been_invalid_through_else_2()
        {
            var s = ParseSchema("eyJhbGxPZiI6W3siaWYiOnsiZXhjbHVzaXZlTWF4aW11bSI6MH19LHsidGhlbiI6eyJtaW5pbXVtIjotMTB9fSx7ImVsc2UiOnsibXVsdGlwbGVPZiI6Mn19XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__a_schema_given_for_items__valid_items()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__a_schema_given_for_items__wrong_type_of_items_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsIngiXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__a_schema_given_for_items__ignores_non_arrays_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__a_schema_given_for_items__JavaScript_pseudo_array_is_valid_4()
        {
            var s = ParseSchema("eyJpdGVtcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyIwIjoiaW52YWxpZCIsImxlbmd0aCI6MX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__an_array_of_schemas_for_items_2__correct_types()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__an_array_of_schemas_for_items_2__wrong_types_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJmb28iLDFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__an_array_of_schemas_for_items_2__incomplete_array_of_items_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__an_array_of_schemas_for_items_2__array_with_additional_items_4()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__an_array_of_schemas_for_items_2__empty_array_5()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__an_array_of_schemas_for_items_2__JavaScript_pseudo_array_is_valid_6()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7InR5cGUiOiJzdHJpbmcifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyIwIjoiaW52YWxpZCIsIjEiOiJ2YWxpZCIsImxlbmd0aCI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schema__true__3__any_array_is_valid()
        {
            var s = ParseSchema("eyJpdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schema__true__3__empty_array_is_valid_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schema__false__4__any_non_empty_array_is_invalid()
        {
            var s = ParseSchema("eyJpdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyIsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schema__false__4__empty_array_is_valid_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6ZmFsc2V9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schemas_5__array_with_one_item_is_valid()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schemas_5__array_with_two_items_is_invalid_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("items")]
        public void Test_draft7__items__items_with_boolean_schemas_5__empty_array_is_valid_3()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3RydWUsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maximum")]
        public void Test_draft7__maximum__maximum_validation__below_the_maximum_is_valid()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maximum")]
        public void Test_draft7__maximum__maximum_validation__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("My4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maximum")]
        public void Test_draft7__maximum__maximum_validation__above_the_maximum_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("My41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maximum")]
        public void Test_draft7__maximum__maximum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjozLjB9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxItems")]
        public void Test_draft7__maxItems__maxItems_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxItems")]
        public void Test_draft7__maxItems__maxItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxItems")]
        public void Test_draft7__maxItems__maxItems_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxItems")]
        public void Test_draft7__maxItems__maxItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtYXhJdGVtcyI6Mn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxLength")]
        public void Test_draft7__maxLength__maxLength_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxLength")]
        public void Test_draft7__maxLength__maxLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxLength")]
        public void Test_draft7__maxLength__maxLength_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxLength")]
        public void Test_draft7__maxLength__maxLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxLength")]
        public void Test_draft7__maxLength__maxLength_validation__two_supplementary_Unicode_code_points_is_long_enough_5()
        {
            var s = ParseSchema("eyJtYXhMZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IvCfkqnwn5KpIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxProperties")]
        public void Test_draft7__maxProperties__maxProperties_validation__shorter_is_valid()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxProperties")]
        public void Test_draft7__maxProperties__maxProperties_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxProperties")]
        public void Test_draft7__maxProperties__maxProperties_validation__too_long_is_invalid_3()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6MiwiYmF6IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxProperties")]
        public void Test_draft7__maxProperties__maxProperties_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxProperties")]
        public void Test_draft7__maxProperties__maxProperties_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("maxProperties")]
        public void Test_draft7__maxProperties__maxProperties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJtYXhQcm9wZXJ0aWVzIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minimum")]
        public void Test_draft7__minimum__minimum_validation__above_the_minimum_is_valid()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mi42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minimum")]
        public void Test_draft7__minimum__minimum_validation__boundary_point_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minimum")]
        public void Test_draft7__minimum__minimum_validation__below_the_minimum_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MC42");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minimum")]
        public void Test_draft7__minimum__minimum_validation__ignores_non_numbers_4()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjoxLjF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ingi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minItems")]
        public void Test_draft7__minItems__minItems_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minItems")]
        public void Test_draft7__minItems__minItems_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzFd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minItems")]
        public void Test_draft7__minItems__minItems_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minItems")]
        public void Test_draft7__minItems__minItems_validation__ignores_non_arrays_4()
        {
            var s = ParseSchema("eyJtaW5JdGVtcyI6MX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minLength")]
        public void Test_draft7__minLength__minLength_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minLength")]
        public void Test_draft7__minLength__minLength_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minLength")]
        public void Test_draft7__minLength__minLength_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minLength")]
        public void Test_draft7__minLength__minLength_validation__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minLength")]
        public void Test_draft7__minLength__minLength_validation__one_supplementary_Unicode_code_point_is_not_long_enough_5()
        {
            var s = ParseSchema("eyJtaW5MZW5ndGgiOjJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IvCfkqki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minProperties")]
        public void Test_draft7__minProperties__minProperties_validation__longer_is_valid()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minProperties")]
        public void Test_draft7__minProperties__minProperties_validation__exact_length_is_valid_2()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minProperties")]
        public void Test_draft7__minProperties__minProperties_validation__too_short_is_invalid_3()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minProperties")]
        public void Test_draft7__minProperties__minProperties_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minProperties")]
        public void Test_draft7__minProperties__minProperties_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("minProperties")]
        public void Test_draft7__minProperties__minProperties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJtaW5Qcm9wZXJ0aWVzIjoxfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_int__int_by_int()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_int__int_by_int_fail_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Nw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_int__ignores_non_numbers_3()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoyfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_number_2__zero_is_multiple_of_anything()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_number_2__4_5_is_multiple_of_1_5_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("NC41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_number_2__35_is_not_multiple_of_1_5_3()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjoxLjV9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MzU=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_small_number_3__0_0075_is_multiple_of_0_0001()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjowLjAwMDF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MC4wMDc1");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("multipleOf")]
        public void Test_draft7__multipleOf__by_small_number_3__0_00751_is_not_multiple_of_0_0001_2()
        {
            var s = ParseSchema("eyJtdWx0aXBsZU9mIjowLjAwMDF9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MC4wMDc1MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not__allowed()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6ImludGVnZXIifX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not__disallowed_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6ImludGVnZXIifX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_multiple_types_2__valid()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_multiple_types_2__mismatch_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_multiple_types_2__other_mismatch_3()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6WyJpbnRlZ2VyIiwiYm9vbGVhbiJdfX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_more_complex_schema_3__match()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_more_complex_schema_3__other_match_2()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_more_complex_schema_3__mismatch_3()
        {
            var s = ParseSchema("eyJub3QiOnsidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__forbidden_property_4__property_present()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJub3QiOnt9fX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__forbidden_property_4__property_absent_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJub3QiOnt9fX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjEsImJheiI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_with_boolean_schema_true_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJub3QiOnRydWV9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("not")]
        public void Test_draft7__not__not_with_boolean_schema_false_6__any_value_is_valid()
        {
            var s = ParseSchema("eyJub3QiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf__first_oneOf_valid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf__second_oneOf_valid_2()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mi41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf__both_oneOf_valid_3()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf__neither_oneOf_valid_4()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sidHlwZSI6ImludGVnZXIifSx7Im1pbmltdW0iOjJ9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS41");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_base_schema_2__mismatch_base_schema()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Mw==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_base_schema_2__one_oneOf_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_base_schema_2__both_oneOf_valid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIiwib25lT2YiOlt7Im1pbkxlbmd0aCI6Mn0seyJtYXhMZW5ndGgiOjR9XX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_boolean_schemas__all_true_3__any_value_is_invalid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3RydWUsdHJ1ZSx0cnVlXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_boolean_schemas__one_true_4__any_value_is_valid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3RydWUsZmFsc2UsZmFsc2VdfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_boolean_schemas__more_than_one_true_5__any_value_is_invalid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3RydWUsdHJ1ZSxmYWxzZV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_with_boolean_schemas__all_false_6__any_value_is_invalid()
        {
            var s = ParseSchema("eyJvbmVPZiI6W2ZhbHNlLGZhbHNlLGZhbHNlXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_complex_types_7__first_oneOf_valid__complex_()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_complex_types_7__second_oneOf_valid__complex__2()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_complex_types_7__both_oneOf_valid__complex__3()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXoiLCJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("oneOf")]
        public void Test_draft7__oneOf__oneOf_complex_types_7__neither_oneOf_valid__complex__4()
        {
            var s = ParseSchema("eyJvbmVPZiI6W3sicHJvcGVydGllcyI6eyJiYXIiOnsidHlwZSI6ImludGVnZXIifX0sInJlcXVpcmVkIjpbImJhciJdfSx7InByb3BlcnRpZXMiOnsiZm9vIjp7InR5cGUiOiJzdHJpbmcifX0sInJlcXVpcmVkIjpbImZvbyJdfV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjIsImJhciI6InF1dXgifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("pattern")]
        public void Test_draft7__pattern__pattern_validation__a_matching_pattern_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImFhYSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("pattern")]
        public void Test_draft7__pattern__pattern_validation__a_non_matching_pattern_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("pattern")]
        public void Test_draft7__pattern__pattern_validation__ignores_non_strings_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiXmEqJCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("pattern")]
        public void Test_draft7__pattern__pattern_is_not_anchored_2__matches_a_substring()
        {
            var s = ParseSchema("eyJwYXR0ZXJuIjoiYSsifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Inh4YWF5eSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_valid_matches_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImZvb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__a_single_invalid_match_is_invalid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb28iOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__multiple_invalid_matches_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJiYXIiLCJmb29vb29vIjoiYmF6In0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WyJmb28iXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_strings_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_validates_properties_matching_a_regex__ignores_other_non_objects_7()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLipvIjp7InR5cGUiOiJpbnRlZ2VyIn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_single_valid_match_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhIjoyMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__a_simultaneous_match_is_valid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhYWFhIjoxOH0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__multiple_matches_is_valid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhIjoyMSwiYWFhYSI6MTh9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_one_is_invalid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhIjoiYmFyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_the_other_is_invalid_5()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__multiple_simultaneous_patternProperties_are_validated_2__an_invalid_due_to_both_is_invalid_6()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJhKiI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJhYWEqIjp7Im1heGltdW0iOjIwfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhYWEiOiJmb28iLCJhYWFhIjozMX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__non_recognized_members_are_ignored()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhbnN3ZXIgMSI6IjQyIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__recognized_members_are_accounted_for_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhMzFiIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhX3hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__regexes_are_not_anchored_by_default_and_are_case_sensitive_3__regexes_are_case_sensitive__2_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJbMC05XXsyLH0iOnsidHlwZSI6ImJvb2xlYW4ifSwiWF8iOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJhX1hfMyI6M30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_with_boolean_schemas_4__object_with_property_matching_schema_true_is_valid()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_with_boolean_schemas_4__object_with_property_matching_schema_false_is_invalid_2()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_with_boolean_schemas_4__object_with_both_properties_is_invalid_3()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("patternProperties")]
        public void Test_draft7__patternProperties__patternProperties_with_boolean_schemas_4__empty_object_is_valid_4()
        {
            var s = ParseSchema("eyJwYXR0ZXJuUHJvcGVydGllcyI6eyJmLioiOnRydWUsImIuKiI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__object_properties_validation__both_properties_present_and_valid_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6ImJheiJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__object_properties_validation__one_property_invalid_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6e319");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__object_properties_validation__both_properties_invalid_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOltdLCJiYXIiOnt9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__object_properties_validation__doesn_t_invalidate_other_properties_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJxdXV4IjpbXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__object_properties_validation__ignores_arrays_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__object_properties_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__property_validates_property()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__property_invalidates_property_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsMyw0XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_property_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_validates_nonproperty_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmeG8iOlsxLDJdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__patternProperty_invalidates_nonproperty_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmeG8iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_ignores_property_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_validates_others_7()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJxdXV4IjozfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties__patternProperties__additionalProperties_interaction_2__additionalProperty_invalidates_others_8()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiYXJyYXkiLCJtYXhJdGVtcyI6M30sImJhciI6eyJ0eXBlIjoiYXJyYXkifX0sInBhdHRlcm5Qcm9wZXJ0aWVzIjp7ImYubyI6eyJtaW5JdGVtcyI6Mn19LCJhZGRpdGlvbmFsUHJvcGVydGllcyI6eyJ0eXBlIjoiaW50ZWdlciJ9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJxdXV4IjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties_with_boolean_schema_3__no_property_present_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties_with_boolean_schema_3__only__true__property_present_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties_with_boolean_schema_3__only__false__property_present_is_invalid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("properties")]
        public void Test_draft7__properties__properties_with_boolean_schema_3__both_properties_present_is_invalid_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6dHJ1ZSwiYmFyIjpmYWxzZX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjEsImJhciI6Mn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_validation__all_property_names_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmIjp7fSwiZm9vIjp7fX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_validation__some_property_names_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOnt9LCJmb29iYXIiOnt9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_validation__object_without_properties_is_valid_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_validation__ignores_arrays_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMiwzLDRd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_validation__ignores_strings_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvb2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_validation__ignores_other_non_objects_6()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp7Im1heExlbmd0aCI6M319", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_with_boolean_schema_true_2__object_with_any_properties_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp0cnVlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_with_boolean_schema_true_2__empty_object_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjp0cnVlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_with_boolean_schema_false_3__object_with_any_properties_is_invalid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("propertyNames")]
        public void Test_draft7__propertyNames__propertyNames_with_boolean_schema_false_3__empty_object_is_valid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0eU5hbWVzIjpmYWxzZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__root_pointer_ref__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__root_pointer_ref__recursive_match_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOnsiZm9vIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__root_pointer_ref__mismatch_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOmZhbHNlfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__root_pointer_ref__recursive_mismatch_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIyJ9fSwiYWRkaXRpb25hbFByb3BlcnRpZXMiOmZhbHNlfQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOnsiYmFyIjpmYWxzZX19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__relative_pointer_ref_to_object_2__match()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__relative_pointer_ref_to_object_2__mismatch_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJiYXIiOnsiJHJlZiI6IiMvcHJvcGVydGllcy9mb28ifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOnRydWV9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__relative_pointer_ref_to_array_3__match_array()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__relative_pointer_ref_to_array_3__mismatch_array_2()
        {
            var s = ParseSchema("eyJpdGVtcyI6W3sidHlwZSI6ImludGVnZXIifSx7IiRyZWYiOiIjL2l0ZW1zLzAifV19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsImZvbyJd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__escaped_pointer_ref_4__slash_invalid()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJzbGFzaCI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__escaped_pointer_ref_4__tilda_invalid_2()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6ImFvZXUifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__escaped_pointer_ref_4__percent_invalid_3()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoiYW9ldSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__escaped_pointer_ref_4__slash_valid_4()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJzbGFzaCI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__escaped_pointer_ref_4__tilda_valid_5()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJ0aWxkYSI6MTIzfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__escaped_pointer_ref_4__percent_valid_6()
        {
            var s = ParseSchema("eyJ0aWxkYX5maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJzbGFzaC9maWVsZCI6eyJ0eXBlIjoiaW50ZWdlciJ9LCJwZXJjZW50JWZpZWxkIjp7InR5cGUiOiJpbnRlZ2VyIn0sInByb3BlcnRpZXMiOnsidGlsZGEiOnsiJHJlZiI6IiMvdGlsZGF+MGZpZWxkIn0sInNsYXNoIjp7IiRyZWYiOiIjL3NsYXNofjFmaWVsZCJ9LCJwZXJjZW50Ijp7IiRyZWYiOiIjL3BlcmNlbnQlMjVmaWVsZCJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJwZXJjZW50IjoxMjN9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__nested_refs_5__nested_ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("NQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__nested_refs_5__nested_ref_invalid_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJhIjp7InR5cGUiOiJpbnRlZ2VyIn0sImIiOnsiJHJlZiI6IiMvZGVmaW5pdGlvbnMvYSJ9LCJjIjp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2IifX0sIiRyZWYiOiIjL2RlZmluaXRpb25zL2MifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__ref_overrides_any_sibling_keywords_6__ref_valid()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOltdfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__ref_overrides_any_sibling_keywords_6__ref_valid__maxItems_ignored_2()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOlsxLDIsM119");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__ref_overrides_any_sibling_keywords_6__ref_invalid_3()
        {
            var s = ParseSchema("eyJkZWZpbml0aW9ucyI6eyJyZWZmZWQiOnsidHlwZSI6ImFycmF5In19LCJwcm9wZXJ0aWVzIjp7ImZvbyI6eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9yZWZmZWQiLCJtYXhJdGVtcyI6Mn19fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOiJzdHJpbmcifQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__remote_ref__containing_refs_itself_7__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNy9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJtaW5MZW5ndGgiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__remote_ref__containing_refs_itself_7__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2pzb24tc2NoZW1hLm9yZy9kcmFmdC0wNy9zY2hlbWEjIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJtaW5MZW5ndGgiOi0xfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__property_named__ref_that_is_not_a_reference_8__property_named__ref_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7IiRyZWYiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyIkcmVmIjoiYSJ9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__property_named__ref_that_is_not_a_reference_8__property_named__ref_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7IiRyZWYiOnsidHlwZSI6InN0cmluZyJ9fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyIkcmVmIjoyfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref___ref_to_boolean_schema_true_9__any_value_is_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9ib29sIiwiZGVmaW5pdGlvbnMiOnsiYm9vbCI6dHJ1ZX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref___ref_to_boolean_schema_false_10__any_value_is_invalid()
        {
            var s = ParseSchema("eyIkcmVmIjoiIy9kZWZpbml0aW9ucy9ib29sIiwiZGVmaW5pdGlvbnMiOnsiYm9vbCI6ZmFsc2V9fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__Recursive_references_between_schemas_11__valid_tree()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvdHJlZSIsImRlc2NyaXB0aW9uIjoidHJlZSBvZiBub2RlcyIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Im1ldGEiOnsidHlwZSI6InN0cmluZyJ9LCJub2RlcyI6eyJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoibm9kZSJ9fX0sInJlcXVpcmVkIjpbIm1ldGEiLCJub2RlcyJdLCJkZWZpbml0aW9ucyI6eyJub2RlIjp7IiRpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9ub2RlIiwiZGVzY3JpcHRpb24iOiJub2RlIiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsidmFsdWUiOnsidHlwZSI6Im51bWJlciJ9LCJzdWJ0cmVlIjp7IiRyZWYiOiJ0cmVlIn19LCJyZXF1aXJlZCI6WyJ2YWx1ZSJdfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJtZXRhIjoicm9vdCIsIm5vZGVzIjpbeyJ2YWx1ZSI6MSwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOjEuMX0seyJ2YWx1ZSI6MS4yfV19fSx7InZhbHVlIjoyLCJzdWJ0cmVlIjp7Im1ldGEiOiJjaGlsZCIsIm5vZGVzIjpbeyJ2YWx1ZSI6Mi4xfSx7InZhbHVlIjoyLjJ9XX19XX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("ref")]
        public void Test_draft7__ref__Recursive_references_between_schemas_11__invalid_tree_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvdHJlZSIsImRlc2NyaXB0aW9uIjoidHJlZSBvZiBub2RlcyIsInR5cGUiOiJvYmplY3QiLCJwcm9wZXJ0aWVzIjp7Im1ldGEiOnsidHlwZSI6InN0cmluZyJ9LCJub2RlcyI6eyJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoibm9kZSJ9fX0sInJlcXVpcmVkIjpbIm1ldGEiLCJub2RlcyJdLCJkZWZpbml0aW9ucyI6eyJub2RlIjp7IiRpZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTIzNC9ub2RlIiwiZGVzY3JpcHRpb24iOiJub2RlIiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsidmFsdWUiOnsidHlwZSI6Im51bWJlciJ9LCJzdWJ0cmVlIjp7IiRyZWYiOiJ0cmVlIn19LCJyZXF1aXJlZCI6WyJ2YWx1ZSJdfX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJtZXRhIjoicm9vdCIsIm5vZGVzIjpbeyJ2YWx1ZSI6MSwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOiJzdHJpbmcgaXMgaW52YWxpZCJ9LHsidmFsdWUiOjEuMn1dfX0seyJ2YWx1ZSI6Miwic3VidHJlZSI6eyJtZXRhIjoiY2hpbGQiLCJub2RlcyI6W3sidmFsdWUiOjIuMX0seyJ2YWx1ZSI6Mi4yfV19fV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__remote_ref__remote_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__remote_ref__remote_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L2ludGVnZXIuanNvbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__fragment_within_remote_ref_2__remote_fragment_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__fragment_within_remote_ref_2__remote_fragment_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__ref_within_remote_ref_3__ref_within_ref_valid()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__ref_within_remote_ref_3__ref_within_ref_invalid_2()
        {
            var s = ParseSchema("eyIkcmVmIjoiaHR0cDovL2xvY2FsaG9zdDoxMjM0L3N1YlNjaGVtYXMuanNvbiMvcmVmVG9JbnRlZ2VyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__base_URI_change_4__base_URI_change_ref_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvIiwiaXRlbXMiOnsiJGlkIjoiZm9sZGVyLyIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W1sxXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__base_URI_change_4__base_URI_change_ref_invalid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvIiwiaXRlbXMiOnsiJGlkIjoiZm9sZGVyLyIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W1siYSJdXQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__base_URI_change___change_folder_5__number_is_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMxLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2JheiJ9fSwiZGVmaW5pdGlvbnMiOnsiYmF6Ijp7IiRpZCI6ImZvbGRlci8iLCJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJsaXN0IjpbMV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__base_URI_change___change_folder_5__string_is_invalid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMxLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2JheiJ9fSwiZGVmaW5pdGlvbnMiOnsiYmF6Ijp7IiRpZCI6ImZvbGRlci8iLCJ0eXBlIjoiYXJyYXkiLCJpdGVtcyI6eyIkcmVmIjoiZm9sZGVySW50ZWdlci5qc29uIn19fX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJsaXN0IjpbImEiXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__base_URI_change___change_folder_in_subschema_6__number_is_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMyLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2Jhei9kZWZpbml0aW9ucy9iYXIifX0sImRlZmluaXRpb25zIjp7ImJheiI6eyIkaWQiOiJmb2xkZXIvIiwiZGVmaW5pdGlvbnMiOnsiYmFyIjp7InR5cGUiOiJhcnJheSIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19fX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJsaXN0IjpbMV19");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__base_URI_change___change_folder_in_subschema_6__string_is_invalid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvc2NvcGVfY2hhbmdlX2RlZnMyLmpzb24iLCJ0eXBlIjoib2JqZWN0IiwicHJvcGVydGllcyI6eyJsaXN0Ijp7IiRyZWYiOiIjL2RlZmluaXRpb25zL2Jhei9kZWZpbml0aW9ucy9iYXIifX0sImRlZmluaXRpb25zIjp7ImJheiI6eyIkaWQiOiJmb2xkZXIvIiwiZGVmaW5pdGlvbnMiOnsiYmFyIjp7InR5cGUiOiJhcnJheSIsIml0ZW1zIjp7IiRyZWYiOiJmb2xkZXJJbnRlZ2VyLmpzb24ifX19fX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJsaXN0IjpbImEiXX0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__root_ref_in_remote_ref_7__string_is_valid()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvb2JqZWN0IiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibmFtZSI6eyIkcmVmIjoibmFtZS5qc29uIy9kZWZpbml0aW9ucy9vck51bGwifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJuYW1lIjoiZm9vIn0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__root_ref_in_remote_ref_7__null_is_valid_2()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvb2JqZWN0IiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibmFtZSI6eyIkcmVmIjoibmFtZS5qc29uIy9kZWZpbml0aW9ucy9vck51bGwifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJuYW1lIjpudWxsfQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("refRemote")]
        public void Test_draft7__refRemote__root_ref_in_remote_ref_7__object_is_invalid_3()
        {
            var s = ParseSchema("eyIkaWQiOiJodHRwOi8vbG9jYWxob3N0OjEyMzQvb2JqZWN0IiwidHlwZSI6Im9iamVjdCIsInByb3BlcnRpZXMiOnsibmFtZSI6eyIkcmVmIjoibmFtZS5qc29uIy9kZWZpbml0aW9ucy9vck51bGwifX19", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJuYW1lIjp7Im5hbWUiOm51bGx9fQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_validation__present_required_property_is_valid()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJmb28iOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_validation__non_present_required_property_is_invalid_2()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("eyJiYXIiOjF9");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_validation__ignores_arrays_3()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_validation__ignores_strings_4()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_validation__ignores_other_non_objects_5()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e30sImJhciI6e319LCJyZXF1aXJlZCI6WyJmb28iXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_default_validation_2__not_required_by_default()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e319fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("required")]
        public void Test_draft7__required__required_with_empty_array_3__property_not_required()
        {
            var s = ParseSchema("eyJwcm9wZXJ0aWVzIjp7ImZvbyI6e319LCJyZXF1aXJlZCI6W119", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__an_integer_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__a_float_is_not_an_integer_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__a_string_is_not_an_integer_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__a_string_is_still_not_an_integer__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__an_object_is_not_an_integer_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__an_array_is_not_an_integer_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__a_boolean_is_not_an_integer_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__integer_type_matches_integers__null_is_not_an_integer_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__an_integer_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__a_float_is_a_number_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__a_string_is_not_a_number_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__a_string_is_still_not_a_number__even_if_it_looks_like_one_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__an_object_is_not_a_number_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__an_array_is_not_a_number_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__a_boolean_is_not_a_number_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__number_type_matches_numbers_2__null_is_not_a_number_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__1_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__a_float_is_not_a_string_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__a_string_is_a_string_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__a_string_is_still_a_string__even_if_it_looks_like_a_number_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__an_object_is_not_a_string_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__an_array_is_not_a_string_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__a_boolean_is_not_a_string_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__string_type_matches_strings_3__null_is_not_a_string_8()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__an_integer_is_not_an_object()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__a_float_is_not_an_object_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__a_string_is_not_an_object_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__an_object_is_an_object_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__an_array_is_not_an_object_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__a_boolean_is_not_an_object_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__object_type_matches_objects_4__null_is_not_an_object_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoib2JqZWN0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__an_integer_is_not_an_array()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__a_float_is_not_an_array_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__a_string_is_not_an_array_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__an_object_is_not_an_array_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__an_array_is_an_array_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__a_boolean_is_not_an_array_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__array_type_matches_arrays_5__null_is_not_an_array_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYXJyYXkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__an_integer_is_not_a_boolean()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__a_float_is_not_a_boolean_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__a_string_is_not_a_boolean_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__an_object_is_not_a_boolean_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__an_array_is_not_a_boolean_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__a_boolean_is_a_boolean_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__boolean_type_matches_booleans_6__null_is_not_a_boolean_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoiYm9vbGVhbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__an_integer_is_not_null()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__a_float_is_not_null_2()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__a_string_is_not_null_3()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__an_object_is_not_null_4()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__an_array_is_not_null_5()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__a_boolean_is_not_null_6()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__null_type_matches_only_the_null_object_7__null_is_null_7()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVsbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__an_integer_is_valid()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__a_string_is_valid_2()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZvbyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__a_float_is_invalid_3()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4x");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__an_object_is_invalid_4()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("e30=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__an_array_is_invalid_5()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W10=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__a_boolean_is_invalid_6()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("dHJ1ZQ==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("type")]
        public void Test_draft7__type__multiple_types_can_be_specified_in_an_array_8__null_is_invalid_7()
        {
            var s = ParseSchema("eyJ0eXBlIjpbImludGVnZXIiLCJzdHJpbmciXX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("bnVsbA==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__unique_array_of_integers_is_valid()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMl0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__non_unique_array_of_integers_is_invalid_2()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__numbers_are_unique_if_mathematically_unequal_3()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEuMCwxLjAsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__unique_array_of_objects_is_valid_4()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXoifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__non_unique_array_of_objects_is_invalid_5()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3siZm9vIjoiYmFyIn0seyJmb28iOiJiYXIifV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__unique_array_of_nested_objects_is_valid_6()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6ZmFsc2V9fX1d");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__non_unique_array_of_nested_objects_is_invalid_7()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3siZm9vIjp7ImJhciI6eyJiYXoiOnRydWV9fX0seyJmb28iOnsiYmFyIjp7ImJheiI6dHJ1ZX19fV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__unique_array_of_arrays_is_valid_8()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJiYXIiXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__non_unique_array_of_arrays_is_invalid_9()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W1siZm9vIl0sWyJmb28iXV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__1_and_true_are_unique_10()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzEsdHJ1ZV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__0_and_false_are_unique_11()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("WzAsZmFsc2Vd");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__unique_heterogeneous_types_are_valid_12()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwsMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7")]
        [TestCategory("uniqueItems")]
        public void Test_draft7__uniqueItems__uniqueItems_validation__non_unique_heterogeneous_types_are_invalid_13()
        {
            var s = ParseSchema("eyJ1bmlxdWVJdGVtcyI6dHJ1ZX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("W3t9LFsxXSx0cnVlLG51bGwse30sMV0=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__integer__a_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTIzNDU2Nzg5MTAxMTEyMTMxNDE1MTYxNzE4MTkyMDIxMjIyMzI0MjUyNjI3MjgyOTMwMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__number_2__a_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__integer_3__a_negative_bignum_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTEyMzQ1Njc4OTEwMTExMjEzMTQxNTE2MTcxODE5MjAyMTIyMjMyNDI1MjYyNzI4MjkzMDMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__number_4__a_negative_bignum_is_a_number()
        {
            var s = ParseSchema("eyJ0eXBlIjoibnVtYmVyIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTk4MjQ5MjgzNzQ5MjM0OTIzNDk4MjkzMTcxODIzOTQ4NzI5MzQ4NzEwMjk4MzAxOTI4MzMx");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__string_5__a_bignum_is_not_a_string()
        {
            var s = ParseSchema("eyJ0eXBlIjoic3RyaW5nIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("OTgyNDkyODM3NDkyMzQ5MjM0OTgyOTMxNzE4MjM5NDg3MjkzNDg3MTAyOTgzMDE5MjgzMzE=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__integer_comparison_6__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJtYXhpbXVtIjoxODQ0Njc0NDA3MzcwOTU1MTYxNX0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTg0NDY3NDQwNzM3MDk1NTE2MDA=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__float_comparison_with_high_precision_7__comparison_works_for_high_numbers()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNYXhpbXVtIjo5LjcyNzgzNzk4MTg3OTg3MTJFKzI2fQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("OS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__integer_comparison_8__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJtaW5pbXVtIjotMTg0NDY3NDQwNzM3MDk1NTE2MTV9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTE4NDQ2NzQ0MDczNzA5NTUxNjAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("bignum")]
        public void Test_draft7_optional__bignum__float_comparison_with_high_precision_on_negative_numbers_9__comparison_works_for_very_negative_numbers()
        {
            var s = ParseSchema("eyJleGNsdXNpdmVNaW5pbXVtIjotOS43Mjc4Mzc5ODE4Nzk4NzEyRSsyNn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("LTkuNzI3ODM3OTgxODc5ODcxMkUrMjY=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_string_encoded_content_based_on_media_type__a_valid_JSON_document()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IntcImZvb1wiOiBcImJhclwifSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_string_encoded_content_based_on_media_type__an_invalid_JSON_document_2()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ins6fSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_string_encoded_content_based_on_media_type__ignores_non_strings_3()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_string_encoding_2__a_valid_base64_string()
        {
            var s = ParseSchema("eyJjb250ZW50RW5jb2RpbmciOiJiYXNlNjQifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImV5Sm1iMjhpT2lBaVltRnlJbjBLIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_string_encoding_2__an_invalid_base64_string____is_not_a_valid_character__2()
        {
            var s = ParseSchema("eyJjb250ZW50RW5jb2RpbmciOiJiYXNlNjQifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImV5Sm1iMjhpT2klaVltRnlJbjBLIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_string_encoding_2__ignores_non_strings_3()
        {
            var s = ParseSchema("eyJjb250ZW50RW5jb2RpbmciOiJiYXNlNjQifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_encoded_media_type_documents_3__a_valid_base64_encoded_JSON_document()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiIsImNvbnRlbnRFbmNvZGluZyI6ImJhc2U2NCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImV5Sm1iMjhpT2lBaVltRnlJbjBLIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_encoded_media_type_documents_3__a_validly_encoded_invalid_JSON_document_2()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiIsImNvbnRlbnRFbmNvZGluZyI6ImJhc2U2NCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImV6cDlDZz09Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_encoded_media_type_documents_3__an_invalid_base64_string_that_is_valid_JSON_3()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiIsImNvbnRlbnRFbmNvZGluZyI6ImJhc2U2NCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Int9Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("content")]
        public void Test_draft7_optional__content__validation_of_binary_encoded_media_type_documents_3__ignores_non_strings_4()
        {
            var s = ParseSchema("eyJjb250ZW50TWVkaWFUeXBlIjoiYXBwbGljYXRpb24vanNvbiIsImNvbnRlbnRFbmNvZGluZyI6ImJhc2U2NCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MTAw");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("ecmascript-regex")]
        public void Test_draft7_optional__ecmascript_regex__ECMA_262_regex_non_compliance__ECMA_262_has_no_support_for__Z_anchor_from__NET()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Il5cXFMofCgufFxcbikqXFxTKVxcWiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional")]
        [TestCategory("zeroTerminatedFloats")]
        public void Test_draft7_optional__zeroTerminatedFloats__some_languages_do_not_distinguish_between_different_types_of_numeric_value__a_float_without_fractional_part_is_an_integer()
        {
            var s = ParseSchema("eyJ0eXBlIjoiaW50ZWdlciJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("MS4w");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__a_valid_date_time_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDYuMjgzMTg1WiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__a_valid_date_time_string_without_second_fraction_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTlUMDg6MzA6MDZaIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__a_valid_date_time_string_with_plus_offset_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5MzctMDEtMDFUMDU6NDA6MjcuODctMDY6MDAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__a_valid_date_time_string_with_minus_offset_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5OTAtMTItMzFUMTc6NTk6NTAuMTIzLTA2OjAwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__a_invalid_day_in_date_time_string_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5OTAtMDItMzFUMTU6NTk6NjAuMTIzLTA4OjAwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__an_invalid_offset_in_date_time_string_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5OTAtMTItMzFUMTU6NTk6NjAtMjQ6MDAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__an_invalid_date_time_string_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjA2LzE5LzE5NjMgMDg6MzA6MDYgUFNUIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__case_insensitive_T_and_Z_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTl0MDg6MzA6MDYuMjgzMTg1eiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date-time")]
        public void Test_draft7_optional_format__date_time__validation_of_date_time_strings__only_RFC3339_not_all_of_ISO_8601_are_valid_9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlLXRpbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjIwMTMtMzUwVDAxOjAxOjAxIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date")]
        public void Test_draft7_optional_format__date__validation_of_date_strings__a_valid_date_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5NjMtMDYtMTki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date")]
        public void Test_draft7_optional_format__date__validation_of_date_strings__an_invalid_date_time_string_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjA2LzE5LzE5NjMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("date")]
        public void Test_draft7_optional_format__date__validation_of_date_strings__only_RFC3339_not_all_of_ISO_8601_are_valid_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJkYXRlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjIwMTMtMzUwIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("email")]
        public void Test_draft7_optional_format__email__validation_of_e_mail_addresses__a_valid_e_mail_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImpvZS5ibG9nZ3NAZXhhbXBsZS5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("email")]
        public void Test_draft7_optional_format__email__validation_of_e_mail_addresses__an_invalid_e_mail_address_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJlbWFpbCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjI5NjIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("hostname")]
        public void Test_draft7_optional_format__hostname__validation_of_host_names__a_valid_host_name()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ind3dy5leGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("hostname")]
        public void Test_draft7_optional_format__hostname__validation_of_host_names__a_valid_punycoded_IDN_hostname_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("InhuLS00Z2J3ZGwueG4tLXdnYmgxYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("hostname")]
        public void Test_draft7_optional_format__hostname__validation_of_host_names__a_host_name_starting_with_an_illegal_character_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii1hLWhvc3QtbmFtZS10aGF0LXN0YXJ0cy13aXRoLS0i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("hostname")]
        public void Test_draft7_optional_format__hostname__validation_of_host_names__a_host_name_containing_illegal_characters_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Im5vdF9hX3ZhbGlkX2hvc3RfbmFtZSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("hostname")]
        public void Test_draft7_optional_format__hostname__validation_of_host_names__a_host_name_with_a_component_too_long_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJob3N0bmFtZSJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEtdnZ2dnZ2dnZ2dnZ2dnZ2dmVlZWVlZWVlZWVlZWVlZWVycnJycnJycnJycnJycnJyeXl5eXl5eXl5eXl5eXl5eS1sb25nLWhvc3QtbmFtZS1jb21wb25lbnQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("idn-email")]
        public void Test_draft7_optional_format__idn_email__validation_of_an_internationalized_e_mail_addresses__a_valid_idn_e_mail__example_example_test_in_Hangul_()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpZG4tZW1haWwifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IuyLpOuhgEDsi6TroYAu7YWM7Iqk7Yq4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("idn-email")]
        public void Test_draft7_optional_format__idn_email__validation_of_an_internationalized_e_mail_addresses__an_invalid_idn_e_mail_address_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpZG4tZW1haWwifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjI5NjIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("idn-hostname")]
        public void Test_draft7_optional_format__idn_hostname__validation_of_internationalized_host_names__a_valid_host_name__example_test_in_Hangul_()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpZG4taG9zdG5hbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IuyLpOuhgC7thYzsiqTtirgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("idn-hostname")]
        public void Test_draft7_optional_format__idn_hostname__validation_of_internationalized_host_names__illegal_first_char_U_302E_Hangul_single_dot_tone_mark_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpZG4taG9zdG5hbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IuOAruyLpOuhgC7thYzsiqTtirgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("idn-hostname")]
        public void Test_draft7_optional_format__idn_hostname__validation_of_internationalized_host_names__contains_illegal_char_U_302E_Hangul_single_dot_tone_mark_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpZG4taG9zdG5hbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IuyLpOOAruuhgC7thYzsiqTtirgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("idn-hostname")]
        public void Test_draft7_optional_format__idn_hostname__validation_of_internationalized_host_names__a_host_name_with_a_component_too_long_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpZG4taG9zdG5hbWUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IuyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOyLpOuhgOuhgO2FjOyKpO2KuOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgO2FjOyKpO2KuOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgO2FjOyKpO2KuOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgOuhgO2FjOyKpO2KuOuhgOuhgOyLpOuhgC7thYzsiqTtirgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv4")]
        public void Test_draft7_optional_format__ipv4__validation_of_IP_addresses__a_valid_IP_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE5Mi4xNjguMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv4")]
        public void Test_draft7_optional_format__ipv4__validation_of_IP_addresses__an_IP_address_with_too_many_components_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEyNy4wLjAuMC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv4")]
        public void Test_draft7_optional_format__ipv4__validation_of_IP_addresses__an_IP_address_with_out_of_range_values_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjI1Ni4yNTYuMjU2LjI1NiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv4")]
        public void Test_draft7_optional_format__ipv4__validation_of_IP_addresses__an_IP_address_without_4_components_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEyNy4wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv4")]
        public void Test_draft7_optional_format__ipv4__validation_of_IP_addresses__an_IP_address_as_an_integer_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY0In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjB4N2YwMDAwMDEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv6")]
        public void Test_draft7_optional_format__ipv6__validation_of_IPv6_addresses__a_valid_IPv6_address()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ijo6MSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv6")]
        public void Test_draft7_optional_format__ipv6__validation_of_IPv6_addresses__an_IPv6_address_with_out_of_range_values_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEyMzQ1Ojoi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv6")]
        public void Test_draft7_optional_format__ipv6__validation_of_IPv6_addresses__an_IPv6_address_with_too_many_components_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjE6MToxOjE6MToxOjE6MToxOjE6MToxOjE6MToxOjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("ipv6")]
        public void Test_draft7_optional_format__ipv6__validation_of_IPv6_addresses__an_IPv6_address_containing_illegal_characters_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcHY2In0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ijo6bGFwdG9wIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__a_valid_IRI()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly/GksO4w7guw5/DpXIvP+KIgsOpxZM9z4DDrngjz4DDrsO8eCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__a_valid_protocol_relative_IRI_Reference_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii8vxpLDuMO4LsOfw6VyLz/iiILDqcWTPc+Aw654I8+Aw67DvHgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__a_valid_relative_IRI_Reference_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii/Dos+Az4Ai");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__an_invalid_IRI_Reference_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWzDq8Ofw6Vyw6ki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__a_valid_IRI_Reference_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IsOiz4DPgCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__a_valid_IRI_fragment_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiPGknLDpGdtw6pudCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri-reference")]
        public void Test_draft7_optional_format__iri_reference__validation_of_IRI_References__an_invalid_IRI_fragment_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiPGknLDpGdcXG3Dqm50Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__a_valid_IRI_with_anchor_tag()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly/GksO4w7guw5/DpXIvP+KIgsOpxZM9z4DDrngjz4DDrsO8eCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__a_valid_IRI_with_anchor_tag_and_parantheses_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly/GksO4w7guY29tL2JsYWhfKHfDrmvDr3DDqWRpw6UpX2JsYWgjw59pdMOpLTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [Ignore]
        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__a_valid_IRI_with_URL_encoded_stuff_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly/GksO4w7guw5/DpXIvP3E9VGVzdCUyMFVSTC1lbmNvZGVkJTIwc3R1ZmYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__a_valid_IRI_with_many_special_characters_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly8tLn5fISQmJygpKissOz06JTQwOjgwJTJmOjo6Ojo6QGV4YW1wbGUuY29tIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__a_valid_IRI_based_on_IPv6_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9bMjAwMTowZGI4Ojg1YTM6MDAwMDowMDAwOjhhMmU6MDM3MDo3MzM0XSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__an_invalid_IRI_based_on_IPv6_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly8yMDAxOjBkYjg6ODVhMzowMDAwOjAwMDA6OGEyZTowMzcwOjczMzQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__an_invalid_relative_IRI_Reference_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9hYmMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__an_invalid_IRI_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWzDq8Ofw6Vyw6ki");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("iri")]
        public void Test_draft7_optional_format__iri__validation_of_IRIs__an_invalid_IRI_though_valid_IRI_reference_9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJpcmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IsOiz4DPgCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___a_valid_JSON_pointer()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vYmFyfjAvYmF6fjEvJWEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer____not_escaped__2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vYmFyfiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_with_empty_segment_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vL2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_with_the_last_empty_segment_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vYmFyLyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__1_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__2_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__3_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vMCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__4_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii8i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__5_9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9hfjFiIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__6_10()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9jJWQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__7_11()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9lXmYi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__8_12()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9nfGgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__9_13()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9pXFxqIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__10_14()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9rXCJsIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__11_15()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii8gIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_as_stated_in_RFC_6901__12_16()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9tfjBuIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer_used_adding_to_the_last_array_position_17()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vLSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer____used_as_object_member_name__18()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vLS9iYXIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer__multiple_escaped_characters__19()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+MX4wfjB+MX4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer__escaped_with_fraction_part___1_20()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+MS4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___valid_JSON_pointer__escaped_with_fraction_part___2_21()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+MC4xIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__URI_Fragment_Identifier___1_22()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__URI_Fragment_Identifier___2_23()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiMvIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__URI_Fragment_Identifier___3_24()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiNhIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__some_escaped__but_not_all___1_25()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+MH4i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__some_escaped__but_not_all___2_26()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+MC9+Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__wrong_escape_character___1_27()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+MiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__wrong_escape_character___2_28()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+LTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__multiple_characters_not_escaped__29()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9+fiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__isn_t_empty_nor_starts_with_____1_30()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__isn_t_empty_nor_starts_with_____2_31()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("json-pointer")]
        public void Test_draft7_optional_format__json_pointer__validation_of_JSON_pointers__JSON_String_Representation___not_a_valid_JSON_pointer__isn_t_empty_nor_starts_with_____3_32()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJqc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImEvYSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("regex")]
        public void Test_draft7_optional_format__regex__validation_of_regular_expressions__a_valid_regular_expression()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IihbYWJjXSkrXFxzKyQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("regex")]
        public void Test_draft7_optional_format__regex__validation_of_regular_expressions__a_regular_expression_with_unclosed_parens_is_invalid_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWdleCJ9", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Il4oYWJjXSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("relative-json-pointer")]
        public void Test_draft7_optional_format__relative_json_pointer__validation_of_Relative_JSON_Pointers__RJP___a_valid_upwards_RJP()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWxhdGl2ZS1qc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("relative-json-pointer")]
        public void Test_draft7_optional_format__relative_json_pointer__validation_of_Relative_JSON_Pointers__RJP___a_valid_downwards_RJP_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWxhdGl2ZS1qc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjAvZm9vL2JhciI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("relative-json-pointer")]
        public void Test_draft7_optional_format__relative_json_pointer__validation_of_Relative_JSON_Pointers__RJP___a_valid_up_and_then_down_RJP__with_array_index_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWxhdGl2ZS1qc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjIvMC9iYXovMS96aXAi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("relative-json-pointer")]
        public void Test_draft7_optional_format__relative_json_pointer__validation_of_Relative_JSON_Pointers__RJP___a_valid_RJP_taking_the_member_or_index_name_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWxhdGl2ZS1qc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjAjIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("relative-json-pointer")]
        public void Test_draft7_optional_format__relative_json_pointer__validation_of_Relative_JSON_Pointers__RJP___an_invalid_RJP_that_is_a_valid_JSON_Pointer_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJyZWxhdGl2ZS1qc29uLXBvaW50ZXIifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9mb28vYmFyIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("time")]
        public void Test_draft7_optional_format__time__validation_of_time_strings__a_valid_time_string()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ0aW1lIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjA4OjMwOjA2LjI4MzE4NVoi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("time")]
        public void Test_draft7_optional_format__time__validation_of_time_strings__an_invalid_time_string_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ0aW1lIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjA4OjMwOjA2IFBTVCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("time")]
        public void Test_draft7_optional_format__time__validation_of_time_strings__only_RFC3339_not_all_of_ISO_8601_are_valid_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ0aW1lIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjAxOjAxOjAxLDExMTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__a_valid_URI()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9iYXo9cXV4I3F1dXgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__a_valid_protocol_relative_URI_Reference_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii8vZm9vLmJhci8/YmF6PXF1eCNxdXV4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__a_valid_relative_URI_Reference_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9hYmMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__an_invalid_URI_Reference_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWxlc2hhcmUi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__a_valid_URI_Reference_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__a_valid_URI_fragment_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiNmcmFnbWVudCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-reference")]
        public void Test_draft7_optional_format__uri_reference__validation_of_URI_References__an_invalid_URI_fragment_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktcmVmZXJlbmNlIn0=", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IiNmcmFnXFxtZW50Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-template")]
        public void Test_draft7_optional_format__uri_template__format__uri_template__a_valid_uri_template()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9leGFtcGxlLmNvbS9kaWN0aW9uYXJ5L3t0ZXJtOjF9L3t0ZXJtfSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-template")]
        public void Test_draft7_optional_format__uri_template__format__uri_template__an_invalid_uri_template_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9leGFtcGxlLmNvbS9kaWN0aW9uYXJ5L3t0ZXJtOjF9L3t0ZXJtIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-template")]
        public void Test_draft7_optional_format__uri_template__format__uri_template__a_valid_uri_template_without_variables_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9leGFtcGxlLmNvbS9kaWN0aW9uYXJ5Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri-template")]
        public void Test_draft7_optional_format__uri_template__format__uri_template__a_valid_relative_uri_template_4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmktdGVtcGxhdGUifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImRpY3Rpb25hcnkve3Rlcm06MX0ve3Rlcm19Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_with_anchor_tag()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9iYXo9cXV4I3F1dXgi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_with_anchor_tag_and_parantheses_2()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uY29tL2JsYWhfKHdpa2lwZWRpYSlfYmxhaCNjaXRlLTEi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_with_URL_encoded_stuff_3()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly9mb28uYmFyLz9xPVRlc3QlMjBVUkwtZW5jb2RlZCUyMHN0dWZmIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_puny_coded_URL__4()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly94bi0tbncyYS54bi0tajZ3MTkzZy8i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_with_many_special_characters_5()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly8tLn5fISQmJygpKissOz06JTQwOjgwJTJmOjo6Ojo6QGV4YW1wbGUuY29tIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_based_on_IPv4_6()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly8yMjMuMjU1LjI1NS4yNTQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_with_ftp_scheme_7()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImZ0cDovL2Z0cC5pcy5jby56YS9yZmMvcmZjMTgwOC50eHQi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL_for_a_simple_text_file_8()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly93d3cuaWV0Zi5vcmcvcmZjL3JmYzIzOTYudHh0Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URL__9()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImxkYXA6Ly9bMjAwMTpkYjg6OjddL2M9R0I/b2JqZWN0Q2xhc3M/b25lIg==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_mailto_URI_10()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Im1haWx0bzpKb2huLkRvZUBleGFtcGxlLmNvbSI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_newsgroup_URI_11()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Im5ld3M6Y29tcC5pbmZvc3lzdGVtcy53d3cuc2VydmVycy51bml4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_tel_URI_12()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("InRlbDorMS04MTYtNTU1LTEyMTIi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__a_valid_URN_13()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOmRvY2Jvb2s6ZHRkOnhtbDo0LjEuMiI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__an_invalid_protocol_relative_URI_Reference_14()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii8vZm9vLmJhci8/YmF6PXF1eCNxdXV4Ig==");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__an_invalid_relative_URI_Reference_15()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Ii9hYmMi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__an_invalid_URI_16()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IlxcXFxXSU5ET1dTXFxmaWxlc2hhcmUi");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__an_invalid_URI_though_valid_URI_reference_17()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("ImFiYyI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__an_invalid_URI_with_spaces_18()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("Imh0dHA6Ly8gc2hvdWxkZmFpbC5jb20i");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("draft7_optional_format")]
        [TestCategory("uri")]
        public void Test_draft7_optional_format__uri__validation_of_URIs__an_invalid_URI_with_spaces_and_missing_scheme_19()
        {
            var s = ParseSchema("eyJmb3JtYXQiOiJ1cmkifQ==", new Uri("http://json-schema.org/draft-07/schema#"));
            var t = ParseElement("IjovLyBzaG91bGQgZmFpbCI=");

            JsonSchemaExpressionBuilder.CreateDefault().Build(s).Compile()(t).Should().BeFalse();
        }


    }

}
