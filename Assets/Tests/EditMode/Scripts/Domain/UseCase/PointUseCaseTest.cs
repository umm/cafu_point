using System.IO;
using ExtraUniRx;
using NUnit.Framework;

namespace CAFU.Point.Domain.UseCase
{
    public class PointUseCaseTest
    {
        private IPointUseCase usecase;

        private readonly string savePath = UnityEngine.Application.temporaryCachePath + "/test.kv";

        [SetUp]
        public void SetUp()
        {
            this.usecase = new PointUseCase.Factory().Create(this.savePath, "key");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(this.savePath))
            {
                File.Delete(this.savePath);
            }
        }

        [Test]
        public void AddTest()
        {
            var observer = new TestObserver<int>();
            this.usecase.PointAsObservable.Subscribe(observer);
            Assert.AreEqual(1, observer.OnNextCount);
            Assert.AreEqual(0, observer.OnNextValues[0]);
            Assert.AreEqual(0, this.usecase.Point);

            this.usecase.Point += 1;
            Assert.AreEqual(2, observer.OnNextCount);
            Assert.AreEqual(1, observer.OnNextValues[1]);
            Assert.AreEqual(1, this.usecase.Point);

            this.usecase.Point += 2;
            Assert.AreEqual(3, observer.OnNextCount);
            Assert.AreEqual(3, observer.OnNextValues[2]);
            Assert.AreEqual(3, this.usecase.Point);
        }

        [Test]
        public void SetTest()
        {
            var observer = new TestObserver<int>();
            this.usecase.PointAsObservable.Subscribe(observer);
            Assert.AreEqual(1, observer.OnNextCount);
            Assert.AreEqual(0, observer.OnNextValues[0]);
            Assert.AreEqual(0, this.usecase.Point);

            this.usecase.Point = 1;
            Assert.AreEqual(2, observer.OnNextCount);
            Assert.AreEqual(1, observer.OnNextValues[1]);
            Assert.AreEqual(1, this.usecase.Point);

            this.usecase.Point = 2;
            Assert.AreEqual(3, observer.OnNextCount);
            Assert.AreEqual(2, observer.OnNextValues[2]);
            Assert.AreEqual(2, this.usecase.Point);
        }

        [Test]
        public void SaveLoadTest()
        {
            this.usecase.Point += 100;
            this.usecase.Save();

            var observer = new TestObserver<int>();
            var usecase2 = new PointUseCase.Factory().Create(this.savePath, "key");
            usecase2.Load();
            usecase2.PointAsObservable.Subscribe(observer);

            Assert.AreEqual(1, observer.OnNextCount);
            Assert.AreEqual(100, observer.OnNextValues[0]);
        }


        [Test]
        public void LoadWithoutSaveTest()
        {
            Assert.DoesNotThrow(() =>
            {
                this.usecase.Load();
            });

            this.usecase.Point += 10;
            this.usecase.Save();
            
            var usecase2 = new PointUseCase.Factory().Create(this.savePath, "key");
            usecase2.Load();
            Assert.AreEqual(10, usecase2.Point);
        }
    }
}