using evoFlix.WPF.Models;
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
    public class SubtitleManagerTests
    {

        private string debugPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");

        [Test]
        public void ReturnAvailableSources_ShouldPass()
        {
            string path = debugPath + @"TestCases\SubtitleManagerTests\sample.mvk";
            string expectedPath = debugPath + @"TestCases\SubtitleManagerTests\sample.ass";
            var sut = new SubtitleManager(path);

            List<string> result = sut.ReturnAvailableSources(path);

            Assert.That(result, Has.Exactly(2).Items);
            Assert.That(result, Does.Contain(expectedPath));
        }

        [Test]
        //00:06:45 = 405000
        [TestCase(405000, "Hívd a királynőt!\n")]
        //00:39:28.468 = 2368468
        [TestCase(2368468, "Csak azért, mert Lex Luthor\nazt állítja, hogy veszélyben a Föld?\n")]
        //01:00:17.685 = 3617685
        [TestCase(3617685, "Már itt van.\n")]
        public void GetText_ShouldPass(int position, string expected)
        {
            expected = expected.Replace("\n", Environment.NewLine);

            var sut = new SubtitleManager(debugPath + @"TestCases\SubtitleManagerTests\sample.mvk");

            sut.SetCurrentSubtitle(sut.AvailableSubtitlePaths[1]);
            string result = sut.GetText(position);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddSubtitlePath_ShouldPass()
        {
            string path = debugPath + @"TestCases\SubtitleManagerTests\sample.mvk";
            var sut = new SubtitleManager(path);
            string pathToAdd = debugPath + @"TestCases\SubtitleManagerTests\subtitle.ass";

            sut.AddSubtitlePath(pathToAdd);
            Assert.That(sut.AvailableSubtitlePaths, Does.Contain(pathToAdd));
        }

        [Test]
        public void AddSubtitlePath_NotExistingFileShouldFail()
        {
            string path = debugPath + @"TestCases\SubtitleManagerTests\sample.mvk";
            var sut = new SubtitleManager(path);
            string pathToAdd =  "notExistingFile.ass";

            Assert.Throws<ArgumentException>(() => sut.AddSubtitlePath(pathToAdd));
            Assert.That(sut.AvailableSubtitlePaths, Does.Not.Contain(pathToAdd));
        }

        [Test]
        public void AddSubtitlePath_InvalidExtensionShouldFail()
        {
            string path = debugPath + @"TestCases\SubtitleManagerTests\sample.mvk";
            var sut = new SubtitleManager(path);
            string pathToAdd = debugPath + @"TestCases\SubtitleManagerTests\FileWithBadExtension.txt";

            Assert.Throws<ArgumentException>(() => sut.AddSubtitlePath(pathToAdd));
            Assert.That(sut.AvailableSubtitlePaths, Does.Not.Contain(pathToAdd));
        }
    }
}
