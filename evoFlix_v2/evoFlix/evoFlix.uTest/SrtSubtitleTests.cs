using evoFlix.WPF.Models.Subtitle;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.uTest
{
    [TestFixture]
    public class SrtSubtitleTests
    {
        private string debugPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");

        [Test]
        public void SrtSubtileParse()
        {
            var expected = new List<SubtitleLine>()
            {
                new SubtitleLine(709431, 711600, "Nem megyek sehova." + Environment.NewLine),
                new SubtitleLine(740546, 745926, "Hogy is van ez? Mindig" + Environment.NewLine + "felveszel egy ilyen denevérjelmezt?" + Environment.NewLine),
                new SubtitleLine(582763, 587017, "Hat napja semmi se tud" + Environment.NewLine + "felszállni. Hogy kerül ide?" + Environment.NewLine),
                new SubtitleLine(663844, 666764, "- Ötezer dollárért." + Environment.NewLine + "- Huszonötezret adok," + Environment.NewLine),
            };

            var sut = new SrtSubtitle(debugPath + @"TestCases\SubtitleTests\SRT\TestCases.srt");

            Assert.That(sut.SubtitleLines, Has.Exactly(expected.Count).Items);
            for (int i = 0; i < expected.Count; i++)
                Assert.That(sut.SubtitleLines[i], Is.EqualTo(expected[i]));
        }
    }
}
