namespace AngelissimaTest
{
    using AngelissimaApi;
    using AutoMapper;
    using Xunit;

    public class GeneralTest
    {
        [Fact]
        public void AutoMapperConfigurationIsValid()
        {
            Mapper.Initialize(m => m.AddProfile<AutoMapperConfig>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}
