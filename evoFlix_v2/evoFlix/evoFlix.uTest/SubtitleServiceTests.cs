using evoFlix.WPF.Models.Subtitle;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.uTest
{
    [TestFixture]
    public class SubtitleServiceTests
    {
        private SubtitleService sut = new SubtitleService();

        [Test]
        [TestCase("xyz/xxyyzz.srt", FileExtension.SRT)]
        [TestCase("abcd/xyz/xxyyzz.ass", FileExtension.ASS)]
        [TestCase("xyz/xxyyzz.ass", FileExtension.ASS)]
        [TestCase("xxyyzz.srt", FileExtension.SRT)]
        public void GetExtension_ShouldPass(string path, FileExtension expectedExtension)
        {
            var result = sut.GetExtension(path);

            Assert.AreEqual(expectedExtension, result);
        }

        [Test]
        [TestCase("xyz/xy/file1.exe")]
        [TestCase("file2.txt")]
        public void GetExtension_InvalidExtensionShouldFail(string path)
        {
            Assert.Throws<ArgumentException>(() => sut.GetExtension(path));
        }

        [Test]
        [TestCase(".srt")]
        [TestCase(".SrT")]
        [TestCase("ASs")]
        [TestCase(".ass")]
        public void IsValidFileExtension_ShouldPass(string extension)
        {
            Assert.That(sut.IsValidFileExtension(extension), Is.True);
        }

        [Test]
        public void Sort_ShouldPass()
        {
            var subtitleMock = new Mock<ISubtitle>();
            var subtitleLines = new List<SubtitleLine>() { new SubtitleLine(1231, 1240, "some text..."),
                                                           new SubtitleLine(24, 30, "some other text..."),
                                                           new SubtitleLine(1, 2, "xyz"),};
            subtitleMock.SetupGet(x => x.SubtitleLines).Returns(subtitleLines);
            var expected = new List<SubtitleLine>() { new SubtitleLine(1, 2, "xyz"), 
                                                      new SubtitleLine(24, 30, "some other text..."),
                                                      new SubtitleLine(1231, 1240, "some text..."),};

            sut.Sort(subtitleMock.Object);

            for (int i = 0; i < subtitleMock.Object.SubtitleLines.Count; i++)
                Assert.AreEqual(subtitleMock.Object.SubtitleLines[i], expected[i]);
        }

        [Test]
        public void ConvertDateTimeToMilliSeconds_EdgeCaseShouldPass()
        {
            DateTime time = DateTime.Parse("23:11:59.999");
            int expected = 83519999;

            int result = sut.ConvertDateTimeToMilliSeconds(time);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("<i>Hat napja semmi se tud </i> <i> felszállni. </i> Hogy kerül ide?", "Hat napja semmi se tud   felszállni.  Hogy kerül ide?")]
        public void RemoveTags_ShouldPass(string text, string expected)
        {
            string result = sut.RemoveTags(text);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("  Egy mondat     sok szóközzel. ", "Egy mondat sok szóközzel.")]
        public void RemoveExtraSpaces_ShouldPass(string text, string expected)
        {
            string result = sut.RemoveExtraSpaces(text);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase(@"{\fad(100,0)\bord4\be4\move(450,25,640,25,0,100)\clip(1,54,1278,100)}kokoro ni kakushiteta omoi", "kokoro ni kakushiteta omoi")]
        [TestCase(@"{\fad(0,100)\c&HHDBDBDB&\3c&H000000&\bord0.4\be2\move(641.5,26,451.5,26,3600,3700)\clip(1,2,1278,54)}shizuka ni kotoba de kizande", "shizuka ni kotoba de kizande")]
        public void RemoveFormatSpecifiers_Shouldpass(string text, string expected)
        {
            string result = sut.RemoveFormatSpecifiers(text);

            Assert.AreEqual(result, expected);
        }
    }
}
