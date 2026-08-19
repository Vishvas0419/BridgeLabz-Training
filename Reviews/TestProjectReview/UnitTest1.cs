using Reviews;

namespace TestProjectReview
{
    public class Tests
    {
        private RegexParse parser; //arrange
        [SetUp]
        public void Setup()
        {
            parser = new RegexParse();
        }
        [Test]
        public void Parse_ValidInput_ShouldParseCorrectly()
        {
            string input = "USER:u8823|TITLE:The Last Horizon (2025)|GENRES:sci-fi,drama|WATCHED:87%|TS:2026-08-14T21:10:00";

            ViewingSession session = parser.Parse(input); //act
            //assert
            Assert.That(session.Username, Is.EqualTo("u8823"));
            Assert.That(session.Title, Is.EqualTo("The Last Horizon"));
            Assert.That(session.Year, Is.EqualTo(2025));
            Assert.That(session.WatchedPercentage, Is.EqualTo(87));
            Assert.That(session.GenreList, Does.Contain("sci-fi"));
        }
    }
}