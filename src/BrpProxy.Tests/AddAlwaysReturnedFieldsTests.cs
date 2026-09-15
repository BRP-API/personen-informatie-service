using BrpProxy.Validators;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BrpProxy.Tests
{
    public class AddAlwaysReturnedFieldsTests
    {
        [Theory]
        [InlineData("geheimhoudingPersoonsgegevens")]
        [InlineData("opschortingBijhouding")]
        [InlineData("rni")]
        [InlineData("verificatie")]
        public void AlwaysReturnedFields(string expectedField)
        {
            new List<string>().AddAlwaysReturnedFields().Should().Contain(expectedField);
        }
    }
}
