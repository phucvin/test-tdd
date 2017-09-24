using NUnit.Framework;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestSimpleUiPure
    {
        private SimpleDataPure _data;
        private SimpleStorePure _store;
        private SimpleUiPure _ui;

        [SetUp]
        public void SetUp()
        {
            _data = new SimpleDataPure();
            _data.energyCostPerAdd = 2;

            _store = new SimpleStorePure();

            _ui = new SimpleUiPure();
            _ui.Data = _data;
            _ui.Store = _store;
            _ui.Init();
        }

        [Test]
        public void UnavailableAtFirst()
        {
            Assert.False(_ui.Available);
        }

        [Test]
        public void AvailableAfterReceiveServiceTime()
        {
            _ui.receiveWhatTimeIsIt(123);

            Assert.True(_ui.Available);
        }

        [Test]
        public void UnavailableAfterFailReceiveServiceTime()
        {
            _ui.failWhatTimeIsIt();

            Assert.False(_ui.Available);
        }

        [Test]
        public void AfterAddShowCorrectMessage()
        {
            _ui.receiveWhatTimeIsIt(35);
            _ui.receiveAdded(10);

            Assert.AreEqual("Sum is 10", _ui.Message);
        }

        [Test]
        public void BeforeInitMessageIsCorrect()
        {
            Assert.AreEqual("Please wait...", _ui.Message);
        }

        [Test]
        public void UnavailableMessageIsCorrect()
        {
            _ui.failWhatTimeIsIt();

            Assert.AreEqual("Can not connect to service", _ui.Message);
        }

        [Test]
        public void AvailableMessageIsCorrect()
        {
            _ui.receiveWhatTimeIsIt(9);

            Assert.AreEqual("Please do something", _ui.Message);
        }

        [Test]
        public void AddSuccessConsumeCorrectEnergy()
        {
            _store.Energy = 10;
            _ui.receiveWhatTimeIsIt(3);
            _ui.receiveAdded(10);

            Assert.AreEqual(8, _store.Energy);
        }

        [Test]
        public void CanNotAddIfNotEnoughtEnergy([Values(1, 0)] int startEnergy)
        {
            _store.Energy = startEnergy;
            _ui.receiveWhatTimeIsIt(7);

            Assert.False(_ui.checkBeforeDoAdd());
        }

        [Test]
        public void CanAddIfEnoughEnergy([Values(3, 2)] int startEnergy)
        {
            _store.Energy = startEnergy;
            _ui.receiveWhatTimeIsIt(55);

            Assert.True(_ui.checkBeforeDoAdd());
        }

        [Test]
        public void CanNotAddAndShowCorrectMessage()
        {
            _store.Energy = 0;
            _ui.receiveWhatTimeIsIt(11);

            Assert.False(_ui.checkBeforeDoAdd());
            Assert.AreEqual("Not enough energy", _ui.Message);
        }

        [Test]
        public void AddFailShowCorrectMessage()
        {
            _store.Energy = 10;
            _ui.receiveWhatTimeIsIt(87);
            _ui.failAdd();

            Assert.AreEqual("Error receive result from service", _ui.Message);
        }

        [Test]
        public void AddFailRefundEnergy()
        {
            _store.Energy = 10;
            _ui.receiveWhatTimeIsIt(23);
            _ui.failAdd();

            Assert.AreEqual(10, _store.Energy);
        }

        [Test]
        public void ShowWaitingAfterCallAdd()
        {
            _store.Energy = 10;
            _ui.receiveWhatTimeIsIt(50);
            _ui.checkBeforeDoAdd();

            Assert.AreEqual("Please wait...", _ui.Message);
        }

        [Test]
        public void AddEvenUnavailableShowCorrectMessage()
        {
            _ui.checkBeforeDoAdd();

            Assert.False(_ui.Available);
            Assert.AreEqual("Can not connect to service", _ui.Message);
        }
    }
}