using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capercali.DataAccess.SimpleStore;
using Capercali.Entities;
using NUnit.Framework;

namespace Capercali.UnitTests.DataAccess.SimpleStore
{
    [TestFixture]
    public class RunnerServiceTests
    {
        private const long EVENT_ID = 6;

        [Test]
        [TestCase("Yann")]
        [TestCase("Güd")]
        [TestCase("GÜDEl")]
        [TestCase("yann gü")]
        [TestCase("güDel  YAN")]
        [TestCase("Yannis  Güdel")]
        [TestCase("  Yannis  ")]
        public async void Search_FirstnameLastName_Find(string key)
        {
            var runnerServices = new SimpleStoreEventRunnersService(true);
            await runnerServices.UpdateRunners(EVENT_ID, new EventRunner(){LastName = "Yannis", FirstName = "Güdel"});
            Assert.AreEqual(1, (await runnerServices.Search(EVENT_ID, key)).Count());
        }

        [Test]
        [TestCase("Yannis x")]
        [TestCase("Yannisx")]
        [TestCase("Yannis güdel x")]
        [TestCase("x")]
        [TestCase("annis")]
        [TestCase("üdel")]
        public async void Search_FirstnameLastName_NotFind(string key)
        {
            long eventId = 6;
            var runnerServices = new SimpleStoreEventRunnersService(true);
            await runnerServices.UpdateRunners(eventId, new EventRunner() { LastName = "Yannis", FirstName = "Güdel" });
            Assert.AreEqual(0, (await runnerServices.Search(eventId, key)).Count());
        }

        [Test]
        [TestCase("34")]
        [TestCase("2345")]
        [TestCase("2345 yan")]
        public async void Search_SiCard_NotFind(string key)
        {
            long eventId = 6;
            var runnerServices = new SimpleStoreEventRunnersService(true);
            await runnerServices.UpdateRunners(eventId, new EventRunner() {SiNumber= 12345, LastName = "Yannis", FirstName = "Güdel" });
            Assert.AreEqual(0, (await runnerServices.Search(eventId, key)).Count());
        }
        [Test]
        [TestCase("123")]
        [TestCase("12")]
        [TestCase("1234 yan")]
        [TestCase("1234 güd")]
        [TestCase("12345 ")]
        public async void Search_SiCard_Find(string key)
        {
            long eventId = 6;
            var runnerServices = new SimpleStoreEventRunnersService(true);
            await runnerServices.UpdateRunners(eventId, new EventRunner() { SiNumber = 12345, LastName = "Yannis", FirstName = "Güdel" });
            Assert.AreEqual(1, (await runnerServices.Search(eventId, key)).Count());
        }

        [Test]
        [TestCase("güdel")]
        public async void Search_LastName_FindMultiple(string key)
        {
            long eventId = 6;
            var runnerServices = new SimpleStoreEventRunnersService(true);
            await runnerServices.UpdateRunners(eventId, new EventRunner() {
                LastName = "Yannis",
                FirstName = "Güdel"
            });
            await runnerServices.UpdateRunners(eventId, new EventRunner()
            {
                LastName = "Térence",
                FirstName = "Risse"
            });
            await runnerServices.UpdateRunners(eventId, new EventRunner()
            {
                LastName = "Fanny",
                FirstName = "Güdel"
            });
            Assert.AreEqual(2, (await runnerServices.Search(eventId, key)).Count());
        }
    }
}
