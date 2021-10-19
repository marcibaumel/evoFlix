using evoFlix.WPF.Models.Subtitle;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.uTest
{
    [TestFixture]
    public class AssSubtitleTests
    {
        private string DebugPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");

        [Test]
        public void AssSubtileParse_ShouldPass()
        {
            var expected = new List<SubtitleLine>()
            {
                new SubtitleLine(23010, 25250, "The earth dragon. A first-class Danger Beast."),
                new SubtitleLine(61170, 64250, "That thing was no match for me. It was child's play!"),
                new SubtitleLine(124800, 127140, "claiming everything as their own."),
                new SubtitleLine(1397790, 1402040, "I wish I'd never known love"),
            };

            var sut = new AssSubtitle(DebugPath + @"TestCases\SubtitleTests\ASS\TestCases.ass");

            Assert.That(sut.SubtitleLines, Has.Exactly(expected.Count).Items);
            for (int i = 0; i < expected.Count; i++)
                Assert.That(sut.SubtitleLines[i], Is.EqualTo(expected[i]));
        }
    }
}
